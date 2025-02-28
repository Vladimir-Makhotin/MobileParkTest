using MP.Api.Context;
using MP.Api.Mappers.Base;
using MP.Api.Mappers.Mappers.TicketMappers;
using MP.Api.Model.Responces;
using MP.Api.Model.Requests;

namespace MP.Api.Mappers
{
    public static class MapperSetup
    {
        public static IServiceCollection AddBaseMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapperFactory, MapperFactory>();
            services.AddScoped<IBaseEntityMapper<TicketViewModel, Ticket>, TicketViewMapper>();
            services.AddScoped<IBaseEntityMapper<TicketUpsertModel, Ticket>, TicketUpsertMapper>();
            return services;
        }
    }
}
