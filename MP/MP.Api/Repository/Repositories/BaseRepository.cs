using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MP.Api.Context;
using MP.Api.Repository.Interfaces;
using System.Threading;

namespace MP.Api.Repository.Repositories
{
    public class BaseRepository(
        ILogger<BaseRepository> _logger
        , IDbContextFactory<MPContext> _contextFactory) : IBaseRepository
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        /// <inheritdoc/>
        public async Task<MPContext> GetContext(CancellationToken token = default)
        {
            return await _contextFactory.CreateDbContextAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> Count<TEntity>(CancellationToken token = default)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                using var context = await GetContext(token);
                return await context.Set<TEntity>().CountAsync(token);
            }
            catch (Exception ex)
            {
                //_logger.GetEntityCountFailed(ex, nameof(TEntity));
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IList<TEntity>> GetAll<TEntity>(CancellationToken token = default)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                using var context = await GetContext(token);
                var res = context.Set<TEntity>();
                return await res.ToListAsync(token);
            }
            catch (Exception ex)
            {
                //_logger.GetObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<TEntity> GetById<TEntity>(Guid id, CancellationToken token = default)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                using var context = await GetContext(token);
                var res = context.Set<TEntity>().Where(x => x.Id == id);
                return await res.FirstOrDefaultAsync(token) ?? new();
            }
            catch (Exception ex)
            {
                //_logger.GetObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IList<TEntity>> GetByIds<TEntity>(IEnumerable<Guid> ids, CancellationToken token)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                using var context = await GetContext(token);
                var res = context.Set<TEntity>().Where(x => ids.Contains(x.Id));
                return await res.ToListAsync(token);
            }
            catch (Exception ex)
            {
                //_logger.GetObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IList<Guid>> Add<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                await _semaphore.WaitAsync(token);
                var guidList = new List<Guid>();
                entities.ToList().ForEach(x =>
                {
                    if (x.Id == Guid.Empty)
                        x.Id = Guid.NewGuid();
                    if (x is IBaseDateCreationEntity dateEntity)
                        dateEntity.CreationDate = DateTime.UtcNow;
                });
                using var context = await GetContext(token);

                var set = context.Set<TEntity>();
                await set.AddRangeAsync(entities, token);
                await context.SaveChangesAsync(token);

                guidList.AddRange(entities.Select(x => x.Id));
                return guidList;
            }
            catch (Exception ex)
            {
                //_logger.AddObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <inheritdoc/>
        public async Task<int> Delete<TEntity>(IEnumerable<Guid> guids, CancellationToken token)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                await _semaphore.WaitAsync(token);
                using var context = await GetContext(token);
                var res = await context.Set<TEntity>()
                    .AsQueryable()
                    .Where(x => guids.Contains(x.Id))
                    .ExecuteDeleteAsync(token);
                await context.SaveChangesAsync(token);

                return res;
            }
            catch (Exception ex)
            {
                //_logger.DeleteObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <inheritdoc/>
        public async Task<int> Update<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                await _semaphore.WaitAsync(token);
                using var context = await GetContext(token);
                context.Set<TEntity>()
                    .UpdateRange(entities.ToArray());
                var res = await context.SaveChangesAsync(token);

                return res;
            }
            catch (Exception ex)
            {
                //_logger.UpdateObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <inheritdoc/>
        public async Task<TEntity> Update<TEntity>(TEntity entity, CancellationToken token)
            where TEntity : class, IBaseEntity, new()
        {
            try
            {
                await _semaphore.WaitAsync(token);
                using var context = await GetContext(token);

                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync(token);

                return context.Entry(entity).Entity;

            }
            catch (Exception ex)
            {
                //_logger.UpdateObjectFromDbFailed(ex, nameof(TEntity));
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
