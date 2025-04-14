using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Specifications.Comments
{
    public class GetListCommentsSpecification : Specification<Comment, long>
    {
        public GetListCommentsSpecification(long? mangaId, long? chapterId, long? parentCommentId, int pageNumber, int pageSize, bool includePaging = true)
            : base(comment => 
                (!mangaId.HasValue || comment.MangaId == mangaId) &&
                (!chapterId.HasValue || comment.ChapterId == chapterId) &&
                (!parentCommentId.HasValue || comment.ParentCommentId == parentCommentId))
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
