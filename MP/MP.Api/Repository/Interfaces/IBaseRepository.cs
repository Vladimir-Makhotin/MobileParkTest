using MP.Api.Context;

namespace MP.Api.Repository.Interfaces
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Метод получения контекста
        /// </summary>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Контекст</returns>
        Task<MPContext> GetContext(CancellationToken token = default);

        /// <summary>
        /// Получить все сущности из базы
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список сущностей</returns>
        Task<IList<TEntity>> GetAll<TEntity>(CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Получить список сущностей по списку идентификаторов
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="ids">Список индетификаторов</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список сущностей</returns>
        Task<IList<TEntity>> GetByIds<TEntity>(IEnumerable<Guid> ids, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="id">Идентификатор</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Сущность по идентификатору</returns>
        Task<TEntity> GetById<TEntity>(Guid id, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Получить количество записей по типу сущности
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Число записей</returns>
        Task<int> Count<TEntity>(CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Добавить список экзамляров сущности
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entities"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns></returns>
        Task<IList<Guid>> Add<TEntity>(IEnumerable<TEntity> entities, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Массовое обновление записей
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entities">Список экземпляров сущности</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Количество обновленных записей</returns>
        Task<int> Update<TEntity>(IEnumerable<TEntity> entities, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Обновление одной записи
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>True - успешное обвновление, иначе false</returns>
        Task<TEntity> Update<TEntity>(TEntity entity, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();

        /// <summary>
        /// Удаление записей по идентфикаторам
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="guids">Список идентификаторов</param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Количество удаленных записей</returns>
        Task<int> Delete<TEntity>(IEnumerable<Guid> guids, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new();
    }
}
