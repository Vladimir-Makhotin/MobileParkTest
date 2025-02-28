using MP.Api.Context;
using MP.Api.Mappers.Base;
using MP.Api.Model.Requests;

namespace MP.Api.Mappers.Mappers.TicketMappers
{
    public class TicketUpsertMapper 
        : IBaseEntityMapper<TicketUpsertModel, Ticket>
    {
        /// <inheritdoc />
        public TicketUpsertModel Map(Ticket model)
            => new()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                VisitDate = model.VisitDate,
                VisitorsNumber = model.VisitorsNumber,
            };

        /// <inheritdoc />
        public Ticket Map(TicketUpsertModel model)
            => new()
            {
                Description = model.Description,
                Title = model.Title,
                VisitDate = model.VisitDate,
                VisitorsNumber = model.VisitorsNumber,
            };
    }
}
