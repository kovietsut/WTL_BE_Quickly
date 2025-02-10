using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class PasswordDto
    {
        [Required]
        public required string CurrentPassword { get; set; }
        [Required]
        public required string NewPassword { get; set; }
        [Required]
        public required string ConfirmPassword { get; set; }
    }
}
