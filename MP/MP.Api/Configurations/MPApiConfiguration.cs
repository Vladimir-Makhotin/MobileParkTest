namespace MP.Api.Configurations
{
    /// <summary>
    /// Конфиг
    /// </summary>
    public record MPApiConfiguration
    {
        /// <summary>
        /// Подключение
        /// </summary>
        public string DefaultConnection { get; set; } = string.Empty;
    }
}
