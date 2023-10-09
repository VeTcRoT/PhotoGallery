using Microsoft.AspNetCore.Http;

namespace PhotoGallery.Domain.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile image);
        void DeleteImage(string imagePath);
        void DeleteImages(IEnumerable<string> imagePaths);
    }
}
