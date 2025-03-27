﻿using Application.Utils;
using Azure.Storage;
using Azure.Storage.Blobs;
using Domain.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Application.Interfaces;
using Azure.Storage.Blobs.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using Application.Models;

namespace Infrastructure.Repositories
{
    public class AzureBlobRepository : IAzureBlobRepository
    {
        private readonly AzureBlobSettings _azureBlobSettings;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly ErrorCode _errorCodes;
        private readonly ISasTokenGenerator _sasTokenGenerator;
        //private readonly IPublishEndpoint _publishEndpoint;

        public AzureBlobRepository(IOptions<AzureBlobSettings> azureBlobSettings, IOptions<ErrorCode> errorCodes, ISasTokenGenerator sasTokenGenerator)
        {
            var accountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_KEY", EnvironmentVariableTarget.User);
            _azureBlobSettings = azureBlobSettings?.Value ?? throw new ArgumentNullException(nameof(azureBlobSettings));
            _errorCodes = errorCodes?.Value ?? throw new ArgumentNullException(nameof(errorCodes));
            var sharedKeyCredential = new StorageSharedKeyCredential(_azureBlobSettings.AccountName, accountKey);
            var blobUri = $"https://{_azureBlobSettings.AccountName}.blob.core.windows.net";
            _blobServiceClient = new BlobServiceClient(new Uri(blobUri), sharedKeyCredential);
            _sasTokenGenerator = sasTokenGenerator ?? throw new ArgumentNullException(nameof(sasTokenGenerator));
        }

        public async Task<IActionResult> GetAttachment(string fileName, string folderName)
        {
            try
            {
                if (string.IsNullOrEmpty(folderName))
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.Notfound, "Folder name is required");
                }
                if (string.IsNullOrEmpty(fileName))
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.Notfound, "File name is required");
                }
                var file = _blobServiceClient.GetBlobContainerClient(folderName).GetBlobClient(fileName);
                if (await file.ExistsAsync())
                {
                    var sasToken = _sasTokenGenerator.GenerateSasToken(fileName, folderName);
                    var blobUriWithSas = new Uri(file.Uri + "?" + sasToken).ToString();
                    var data = await file.OpenReadAsync();
                    var content = await file.DownloadContentAsync();
                    var contentType = content?.Value?.Details?.ContentType;
                    return JsonUtil.Success(new
                    {
                        FilePath = blobUriWithSas,
                        file.Name,
                        ContentType = contentType
                    });
                }
                return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.Notfound, "File does not exist");
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes.Status500.ServerError, e.Message);
            }
        }

        public async Task<IActionResult> GetListAsync(string folderName)
        {
            try
            {
                if (string.IsNullOrEmpty(folderName))
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.Notfound, "Folder name is required");
                }
                var containerClient = _blobServiceClient.GetBlobContainerClient(folderName);
                if (await containerClient.ExistsAsync() != true)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.Notfound, "Folder does not exist");
                }
                var blobs = new List<BlobItemResponse>();
                var uri = _blobServiceClient.Uri.ToString();
                await foreach (var blobItem in containerClient.GetBlobsAsync())
                {
                    var sasToken = _sasTokenGenerator.GenerateSasToken(blobItem.Name, folderName);
                    var blobUriWithSas = new Uri($"{uri}{folderName}/{blobItem.Name}" + "?" + sasToken).ToString();
                    blobs.Add(new BlobItemResponse
                    {
                        FilePath = blobUriWithSas,
                        Name = blobItem.Name,
                        ContentType = blobItem.Properties?.ContentType
                    });
                }
                return JsonUtil.Success(blobs);
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes.Status500.ServerError, e.Message);
            }
        }

        private async Task CompressAsync(IFormFile imageFile, string outputPath, int quality)
        {
            using var imageStream = imageFile.OpenReadStream();
            using var image = Image.Load(imageStream);
            var encoder = new JpegEncoder
            {
                Quality = quality,
            };
            await Task.Run(() => image.Save(outputPath, encoder));
        }

        public async Task<IActionResult> UploadFile(IFormFile attachment, string folderName)
        {
            try
            {
                var quality = 75;
                if (string.IsNullOrEmpty(folderName))
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.BadRequest, "Folder name cannot be null");
                }
                if (attachment == null)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.BadRequest, "Attachment cannot be null");
                }
                // Create temporary file and Compress file
                var tempFilePath = Path.GetTempFileName();
                await CompressAsync(attachment, tempFilePath, quality);
                // Upload file to blob Azure
                var containerClient = _blobServiceClient.GetBlobContainerClient(folderName);
                await containerClient.CreateIfNotExistsAsync();
                string uniqueAttachmentName = Guid.NewGuid().ToString() + "9999a" + attachment.FileName;
                var blobClient = containerClient.GetBlobClient(uniqueAttachmentName);
                var compressedFileStream = File.OpenRead(tempFilePath);
                await blobClient.UploadAsync(compressedFileStream, new BlobHttpHeaders { ContentType = attachment.ContentType });
                // Delete the temporary file
                // File.Delete(tempFilePath);
                //var eventMessage = new AzureAttachmentEvent()
                //{
                //    FilePath = blobClient.Uri.ToString(),
                //    FileName = attachment.FileName,
                //    ContentType = attachment.ContentType
                //};
                //await _publishEndpoint.Publish(eventMessage);
                return JsonUtil.Success(new
                {
                    FilePath = Util.RemoveWhiteSpace(blobClient.Uri.ToString()),
                    FileName = Util.RemoveWhiteSpace(attachment.FileName),
                    attachment.ContentType
                });
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes.Status500.ServerError, e.Message);
            }
        }

        public async Task<IActionResult> UploadListFile(IFormFileCollection attachments, string folderName)
        {
            try
            {
                var quality = 75;
                if (string.IsNullOrEmpty(folderName))
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.BadRequest, "Folder name cannot be null");
                }
                if (attachments == null || !attachments.Any())
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.BadRequest, "Please select at least 1 attachment");
                }
                // Create temporary file and Compress file
                foreach (var attachment in attachments)
                {
                    var tempFilePath = Path.GetTempFileName();
                    await CompressAsync(attachment, tempFilePath, quality);
                    // Upload file to blob Azure
                    var containerClient = _blobServiceClient.GetBlobContainerClient(folderName);
                    await containerClient.CreateIfNotExistsAsync();
                    string uniqueAttachmentName = Guid.NewGuid().ToString() + "9999a" + attachment.FileName;
                    var blobClient = containerClient.GetBlobClient(uniqueAttachmentName);
                    var compressedFileStream = File.OpenRead(tempFilePath);
                    await blobClient.UploadAsync(compressedFileStream, new BlobHttpHeaders { ContentType = attachment.ContentType });
                    // Delete the temporary file
                    // File.Delete(tempFilePath);
                }
                return JsonUtil.Success($"Upload {attachments.Count} Success");
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes.Status500.ServerError, e.Message);
            }
        }

        public async Task<IActionResult> DeleteAsync(string fileName, string folderName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folderName))
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes.Status400.BadRequest, "File name and folder name are required");
                }
                var file = _blobServiceClient.GetBlobContainerClient(folderName).GetBlobClient(fileName);
                await file.DeleteAsync();
                return JsonUtil.Success($"File {fileName} has been deleted");
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes.Status500.ServerError, e.Message);
            }
        }
    }
}
