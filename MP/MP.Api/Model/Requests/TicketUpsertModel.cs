using MP.Api.Model.Base;

namespace MP.Api.Model.Requests
{
    public class TicketUpsertModel : BaseTicketModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <remarks>Id = null - insert, else update</remarks>
        public Guid? Id { get; set; }
    }
}
