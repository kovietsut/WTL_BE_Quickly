using Domain.Entities;

namespace Domain.Specifications.Comments
{
    public class GetCommentByIdSpecification : Specification<Comment, string>
    {
        public GetCommentByIdSpecification(string id) : base(comment => 
            comment.Id == id && !comment.IsDeleted)
        {
            // Include related entities
            AddInclude(c => c.ParentComment);
            AddInclude(c => c.InverseParentComment);
            AddInclude(c => c.CommentReactions);
            AddInclude(c => c.Manga);
            AddInclude(c => c.Chapter);

            // Use split query for better performance with multiple includes
            IsSplitQuery = true;
        }
    }
}
