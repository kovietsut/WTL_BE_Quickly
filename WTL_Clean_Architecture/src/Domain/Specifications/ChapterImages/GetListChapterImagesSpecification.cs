using ChapterImageEntity = Domain.Entities.ChapterImage;

namespace Domain.Specifications.ChapterImages
{
    public class GetListChapterImagesSpecification : Specification<ChapterImageEntity, string>
    {
        public GetListChapterImagesSpecification(int? pageNumber, int? pageSize, string? searchText)
            : base(chapterImage => chapterImage.IsDeleted != true &&
                                  (string.IsNullOrEmpty(searchText) || (chapterImage.Name != null && chapterImage.Name.Contains(searchText.Trim()))))
        {
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            //AddOrderByDescending(u => u.CreatedDate);
        }
    }
}
