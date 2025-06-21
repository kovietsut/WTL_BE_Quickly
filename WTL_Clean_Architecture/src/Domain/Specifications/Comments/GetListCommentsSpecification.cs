using Domain.Entities;

namespace Domain.Specifications.Comments
{
    public class GetListCommentsSpecification : Specification<Comment, string>
    {
        public GetListCommentsSpecification(string? mangaId, string? chapterId, string? parentCommentId, int pageNumber, int pageSize, bool includePaging = true)
            : base(comment => 
                (string.IsNullOrEmpty(mangaId) || comment.MangaId == mangaId) &&
                (string.IsNullOrEmpty(chapterId) || comment.ChapterId == chapterId) &&
                (string.IsNullOrEmpty(parentCommentId) || comment.ParentCommentId == parentCommentId))
        {
            if (includePaging)
            {
                ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            }
            
            // Order by creation date descending (newest first)
            AddOrderByDescending(c => c.CreatedAt);
            
            // Include related entities
            AddInclude(c => c.ParentComment);
            AddInclude(c => c.InverseParentComment);
            AddInclude(c => c.CommentReactions);
            
            // Use split query for better performance with multiple includes
            IsSplitQuery = true;
        }
    }
}
