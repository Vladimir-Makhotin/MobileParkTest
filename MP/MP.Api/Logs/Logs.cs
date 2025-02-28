namespace MP.Api.Logs
{
    public static partial class Log
    {
        [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Применение миграций запущено.")]
        public static partial void ApplyMigrationsStart(this ILogger logger);

        [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Применение миграций завершено успешно.")]
        public static partial void ApplyMigrationsSuccess(this ILogger logger);

        [LoggerMessage(EventId = 3, Level = LogLevel.Error, Message = "Во время применения миграций возникло исключение.")]
        public static partial void ApplyMigrationsFailed(this ILogger logger, Exception ex);

        [LoggerMessage(EventId = 4, Level = LogLevel.Error, Message = "Во время получения количества записей {entity} возникло исключение")]
        public static partial void GetEntityCountFailed(this ILogger logger, Exception ex, string entity);

        [LoggerMessage(EventId = 5, Level = LogLevel.Error, Message = "Во время получения записей типа {entity} возникло исключение")]
        public static partial void GetObjectFromDbFailed(this ILogger logger, Exception ex, string entity);

        [LoggerMessage(EventId = 6, Level = LogLevel.Error, Message = "Во время добавления записи типа {entity} возникло исключение")]
        public static partial void AddObjectFromDbFailed(this ILogger logger, Exception ex, string entity);

        [LoggerMessage(EventId = 7, Level = LogLevel.Error, Message = "Во время удаления записи типа {entity} возникло исключение")]
        public static partial void DeleteObjectFromDbFailed(this ILogger logger, Exception ex, string entity);

        [LoggerMessage(EventId = 8, Level = LogLevel.Error, Message = "Во время обновления записи типа {entity} возникло исключение")]
        public static partial void UpdateObjectFromDbFailed(this ILogger logger, Exception ex, string entity);
    }
}
