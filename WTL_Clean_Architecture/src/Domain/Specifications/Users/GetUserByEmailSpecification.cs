using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetUserByEmailSpecification : Specification<User, long>
    {
        public GetUserByEmailSpecification(string email) : base(user => !string.IsNullOrEmpty(email) && user.Email == email)
        {

        }
    }
}
