using DesafioSpedy.Domain.Authorization;
using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Repositories;
using DesafioSpedy.Infrastructure.Crypto;
using DesafioSpedy.Infrastructure.DataAccess;
using DesafioSpedy.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioSpedy.Infrastructure;

public static class InfrastructureDependecyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddCrypto(services);
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<DesafioSpedyDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
    }
    public static void AddCrypto(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();
        services.AddScoped<IJwtGenerator, JwtGenerator>();
    }
}
