using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetUserByIdSpecification : Specification<User, string>
    {
        public GetUserByIdSpecification(string id) : base(user => user.Id == id)
        {
                
        }
    }
}
