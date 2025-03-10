using ChapterEntity = Domain.Entities.Chapter;
namespace Domain.Specifications.Chapter
{
    public class GetChapterByIdSpecification : Specification<ChapterEntity, long>
    {
        public GetChapterByIdSpecification(long id) : base(chapter => chapter.Id == id)
        {

        }
    }
}
