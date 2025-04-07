using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UpdateGenreDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
