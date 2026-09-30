using System.ComponentModel.DataAnnotations;

namespace TicketDesk.DTOs
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Text { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;
    }
}