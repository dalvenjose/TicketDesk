using System.ComponentModel.DataAnnotations;

namespace TicketDesk.DTOs
{
    public class CreateTicketDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
    }
}