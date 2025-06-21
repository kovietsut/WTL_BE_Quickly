using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UserTokenDto
    {
        [Required]
        public required string UserId { get; set; }
        [Required]
        public required string Email { get; set; }
    }
}
