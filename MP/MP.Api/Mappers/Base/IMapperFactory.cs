using MP.Api.Context;

namespace MP.Api.Mappers.Base
{
    /// <summary>
    /// Фабрика мапперов
    /// </summary>
    public interface IMapperFactory
    {
        /// <summary>
        /// Получение маппера из ДТО в сущность БД
        /// </summary>
        /// <typeparam name="T">ДТО</typeparam>
        /// <typeparam name="TT">Сущность БД</typeparam>
        /// <returns>Маппер</returns>
        public IBaseEntityMapper<T, TT> GetEntityMapper<T, TT>()
            where T : class
            where TT : class, IBaseEntity, new();

        /// <summary>
        /// Получение маппера из ДТО в другую ДТО
        /// </summary>
        /// <typeparam name="T">ДТО</typeparam>
        /// <typeparam name="TT">Другая БД</typeparam>
        /// <returns>Маппер</returns>
        public IBaseMapper<T, TT> GetMapper<T, TT>()
            where T : class
            where TT : class;
    }
}
