using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UserTokenDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
