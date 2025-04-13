using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CreateUserDto
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string RePassword { get; set; }
        [Required]
        public long RoleId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
    }
}
