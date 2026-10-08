using TicketDesk.Models;

namespace TicketDesk.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}