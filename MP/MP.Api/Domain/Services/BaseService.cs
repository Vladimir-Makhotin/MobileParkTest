using Microsoft.EntityFrameworkCore;
using MP.Api.Context;
using MP.Api.Domain.Interfaces;
using MP.Api.Mappers.Base;
using MP.Api.Repository.Interfaces;

namespace MP.Api.Domain.Services
{
    public class BaseService(
        ILogger<BaseService> _logger
        , IMapperFactory _mapperFactory
        , IBaseRepository _repository) 
        : IBaseService
    {
        /// <inheritdoc/>
        public Task<int> Count<T, TT>(CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var res = _repository.Count<TT>(token);
            return res;
        }

        /// <inheritdoc/>
        public async Task<IList<T>> GetAll<T, TT>(CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var mapper = _mapperFactory.GetEntityMapper<T, TT>();
            var entities = await _repository.GetAll<TT>(token);
            var models = new List<T>();
            entities.ToList().ForEach(x =>
            {
                var model = mapper.Map(x);
                models.Add(model);
            });
            return models;
        }

        /// <inheritdoc/>
        public async Task<T> GetById<T, TT>(Guid id, CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var mapper = _mapperFactory.GetEntityMapper<T, TT>();
            var entity = await _repository.GetById<TT>(id, token);
            var model = mapper.Map(entity);
            return model;
        }

        /// <inheritdoc/>
        public async Task<IList<T>> GetByIds<T, TT>(IEnumerable<Guid> ids, CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var mapper = _mapperFactory.GetEntityMapper<T, TT>();
            var entities = await _repository.GetByIds<TT>(ids, token);
            var models = new List<T>();
            entities.ToList().ForEach(x =>
            {
                var model = mapper.Map(x);
                models.Add(model);
            });
            return models;
        }

        /// <inheritdoc/>
        public async Task<IList<Guid>> Add<T, TT>(IEnumerable<T> models, CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var mapper = _mapperFactory.GetEntityMapper<T, TT>();
            var entities = new List<TT>();
            models.ToList().ForEach(x =>
            {
                var entity = mapper.Map(x);
                entities.Add(entity);
            });
            var res = await _repository.Add(entities, token);
            return res;
        }

        /// <inheritdoc/>
        public async Task<int> Delete<T, TT>(IEnumerable<Guid> guids, CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var res = await _repository.Delete<TT>(guids, token);
            return res;
        }

        /// <inheritdoc/>
        public async Task<int> Update<T, TT>(IEnumerable<T> models, CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var mapper = _mapperFactory.GetEntityMapper<T, TT>();
            var entities = new List<TT>();
            models.ToList().ForEach(x =>
            {
                var entity = mapper.Map(x);
                entities.Add(entity);
            });
            var res = await _repository.Update(entities, token);
            return res;
        }

        /// <inheritdoc/>
        public async Task<T> Update<T, TT>(T model, CancellationToken token)
            where T : class
            where TT : class, IBaseEntity, new()
        {
            var mapper = _mapperFactory.GetEntityMapper<T, TT>();
            var entity = mapper.Map(model);
            var updatedEntity = await _repository.Update(entity, token);
            var res = mapper.Map(updatedEntity);
            return res;
        }
    }
}
