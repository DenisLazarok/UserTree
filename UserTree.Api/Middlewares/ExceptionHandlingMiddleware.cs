using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using UserTree.Domain.Entities;
using UserTree.Domain.Exceptions;
using UserTree.Domain.Interfaces;

namespace UserTree.Api.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly IRepository<JournalEvent> _journalEventsRepository;

    private static readonly JsonSerializerOptions _jsonOptions =
        new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

    public ExceptionHandlingMiddleware(IRepository<JournalEvent> journalEventsRepository)
    {
        _journalEventsRepository = journalEventsRepository;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string method = context.Request.Method;

        context.Request.EnableBuffering();
        var requestBody = string.Empty;
        if (context.Request.Body.CanRead && (method == HttpMethods.Post || method == HttpMethods.Put))
        {
            using StreamReader reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                false,
                512, true);

            requestBody = await reader.ReadToEndAsync();

            context.Request.Body.Position = 0;
        }

        var journalRequest = JsonSerializer.Serialize(
            new JournalRequestData(requestBody, $"{context.Request.Path}{context.Request.QueryString}"),
            _jsonOptions);

        var journalEvent = new JournalEvent() {RequestData = journalRequest, TimeOffset = DateTimeOffset.UtcNow };
        await _journalEventsRepository.AddAsync(journalEvent);
        await _journalEventsRepository.SaveChangesAsync();
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            journalEvent.Data = exception.Message;
            journalEvent.StackTrace = exception.StackTrace;
            journalEvent.Type = exception.GetType().ToString();
            await _journalEventsRepository.UpdateAsync(journalEvent);
            await _journalEventsRepository.SaveChangesAsync();
            await HandleException(context, exception, journalEvent);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception, JournalEvent journalEvent)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case SecureException secureException:
                case ValidationException validationException:
                    result = JsonSerializer.Serialize(
                        new ErrorResponse("Secure", journalEvent.Id.ToString(),
                            new(exception.Message)),
                        _jsonOptions);
                    break;

                default:
                    result = JsonSerializer.Serialize(
                        new ErrorResponse("Exception", journalEvent.Id.ToString(),
                            new($"Internal server error ID = {journalEvent.Id}")),
                        _jsonOptions);
                    
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;

            await context.Response.WriteAsync(result);
        }

        record JournalRequestData(string RequestData, string Query);

        record ErrorResponse(string Type, string Id, ErrorDataResponse Data);

        record ErrorDataResponse(string Message);
    }