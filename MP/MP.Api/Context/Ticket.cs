using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MP.Api.Context
{
    public class Ticket : IBaseDateCreationEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key, Column("id"), Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [Column("creation_date"), Required]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Column("title"), MaxLength(512), Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        [Column("description"), MaxLength(4096)]
        public string? Description { get; set; }

        /// <summary>
        /// Дата посещения
        /// </summary>
        [Column("visit_date"), Required]
        public DateTime VisitDate { get; set; }

        /// <summary>
        /// Количество людей
        /// </summary>
        /// <remarks>Поставил ushort, потому что самый большой зал в мире вмещает меньше 65к мест </remarks>
        [Column("visitors_number"), Required]
        public ushort VisitorsNumber { get; set; }
    }
}
