using Domain.Entities;
using Domain.Enums;

namespace Domain.Specifications.MangaInteractions
{
    public class GetMangaInteractionByUserAndContentSpecification : Specification<MangaInteraction, long>
    {
        public GetMangaInteractionByUserAndContentSpecification(long userId, long? mangaId, long? chapterId, MangaInteractionType? interactionType) 
            : base(interaction => 
                interaction.UserId == userId &&
                (!mangaId.HasValue || interaction.MangaId == mangaId) &&
                (!chapterId.HasValue || interaction.ChapterId == chapterId) &&
                (!interactionType.HasValue || interaction.InteractionType == interactionType))
        {
        }
    }
} 