using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CreateUserDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public long RoleId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
    }
}
