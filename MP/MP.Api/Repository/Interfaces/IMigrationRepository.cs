namespace MP.Api.Repository.Interfaces
{
    /// <summary>
    /// Репозиторий запуска миграций
    /// </summary>
    public interface IMigrationRepository
    {
        /// <summary>
        /// Запуск миграции
        /// </summary>
        /// <param name="token">Токен отмены операции</param>
        /// <returns></returns>
        Task RunMigration(CancellationToken token = default);

        /// <summary>
        /// Асинхронно возвращает <see langword="True"/>, если есть миграции, не примененные к целевой базе данных
        /// </summary>
        /// <param name="ct"> Токен отмены операции </param>
        /// <returns></returns>
        Task<bool> HasPendingMigrationsAsync(CancellationToken ct = default);
    }
}
