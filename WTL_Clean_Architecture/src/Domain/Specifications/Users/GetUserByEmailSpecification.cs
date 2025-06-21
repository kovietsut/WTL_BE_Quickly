using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetUserByEmailSpecification : Specification<User, string>
    {
        public GetUserByEmailSpecification(string email) : base(user => !string.IsNullOrEmpty(email) && user.Email == email)
        {

        }
    }
}
