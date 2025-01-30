using Application.Interfaces;
using Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EncryptionRepository(IOptions<AppSetting> appSettings) : IEncryptionRepository
    {
        private readonly AppSetting _appSettings = appSettings.Value;

        private static string CreateSalt(params object[] objs)
        {
            string salt = "@!";

            foreach (var obj in objs)
            {
                salt += obj;
            }

            salt += "!@";

            return salt;
        }

        private static string Encrypt(string value, string salt)
        {
            using var sha256 = SHA256.Create();
            if (sha256 != null)
            {
                var saltedPassword = string.Format("{0}{1}", salt, value);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                Console.WriteLine("sha256.ComputeHas: " + sha256.ComputeHash(saltedPasswordAsBytes));
                Console.WriteLine("ToBase64String: " + Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes)));

                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
            return "";
        }

        public string CreateSalt()
        {
            var data = new byte[0x10];

            var cryptoServiceProvider = RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public string CreateSalt(string value)
        {
            if (_appSettings.Salt != null)
            {

                return CreateSalt(value, _appSettings.Salt);
            }
            return "";
        }

        public string EncryptPassword(string password, string securityStamp)
        {
            return Encrypt(password, CreateSalt([HashSHA256(securityStamp)]));
        }

        public string HashSHA256(string value)
        {
            return String.Concat(SHA256.HashData(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString("x2")));
        }
    }
}
