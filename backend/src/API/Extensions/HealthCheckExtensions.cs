using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.Extensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddDatabaseHealthCheck(this IServiceCollection services, IConfiguration configuration)
            => services.AddHealthChecks()
                .AddMySql(
                    configuration.GetConnectionString("Default")!,
                    name: "database",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: ["db", "sql"]).Services;
    }
}
