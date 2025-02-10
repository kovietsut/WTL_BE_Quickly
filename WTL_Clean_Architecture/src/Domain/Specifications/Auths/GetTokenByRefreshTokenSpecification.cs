using Domain.Entities;

namespace Domain.Specifications.Auths
{
    public class GetTokenByRefreshTokenSpecification : Specification<AuthMethod, long>
    {
        public GetTokenByRefreshTokenSpecification(string refreshToken) : 
            base(auth => !string.IsNullOrEmpty(auth.RefreshToken) && auth.RefreshToken.Equals(refreshToken))
        {}
    }
}
