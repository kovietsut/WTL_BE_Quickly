using ChapterEntity = Domain.Entities.Chapter;

namespace Domain.Specifications.Chapter
{
    public class GetListChaptersSpecification : Specification<ChapterEntity, long>
    {
        public GetListChaptersSpecification(int? pageNumber, int? pageSize, string? searchText) :
            base(chapter => chapter.IsDeleted != true &&
            (string.IsNullOrEmpty(searchText) || (chapter.Name != null && chapter.Name.Contains(searchText.Trim()))))
        {
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            AddOrderByDescending(u => u.CreatedAt);
        }
    }
}
