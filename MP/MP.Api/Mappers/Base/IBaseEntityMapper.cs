using MP.Api.Context;

namespace MP.Api.Mappers.Base
{
    /// <summary>
    /// Базовый маппер для преобразования модели в сущность БД
    /// </summary>
    /// <typeparam name="TDto">Модель</typeparam>
    /// <typeparam name="TEntity">Сущность</typeparam>
    public interface IBaseEntityMapper<TDto, TEntity>
        where TDto : class
        where TEntity : class, IBaseEntity, new()
    {
        /// <summary>
        /// Метод преобразования TEntity до TDto
        /// </summary>
        /// <param name="entity">Модель</param>
        /// <returns>Преобразованная модель</returns>
        TDto Map(TEntity entity);

        /// <summary>
        /// Метод преобразования TDto до TEntity
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns>Преобразованная модель</returns>
        TEntity Map(TDto model);
    }
}
