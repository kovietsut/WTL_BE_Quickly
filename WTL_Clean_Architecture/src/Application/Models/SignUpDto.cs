using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class SignUpDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
