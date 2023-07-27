using System.Reflection;
using Application.Common.Mappings;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        });
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService, UserService>();
        
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        
        return services;
    }
}