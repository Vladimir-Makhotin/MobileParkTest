using MP.Api.Context;
using MP.Api.Domain.Interfaces;
using MP.Api.Mappers.Base;
using MP.Api.Model.Requests;
using MP.Api.Model.Responces;
using MP.Api.Repository.Interfaces;

namespace MP.Api.Domain.Services
{
    internal class TicketService(
        ILogger<TicketService> _logger
        , IMapperFactory _mapperFactory
        , ITicketRepository _repository) 
        : BaseService(_logger, _mapperFactory, _repository)
        , ITicketService
    {
        /// <inheritdoc/>
        public async Task<IList<TicketViewModel>> GetTickets(CancellationToken token = default)
        {
            var res = await GetAll<TicketViewModel, Ticket>(token);
            return res.ToList();
        }

        /// <inheritdoc/>
        public async Task<Guid> AddTicket(TicketUpsertModel model, CancellationToken token = default)
        {
            model.VisitDate = TimeZoneInfo.ConvertTimeToUtc(model.VisitDate);
            var res = await Add<TicketUpsertModel, Ticket>([model], token);
            return res.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<IList<TicketViewModel>> GetTicketsByPeriod(DateTime startDate, DateTime endDate, CancellationToken token = default)
        {
            var entities = await GetTicketsByPeriod(startDate, endDate, token);
            var mapper = _mapperFactory.GetEntityMapper<TicketViewModel, Ticket>();
            List<TicketViewModel> res = new();
            entities.ToList().ForEach(x =>
            {
                var ticket = mapper.Map(x);
                res.Add(x);
            });
            return res;
        }
    }
}
