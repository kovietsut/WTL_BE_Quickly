using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetUserByPhoneNumberSpecification : Specification<User, string>
    {
        public GetUserByPhoneNumberSpecification(string phoneNumber) : base(user => !string.IsNullOrEmpty(phoneNumber) && user.PhoneNumber == phoneNumber)
        {

        }
    }
}
