using MP.Api.Context;

namespace MP.Api.Repository.Interfaces
{
    public interface ITicketRepository : IBaseRepository
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="token">Токен отмены операции</param>
        /// <remarks>Метод излишний, тк хватит реализации базового метода</remarks>
        /// <returns>Список записей</returns>
        Task<IList<Ticket>> GetTickets(CancellationToken token = default);

        /// <summary>
        /// Добавить запись 
        /// </summary>
        /// <param name="ticket">Сущность на добавление</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Идентификтаор добавленной записи</returns>
        Task<Guid> AddTicket(Ticket ticket, CancellationToken token = default);

        /// <summary>
        /// Получить записи по заданному периоду
        /// </summary>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список записей</returns>
        Task<IList<Ticket>> GetTicketsByPeriod(DateTime startDate, DateTime endDate, CancellationToken token = default);
    }
}
