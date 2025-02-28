using MP.Api.Model.Requests;
using MP.Api.Model.Responces;

namespace MP.Api.Domain.Interfaces
{
    public interface ITicketService
    {
        /// <summary>
        /// Получить все билеты
        /// </summary>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список билетов</returns>
        Task<IList<TicketViewModel>> GetTickets(CancellationToken token = default);

        /// <summary>
        /// Добавить билет
        /// </summary>
        /// <param name="model">Билет</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Идентификатор добавленной записи</returns>
        Task<Guid> AddTicket(TicketUpsertModel model, CancellationToken token = default);

        /// <summary>
        /// Получить билеты по заднному периоду
        /// </summary>
        /// <param name="startDate">НАчало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список билетов</returns>
        Task<IList<TicketViewModel>> GetTicketsByPeriod(DateTime startDate, DateTime endDate, CancellationToken token = default);
    }
}
