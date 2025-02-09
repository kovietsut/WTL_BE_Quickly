using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetUserByIdSpecification : Specification<User, long>
    {
        public GetUserByIdSpecification(long id) : base(user => user.Id == id)
        {
                
        }
    }
}
