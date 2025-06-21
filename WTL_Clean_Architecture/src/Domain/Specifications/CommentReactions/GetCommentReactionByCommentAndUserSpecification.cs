using Domain.Entities;

namespace Domain.Specifications.CommentReactions
{
    public class GetCommentReactionByCommentAndUserSpecification : Specification<CommentReaction, string>
    {
        public GetCommentReactionByCommentAndUserSpecification(string commentId, string userId) : base(reaction => 
            reaction.CommentId == commentId && 
            reaction.UserId == userId)
        {
            // Include related entities
            AddInclude(r => r.Comment);
            AddInclude(r => r.User);
        }
    }
} 