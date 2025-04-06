using Domain.Entities;

namespace Domain.Specifications.MangaInteractions
{
    public class GetMangaInteractionByUserAndContentSpecification : Specification<MangaInteraction, long>
    {
        public GetMangaInteractionByUserAndContentSpecification(long userId, long? mangaId, long? chapterId) 
            : base(interaction => 
                interaction.UserId == userId &&
                (!mangaId.HasValue || interaction.MangaId == mangaId) &&
                (!chapterId.HasValue || interaction.ChapterId == chapterId))
        {
        }
    }
} 