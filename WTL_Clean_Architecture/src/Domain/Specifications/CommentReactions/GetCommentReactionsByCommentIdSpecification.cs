using Domain.Entities;

namespace Domain.Specifications.CommentReactions
{
    public class GetCommentReactionsByCommentIdSpecification : Specification<CommentReaction, long>
    {
        public GetCommentReactionsByCommentIdSpecification(long commentId, int? pageNumber = null, int? pageSize = null) : base(reaction => 
            reaction.CommentId == commentId)
        {
            // Apply pagination if provided
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                ApplyPaging((pageNumber.Value - 1) * pageSize.Value, pageSize.Value);
            }
            
            // Order by creation date descending (newest first)
            AddOrderByDescending(r => r.CreatedAt);
            
            // Include related entities
            AddInclude(r => r.User);
            AddInclude(r => r.Comment);
            
            // Use split query for better performance
            IsSplitQuery = true;
        }
    }
} 