using ChapterImageEntity = Domain.Entities.ChapterImage;

namespace Domain.Specifications.ChapterImages
{
    public class GetListChapterImagesByChapterIdSpecification : Specification<ChapterImageEntity, string>
    {
        public GetListChapterImagesByChapterIdSpecification(string chapterId) : base(chapterImage => chapterImage.ChapterId == chapterId)
        {
            //ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            //AddOrderByDescending(u => u.CreatedDate);
        }
    }
}
