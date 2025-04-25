using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {

        public async Task<string> ConvertImageToBase64Async(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                throw new ArgumentException("Invalid image file");

            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();

            string base64String = Convert.ToBase64String(imageBytes);
            string contentType = imageFile.ContentType; // e.g., image/png

            return $"data:{contentType};base64,{base64String}";
        }
    }
} 