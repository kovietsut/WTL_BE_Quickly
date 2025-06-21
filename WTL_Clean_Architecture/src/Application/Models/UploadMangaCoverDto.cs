using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UploadMangaCoverDto
    {
        [Required]
        public required string MangaId { get; set; }

        [Required]
        public required IFormFile CoverImageFile { get; set; }
    }
} 