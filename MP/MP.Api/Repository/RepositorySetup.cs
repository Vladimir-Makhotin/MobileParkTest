using MP.Api.Context;
using MP.Api.Repository.Interfaces;
using MP.Api.Repository.Repositories;

namespace MP.Api.Repository
{
    public static class RepositorySetup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMigrationRepository, MigrationRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            return services;
        }
    }
}
