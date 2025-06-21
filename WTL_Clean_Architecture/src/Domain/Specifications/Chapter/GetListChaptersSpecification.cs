using ChapterEntity = Domain.Entities.Chapter;

namespace Domain.Specifications.Chapter
{
    public class GetListChaptersSpecification : Specification<ChapterEntity, string>
    {
        public GetListChaptersSpecification(int? pageNumber, int? pageSize, string? searchText)
            : base(chapter => chapter.IsDeleted != true &&
                              (string.IsNullOrEmpty(searchText) || (chapter.Name != null && chapter.Name.Contains(searchText.Trim()))))
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                ApplyPaging((pageNumber.Value - 1) * pageSize.Value, pageSize.Value);
                AddOrderByDescending(u => u.Id);

                IsSplitQuery = true;
            }
        }
    }
}
