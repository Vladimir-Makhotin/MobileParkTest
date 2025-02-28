using Microsoft.EntityFrameworkCore;
using MP.Api.Context;
using MP.Api.Logs;
using MP.Api.Repository.Interfaces;

namespace MP.Api.Repository.Repositories
{
    public class TicketRepository(
        ILogger<BaseRepository> _logger
        , IDbContextFactory<MPContext> _contextFactory) 
        : BaseRepository(_logger, _contextFactory)
        , ITicketRepository
    {
        /// <inheritdoc />
        public async Task<IList<Ticket>> GetTickets(CancellationToken token = default)
        {
            var res = await GetAll<Ticket>(token);
            return res;
        }

        /// <inheritdoc />
        public async Task<Guid> AddTicket(Ticket ticket, CancellationToken token = default)
        {
            if (ticket is null)
                throw new ArgumentNullException();

            var res = await Add([ticket], token);

            return res.FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<IList<Ticket>> GetTicketsByPeriod(DateTime startDate, DateTime endDate, CancellationToken token = default)
        {
            try
            {
                using var context = await GetContext(token);

                var res = await context.Tickets
                    .Where(x => x.VisitDate >= startDate && endDate <= x.VisitDate)
                    .ToListAsync(token);

                return res;
            }
            catch(Exception ex)
            {
                _logger.GetObjectFromDbFailed(ex, nameof(Ticket));
                throw;
            }
        }
    }
}
