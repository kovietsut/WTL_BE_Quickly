using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class TokenDto
    {
        [Required]
        public required string AccessToken { get; set; }
        [Required]
        public required string RefreshToken { get; set; }
    }
}
