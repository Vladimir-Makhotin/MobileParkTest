using MP.Api.Domain.Interfaces;
using MP.Api.Logs;
using MP.Api.Repository.Interfaces;

namespace MP.Api.Domain.Services
{
    internal class MigrationService(
        ILogger<MigrationService> _logger
        , IMigrationRepository _migrationRepository) 
        : IMigrationService
    {
        /// <inheritdoc />
        public async Task ApplyDbMigrationsAsync(CancellationToken ct = default)
        {
            var hasMigrations = await _migrationRepository.HasPendingMigrationsAsync(ct);
            if (hasMigrations)
            {
                _logger.ApplyMigrationsStart();
                try
                {
                    await _migrationRepository.RunMigration(ct);
                    _logger.ApplyMigrationsSuccess();
                }
                catch (Exception e)
                {
                    _logger.ApplyMigrationsFailed(e);
                }
            }
        }
    }
}
