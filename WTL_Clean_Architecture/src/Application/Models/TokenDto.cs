using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class TokenDto
    {
        [Required]
        public string? AccessToken { get; set; }
        [Required]
        public string? RefreshToken { get; set; }
    }
}
