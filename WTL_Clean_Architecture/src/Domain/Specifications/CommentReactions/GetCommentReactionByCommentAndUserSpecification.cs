using Domain.Entities;

namespace Domain.Specifications.CommentReactions
{
    public class GetCommentReactionByCommentAndUserSpecification : Specification<CommentReaction, long>
    {
        public GetCommentReactionByCommentAndUserSpecification(long commentId, long userId) : base(reaction => 
            reaction.CommentId == commentId && 
            reaction.UserId == userId)
        {
            // Include related entities
            AddInclude(r => r.Comment);
            AddInclude(r => r.User);
        }
    }
} 