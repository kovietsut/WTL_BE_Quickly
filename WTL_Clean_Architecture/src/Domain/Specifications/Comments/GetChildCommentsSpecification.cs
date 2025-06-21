using Domain.Entities;

namespace Domain.Specifications.Comments
{
    public class GetChildCommentsSpecification : Specification<Comment, string>
    {
        public GetChildCommentsSpecification(string parentCommentId) : base(comment => 
            comment.ParentCommentId == parentCommentId && !comment.IsDeleted)
        {
            // Include related entities
            AddInclude(c => c.ParentComment);
            AddInclude(c => c.CommentReactions);
            AddInclude(c => c.Manga);
            AddInclude(c => c.Chapter);

            // Use split query for better performance with multiple includes
            IsSplitQuery = true;
        }
    }
} 