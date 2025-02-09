using Domain.Entities;

namespace Domain.Specifications.Users
{
    public class GetListUsersSpecification : Specification<User, long>
    {
        public GetListUsersSpecification(int? pageNumber, int? pageSize, string? searchText, int? roleId):
            base(user => user.IsDeleted == true && (user.RoleId == roleId || roleId == null) &&
            (string.IsNullOrEmpty(searchText) || user.FullName.Contains(searchText.Trim()) || user.PhoneNumber.Contains(searchText.Trim())
                || user.Address.Contains(searchText.Trim()) || user.Email.Contains(searchText.Trim())))
        {
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            AddOrderByDescending(u => u.CreatedAt);
        }
    }
}
