using Microsoft.EntityFrameworkCore;
using MP.Api.Context;
using MP.Api.Repository.Interfaces;

namespace MP.Api.Repository.Repositories
{
    internal class MigrationRepository(
        IDbContextFactory<MPContext> _dbContextFactory) 
        : IMigrationRepository
    {
        /// <inheritdoc />
        public async Task<bool> HasPendingMigrationsAsync(CancellationToken ct = default)
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);

            if (dbContext.Database.GetMigrations().Any())
            {
                var appliedMigrations = await dbContext.Database.GetAppliedMigrationsAsync(ct);
                if (!appliedMigrations.Any())
                    return true;

                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(ct);
                return pendingMigrations.Any();
            }

            throw new Exception("Миграции в сборке не найдены.");
        }

        /// <inheritdoc />
        public async Task RunMigration(CancellationToken ct = default)
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);
            await dbContext.Database.MigrateAsync(ct);
        }
    }
}
