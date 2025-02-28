using MP.Api.Context;
using MP.Api.Mappers.Base;
using MP.Api.Model.Responces;

namespace MP.Api.Mappers.Mappers.TicketMappers
{
    internal class TicketViewMapper 
        : IBaseEntityMapper<TicketViewModel, Ticket>
    {
        /// <inheritdoc />
        public TicketViewModel Map(Ticket model)
            => new()
            {
                Description = model.Description,
                Title = model.Title,
                VisitDate = model.VisitDate,
                VisitorsNumber = model.VisitorsNumber,
                Id = model.Id,
            };

        /// <inheritdoc />
        public Ticket Map(TicketViewModel model)
            => new()
            {
                Description = model.Description,
                Title = model.Title,
                VisitDate = model.VisitDate,
                VisitorsNumber = model.VisitorsNumber,
            };
    }
}
