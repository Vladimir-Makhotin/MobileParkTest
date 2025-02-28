using MP.Api.Context;

namespace MP.Api.Domain.Interfaces
{
    public interface IBaseService
    {
        /// <summary>
        /// Получение всез записей из БД
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список ДТО</returns>
        protected Task<IList<T>> GetAll<T, TT>(CancellationToken token = default) 
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Получение записи по идентификаторам
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="ids"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Список записей</returns>
        protected Task<IList<T>> GetByIds<T, TT>(IEnumerable<Guid> ids, CancellationToken token = default) 
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Получить запись из по идентификатору
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="id"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Запись</returns>
        protected Task<T> GetById<T, TT>(Guid id, CancellationToken token = default) 
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Получить колличество записей в БД
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Колличество записей в БД</returns>
        protected Task<int> Count<T, TT>(CancellationToken token = default) 
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="models"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Идентефикатор добавленной записи</returns>
        protected Task<IList<Guid>> Add<T, TT>(IEnumerable<T> models, CancellationToken token = default)
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Обновить записи
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="models"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Количесвто обновленных записей</returns>
        protected Task<int> Update<T, TT>(IEnumerable<T> models, CancellationToken token = default)
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Обновить одну запись
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="model"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns>Обновленная сущность</returns>
        protected Task<T> Update<T, TT>(T model, CancellationToken token = default)
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Удалить запись
        /// </summary>
        /// <typeparam name="T">Тип ДТО</typeparam>
        /// <typeparam name="TT">Тип сущности БД</typeparam>
        /// <param name="guids"></param>
        /// <param name="token">Токен отмены операции</param>
        /// <returns></returns>
        protected Task<int> Delete<T, TT>(IEnumerable<Guid> guids, CancellationToken token = default)
            where T : class
            where TT : class, IBaseEntity, new();
    }
}
