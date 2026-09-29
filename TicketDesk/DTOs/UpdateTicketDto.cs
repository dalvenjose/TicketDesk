using System.ComponentModel.DataAnnotations;

namespace TicketDesk.DTOs
{
    public class UpdateTicketDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(Open|InProgress|Closed)$",
            ErrorMessage = "Status must be Open, InProgress, or Closed.")]
        public string Status { get; set; } = "Open";
    }
}