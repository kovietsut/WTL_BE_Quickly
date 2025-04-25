using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IImageRepository
    {
        Task<string> ConvertImageToBase64Async(IFormFile imageFile);
    }
} 