using Microsoft.EntityFrameworkCore;
using MP.Api.Domain.Interfaces;
using MP.Api.Domain.Services;

namespace MP.Api.Domain
{
    public static class DomainSetup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBaseService, BaseService>();
            services.AddTransient<IMigrationService, MigrationService>();
            services.AddTransient<ITicketService, TicketService>();
            return services;
        }
    }
}
