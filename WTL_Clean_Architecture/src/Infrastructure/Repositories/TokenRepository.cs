using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.Auths;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TokenRepository : RepositoryBase<AuthMethod, long, MyDbContext>, ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _iUserRepository;

        public TokenRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IConfiguration configuration,
            IUserRepository iUserRepository)
            : base(dbContext, unitOfWork)
        {
            _configuration = configuration;
            _iUserRepository = iUserRepository;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration["Jwt:Secret"];
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("JWT Secret is not configured.");
            }
            var secret = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);
            return Convert.ToBase64String(random);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:Lifetime"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );
            return token;
        }

        private async Task<List<Claim>> GetClaims(int userId)
        {
            var currentUser = await _iUserRepository.GetUserById(userId) ?? throw new Exception("User not found");
            var role = currentUser.RoleId;
            var claims = new List<Claim>
            {
                new("id", currentUser.Id.ToString()),
                new("email", currentUser.Email),
                new("role", role.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            };
            return claims;
        }

        public async Task<AuthMethod?> GetTokenByRefreshToken(string refreshToken)
        {
            var query = FindByCondition(x => x.RefreshToken == refreshToken);
            var specification = new GetTokenByRefreshTokenSpecification(refreshToken);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<string> CreateToken(int userId)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(userId);
            var token = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }

        public async Task<TokenDto> GenerateToken(UserTokenDto model)
        {
            var currentUser = await _iUserRepository.GetUserByEmail(model.Email) ?? throw new Exception("User not found");
            var role = currentUser.RoleId;
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:Secret"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret is not configured.");
            }
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"],
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Email, model.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, currentUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", currentUser.Id.ToString()),
                    new Claim("Email", currentUser.Email.ToString()),
                    new Claim("Role", role.ToString()),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            var tokenEntity = new AuthMethod
            {
                IsDeleted = false,
                JwtId = token.Id,
                UserId = model.UserId,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiration = DateTime.Now.AddDays(7),
                RefreshTokenExpiration = DateTime.Now.AddDays(7),
                IsRevoked = false,
            };
            await CreateAsync(tokenEntity);
            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<string> IssueToken(string email)
        {
            var currentUser = await _iUserRepository.GetUserByEmail(email) ?? throw new Exception("User not found");
            var role = currentUser.RoleId;
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:Secret"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret is not configured.");
            }
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"],
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Sub, currentUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", currentUser.Id.ToString()),
                    new Claim("Email", currentUser.Email.ToString()),
                    new Claim("Role", role.ToString()),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            return accessToken;
        }
    }
}
