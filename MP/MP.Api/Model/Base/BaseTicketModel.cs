namespace MP.Api.Model.Base
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public class BaseTicketModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата посещения
        /// </summary>
        public required DateTime VisitDate { get; set; }

        /// <summary>
        /// Количество людей
        /// </summary>
        public required ushort VisitorsNumber { get; set; }
    }
}
