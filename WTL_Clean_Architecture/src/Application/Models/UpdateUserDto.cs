using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UpdateUserDto
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string RoleId { get; set; }
        public string? FullName { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
    }
}
