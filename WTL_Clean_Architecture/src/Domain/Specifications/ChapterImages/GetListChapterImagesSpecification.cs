using ChapterImagesEntity = Domain.Entities.ChapterImage;

namespace Domain.Specifications.ChapterImages
{
    public class GetListChapterImagesSpecification : Specification<ChapterImagesEntity, long>
    {
        public GetListChapterImagesSpecification(int? pageNumber, int? pageSize, string? searchText) :
            base(chapterImages => chapterImages.IsDeleted != true &&
            (string.IsNullOrEmpty(searchText) || (chapterImages.Name != null && chapterImages.Name.Contains(searchText.Trim()))))
        {
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            //AddOrderByDescending(u => u.CreatedDate);
        }
    }
}
