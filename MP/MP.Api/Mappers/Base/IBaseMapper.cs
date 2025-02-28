namespace MP.Api.Mappers.Base
{
    /// <summary>
    /// Базовый маппер для преобразования моделей
    /// </summary>
    /// <typeparam name="TDto">Первая модель</typeparam>
    /// <typeparam name="TModel">Вторая модель</typeparam>
    public interface IBaseMapper<TDto, TModel>
        where TDto : class
        where TModel : class
    {
        /// <summary>
        /// Метод преобразования TModel до TDto
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns>Преобразованная модель</returns>
        TDto Map(TModel model);

        /// <summary>
        /// Метод преобразования TDto до TModel
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns>Преобразованная модель</returns>
        TModel Map(TDto model);
    }
}
