using Domain.Entities;
using Domain.Enums;

namespace Domain.Specifications.MangaInteractions
{
    public class GetMangaInteractionByUserAndContentSpecification : Specification<MangaInteraction, string>
    {
        public GetMangaInteractionByUserAndContentSpecification(string userId, string? mangaId, string? chapterId, MangaInteractionType? interactionType)
            : base(interaction =>
                interaction.UserId == userId &&
                (mangaId == null || interaction.MangaId == mangaId) &&
                (chapterId == null || interaction.ChapterId == chapterId) &&
                (!interactionType.HasValue || interaction.InteractionType == interactionType))
        {
        }
    }
} 