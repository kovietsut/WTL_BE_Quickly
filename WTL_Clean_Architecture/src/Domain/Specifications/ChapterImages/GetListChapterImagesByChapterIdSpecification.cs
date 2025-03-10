using ChapterImagesEntity = Domain.Entities.ChapterImage;

namespace Domain.Specifications.ChapterImages
{
    public class GetListChapterImagesByChapterIdSpecification : Specification<ChapterImagesEntity, long>
    {
        public GetListChapterImagesByChapterIdSpecification(long chapterId) :
            base(chapterImages => chapterImages.IsDeleted != true &&
            chapterImages.ChapterId == chapterId)
        {
            //ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            //AddOrderByDescending(u => u.CreatedDate);
        }
    }
}
