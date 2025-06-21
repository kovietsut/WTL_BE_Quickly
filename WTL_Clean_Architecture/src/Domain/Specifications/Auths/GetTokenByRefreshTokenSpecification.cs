using Domain.Entities;

namespace Domain.Specifications.Auths
{
    public class GetTokenByRefreshTokenSpecification : Specification<AuthMethod, string>
    {
        public GetTokenByRefreshTokenSpecification(string refreshToken) : 
            base(auth => !string.IsNullOrEmpty(auth.RefreshToken) && auth.RefreshToken.Equals(refreshToken))
        {}
    }
}
