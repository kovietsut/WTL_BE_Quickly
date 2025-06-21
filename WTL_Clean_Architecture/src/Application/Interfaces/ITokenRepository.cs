using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITokenRepository : IRepositoryBase<AuthMethod, string>
    {
        Task<AuthMethod?> GetTokenByRefreshToken(string refreshToken);
        // Làm basic
        Task<string> CreateToken(string userId);
        Task<string> IssueToken(string email);
        // Làm xịn hơn
        Task<TokenDto> GenerateToken(UserTokenDto model);
        DateTime ConvertUnixTimeToDateTime(string utcExpireDate);
    }
}
