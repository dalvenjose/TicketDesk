using Microsoft.AspNetCore.Mvc;
using TicketDesk.DTOs;
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

        private static TicketDto ToDto(Ticket t) => new()
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Status = t.Status,
            CreatedAt = t.CreatedAt,
            Comments = t.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Text = c.Text,
                Author = c.Author,
                CreatedAt = c.CreatedAt
            }).ToList()
        };

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetAll()
        {
            var tickets = await _repository.GetAllAsync();
            return Ok(tickets.Select(ToDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetById(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ToDto(ticket));
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> Create(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                Title = dto.Title,
                Description = dto.Description
            };

            var created = await _repository.CreateAsync(ticket);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, ToDto(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTicketDto dto)
        {
            var updated = new Ticket
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status
            };

            var success = await _repository.UpdateAsync(id, updated);
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

        [HttpPost("{ticketId}/comments")]
        public async Task<ActionResult<CommentDto>> AddComment(int ticketId, CreateCommentDto dto)
        {
            var comment = new Comment { Text = dto.Text, Author = dto.Author };
            var created = await _repository.AddCommentAsync(ticketId, comment);
            if (created == null) return NotFound();

            return Ok(new CommentDto
            {
                Id = created.Id,
                Text = created.Text,
                Author = created.Author,
                CreatedAt = created.CreatedAt
            });
        }
    }
}