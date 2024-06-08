using BuberDinner.Application.Services.Authentication;
using BurberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.DependencyInjection;
using BurberDinner.Infrastructure.Authentication;
using BurberDinner.Application.Common.Interfaces.Services;
using BurberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Infrastructure.Persistence;

namespace BurberDinner.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure (
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.sectionName));
        services.AddSingleton<IjwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}