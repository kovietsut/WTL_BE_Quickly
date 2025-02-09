using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetUserByPhoneNumberSpecification : Specification<User, long>
    {
        public GetUserByPhoneNumberSpecification(string phoneNumber) : base(user => !string.IsNullOrEmpty(phoneNumber) && user.PhoneNumber == phoneNumber)
        {

        }
    }
}
