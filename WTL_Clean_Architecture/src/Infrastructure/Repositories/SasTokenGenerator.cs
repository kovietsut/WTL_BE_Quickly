using Application.Interfaces;
using Application.Utils;
using Azure.Storage;
using Azure.Storage.Sas;
using Domain.Configurations;
using Microsoft.Extensions.Options;


namespace Infrastructure.Repositories
{
    public class SasTokenGenerator : ISasTokenGenerator
    {
        private readonly AzureBlobSettings _azureBlobSettings;
        public SasTokenGenerator(IOptions<AzureBlobSettings> azureBlobSettings)
        {
            _azureBlobSettings = azureBlobSettings.Value;
        }

        public string GenerateSasToken(string fileName, string folderName)
        {
            var startTime = DateTimeOffset.UtcNow;
            var expiryTime = DateTimeOffset.UtcNow.AddMinutes(30);
            // Generate the SAS token
            var sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = folderName,
                BlobName = fileName,
                Resource = "b", // "b" indicates a blob-level SAS
                StartsOn = startTime,
                ExpiresOn = expiryTime,
            };
            sasBuilder.SetPermissions(BlobSasPermissions.Read);
            var accountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_KEY", EnvironmentVariableTarget.User);
            var sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(_azureBlobSettings.AccountName,
            accountKey)).ToString();
            return sasToken;
        }

        public string GenerateCoverImageUriWithSas(string coverImageUrl)
        {
            if (string.IsNullOrEmpty(coverImageUrl)) return null;
            var (folderName, fileName) = Util.ExtractNamesFromUrl(coverImageUrl);
            var sasToken = GenerateSasToken(fileName, folderName);
            var blobUriWithSas = new Uri(coverImageUrl + "?" + sasToken).ToString();
            return blobUriWithSas;
        }
    }
}
