using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services.AddDatabase(configuration)
                .AddRepositories(configuration);

        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<IUnityOfWork, UnityOfWork>();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("Default"))));
    }
}
