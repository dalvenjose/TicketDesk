using Microsoft.AspNetCore.Mvc;
using TicketDesk.Models;

namespace TicketDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private static readonly List<Ticket> _tickets = new()
        {
            new Ticket { Id = 1, Title = "Printer not working", Description = "Office printer jams every time", Status = "Open" },
            new Ticket { Id = 2, Title = "Can't reset password", Description = "Reset link expired", Status = "Open" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetAll()
        {
            return Ok(_tickets);
        }
    }
}