using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CreateGenreDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
