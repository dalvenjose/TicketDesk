using Microsoft.EntityFrameworkCore;
using TicketDesk.Data;
using TicketDesk.Models;

namespace TicketDesk.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDeskDbContext _context;

        public TicketRepository(TicketDeskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets
                .Include(t => t.Comments)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Comment?> AddCommentAsync(int ticketId, Comment comment)
        {
            var exists = await _context.Tickets.AnyAsync(t => t.Id == ticketId);
            if (!exists) return null;

            comment.TicketId = ticketId;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> UpdateAsync(int id, Ticket updatedTicket)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;

            ticket.Title = updatedTicket.Title;
            ticket.Description = updatedTicket.Description;
            ticket.Status = updatedTicket.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}