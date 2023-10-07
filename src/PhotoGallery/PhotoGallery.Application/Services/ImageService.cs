using Microsoft.AspNetCore.Http;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Application.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("Invalid image file");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;

            var filePath = Path.Combine(GetUploadsPath(), uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return filePath;
        }

        private string GetUploadsPath()
        {
            var uploadsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            return uploadsPath;
        }

        public void DeleteImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public void DeleteImages(IEnumerable<string> imagePaths)
        {
            foreach (string imagePath in imagePaths)
            {
                DeleteImage(imagePath);
            }
        }
    }
}
