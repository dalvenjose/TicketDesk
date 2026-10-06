using Microsoft.EntityFrameworkCore;
using TicketDesk.Models;

namespace TicketDesk.Data
{
    public class TicketDeskDbContext : DbContext
    {
        public TicketDeskDbContext(DbContextOptions<TicketDeskDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}