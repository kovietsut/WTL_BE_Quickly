namespace Application.Interfaces
{
    public interface IEncryptionRepository
    {
        string CreateSalt();
        string CreateSalt(string code);
        string EncryptPassword(string password, string securityStamp);
        string HashSHA256(string value);
    }
}
