using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class SignInDto
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
