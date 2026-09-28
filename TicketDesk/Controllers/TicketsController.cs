using Microsoft.AspNetCore.Mvc;
using TicketDesk.Models;
using TicketDesk.Repositories;

namespace TicketDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _repository;

        public TicketsController(ITicketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Create(Ticket newTicket)
        {
            var created = await _repository.CreateAsync(newTicket);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ticket updatedTicket)
        {
            var success = await _repository.UpdateAsync(id, updatedTicket);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}