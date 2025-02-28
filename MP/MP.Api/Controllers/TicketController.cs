using Microsoft.AspNetCore.Mvc;
using MP.Api.Context;
using MP.Api.Domain.Interfaces;
using MP.Api.Model.Requests;
using MP.Api.Model.Responces;

namespace MP.Api.Controllers
{
    /// <summary>
    /// Контролле для работы с билетаим
    /// </summary>
    /// <param name="_service"></param>
    [Route("ticket")]
    [ApiController]
    public class TicketController(ITicketService _service) : ControllerBase
    {
        /// <summary>
        /// Получить все билеты
        /// </summary>
        /// <returns>Список всех билетов</returns>
        [HttpGet("all")]
        public async Task<ActionResult<TicketViewModel>> GetAllTickets()
        {
            try
            {
                var token = HttpContext.RequestAborted;
                var res = await _service.GetTickets(token);

                if (res is null || res.Count == 0)
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Добавить билет
        /// </summary>
        /// <param name="ticket">Билет</param>
        /// <returns>Идентификатор добавленного билета</returns>
        [HttpPost("add")]
        public async Task<ActionResult> AddTicket([FromBody] TicketUpsertModel ticket)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (ticket.Id is not null || ticket.Id == Guid.Empty)
                    return BadRequest("Недопустимая операция для существующей записи");

                var token = HttpContext.RequestAborted;
                var res = await _service.AddTicket(ticket, token);

                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Получить билеты по периоду
        /// </summary>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <returns>Спиоск билетов</returns>
        [HttpGet("by-period")]
        public async Task<ActionResult<List<Ticket>>> GetTicketByPeriod([FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var token = HttpContext.RequestAborted;
                TimeZoneInfo timeZone = (TimeZoneInfo)HttpContext.Items["Time-Zone"];

                DateTime startDateUtc = TimeZoneInfo.ConvertTimeToUtc(startDate, timeZone);
                DateTime endDateUtc = TimeZoneInfo.ConvertTimeToUtc(endDate, timeZone);

                var res = await _service.GetTicketsByPeriod(startDateUtc, endDateUtc, token);

                if (res is null || res.Any())
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
