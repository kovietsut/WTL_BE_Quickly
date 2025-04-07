namespace Application.Interfaces
{
    public interface ISasTokenGenerator
    {
        string GenerateSasToken(string fileName, string folderName);
        string GenerateCoverImageUriWithSas(string coverImageUrl);
    }
}
