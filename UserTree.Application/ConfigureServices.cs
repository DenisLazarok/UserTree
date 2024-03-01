using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UserTree.Application.Extensions;
using UserTree.Application.Services;
using UserTree.Domain.Services;

namespace UserTree.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddScoped<ITreeNodeValidator, TreeNodeValidator>();

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new MappingProfile());
        });
        
        return services;
    }
}