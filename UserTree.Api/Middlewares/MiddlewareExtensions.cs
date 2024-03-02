namespace UserTree.Api.Middlewares;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseOwnExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}