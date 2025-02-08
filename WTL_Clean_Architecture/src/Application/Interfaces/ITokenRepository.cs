using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITokenRepository : IRepositoryBase<AuthMethod, long>
    {
        Task<AuthMethod> GetTokenByRefreshToken(string refreshToken);
        // Làm basic
        Task<string> CreateToken(int userId);
        Task<string> IssueToken(string email);
        // Làm xịn hơn
        Task<TokenDto> GenerateToken(UserTokenDto model);
        DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
    }
}
