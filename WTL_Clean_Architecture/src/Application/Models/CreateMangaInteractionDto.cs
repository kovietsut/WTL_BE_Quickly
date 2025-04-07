using Domain.Enums;

namespace Application.Models
{
    public class CreateMangaInteractionDto
    {
        public long? MangaId { get; set; }

        public long? ChapterId { get; set; }

        public MangaInteractionType? InteractionType { get; set; }
    }
}
