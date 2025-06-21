using Domain.Entities;

namespace Domain.Specifications.FeaturedCollections
{
    public class GetListFeaturedCollectionsSpecification : Specification<FeaturedCollection, string>
    {
        public GetListFeaturedCollectionsSpecification(int? pageNumber, int? pageSize, string? searchText, string currentUserId)
            : base(collection => 
                collection.IsDeleted != true &&
                collection.CreatedBy == currentUserId &&
                (string.IsNullOrEmpty(searchText) || (collection.Name != null && collection.Name.Contains(searchText.Trim()))))
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                ApplyPaging((pageNumber.Value - 1) * pageSize.Value, pageSize.Value);
                AddOrderByDescending(u => u.Id);
            }
        }
    }
}
