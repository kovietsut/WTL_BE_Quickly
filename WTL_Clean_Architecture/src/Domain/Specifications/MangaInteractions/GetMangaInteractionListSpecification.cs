using Domain.Entities;
using Domain.Enums;

namespace Domain.Specifications.MangaInteractions
{
    public class GetMangaInteractionListSpecification : Specification<MangaInteraction, string>
    {
        public GetMangaInteractionListSpecification(string userId, string? mangaId, string? chapterId, MangaInteractionType? interactionType, int? pageNumber, int? pageSize)
            : base(interaction =>
                interaction.UserId == userId &&
                (mangaId == null || interaction.MangaId == mangaId) &&
                (chapterId == null || interaction.ChapterId == chapterId) &&
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
