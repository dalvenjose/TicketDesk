using TicketDesk.Models;

namespace TicketDesk.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<bool> UpdateAsync(int id, Ticket updatedTicket);
        Task<bool> DeleteAsync(int id);
    }
}