namespace MP.Api.Domain.Interfaces
{
    public interface IMigrationService
    {
        /// <summary>
        /// Асинхронно применяет миграци к текущей базе данных
        /// </summary>
        /// <param name="ct"> Токен отмены операции </param>
        /// <returns></returns>
        Task ApplyDbMigrationsAsync(CancellationToken ct = default);
    }
}
