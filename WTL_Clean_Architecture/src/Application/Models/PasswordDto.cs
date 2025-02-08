using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class PasswordDto
    {
        [Required]
        public string? CurrentPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
