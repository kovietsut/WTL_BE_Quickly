using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IAzureBlobRepository
    {
        Task<IActionResult> GetAttachment(string fileName, string folderName);
        Task<IActionResult> GetListAsync(string folderName);
        Task<IActionResult> UploadFile(IFormFile attachment, string folderName);
        Task<IActionResult> UploadListFile(IFormFileCollection attachments, string folderName);
        Task<IActionResult> DeleteAsync(string fileName, string folderName);
    }
}
