using Domain.Enums;

namespace Application.Models
{
    public class CreateMangaInteractionDto
    {
        public string? MangaId { get; set; }

        public string? ChapterId { get; set; }

        public MangaInteractionType? InteractionType { get; set; }
    }
}
