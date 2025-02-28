using MP.Api.Context;

namespace MP.Api.Mappers.Base
{
    /// <summary>
    /// Реализации фабрики мапперов
    /// </summary>
    /// <param name="_provider">ДИ контейнер</param>
    internal class MapperFactory(IServiceProvider _provider) 
        : IMapperFactory
    {
        /// <inheritdoc />
        public IBaseEntityMapper<T, TT> GetEntityMapper<T, TT>()
            where T : class
            where TT : class, IBaseEntity, new()
        {
            return _provider.GetRequiredService<IBaseEntityMapper<T, TT>>();
        }

        /// <inheritdoc />
        public IBaseMapper<T, TT> GetMapper<T, TT>()
            where T : class
            where TT : class
        {
            return _provider.GetRequiredService<IBaseMapper<T, TT>>();
        }
    }
}
