using ChapterEntity = Domain.Entities.Chapter;
namespace Domain.Specifications.Chapter
{
    public class GetChapterByIdSpecification : Specification<ChapterEntity, string>
    {
        public GetChapterByIdSpecification(string id) : base(chapter => chapter.Id == id)
        {

        }
    }
}
