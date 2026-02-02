using DesafioSpedy.Application.Services;
using DesafioSpedy.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioSpedy.Application;

public static class ApplicationDependecyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<AuthenticationService>();
    }
}
