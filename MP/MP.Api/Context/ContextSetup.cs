using Microsoft.EntityFrameworkCore;

namespace MP.Api.Context
{
    public static class ContextSetup
    {
        public static IServiceCollection AddContext(this IServiceCollection services, string defaulConnectionString)
        {
            services.AddLogging()
                .AddDbContextFactory<MPContext>(
                    o => o.UseNpgsql(
                        defaulConnectionString)
                    , ServiceLifetime.Scoped);
            services.AddHealthChecks()
                .AddDbContextCheck<MPContext>();
            return services;
        }
    }
}
