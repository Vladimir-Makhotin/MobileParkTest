namespace MP.Api.Context
{
    public interface IBaseDateCreationEntity : IBaseEntity
    {
        /// <summary>
        /// Служебное поле дата создания записи
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
