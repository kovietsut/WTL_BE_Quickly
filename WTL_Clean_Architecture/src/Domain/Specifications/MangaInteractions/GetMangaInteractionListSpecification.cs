using Domain.Entities;
using Domain.Enums;

namespace Domain.Specifications.MangaInteractions
{
    public class GetMangaInteractionListSpecification : Specification<MangaInteraction, long>
    {
        public GetMangaInteractionListSpecification(long userId, long? mangaId, long? chapterId, MangaInteractionType? interactionType, int? pageNumber, int? pageSize)
            : base(interaction =>
                interaction.UserId == userId &&
                (!mangaId.HasValue || interaction.MangaId == mangaId) &&
                (!chapterId.HasValue || interaction.ChapterId == chapterId) &&
                (!interactionType.HasValue || interaction.InteractionType == interactionType))
        {
            
            // Apply pagination if provided
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                ApplyPaging((pageNumber.Value - 1) * pageSize.Value, pageSize.Value);
            }
            
            // Order by ID descending
            AddOrderByDescending(i => i.Id);
            
            // Use split query for better performance
            IsSplitQuery = true;
        }
    }
}
