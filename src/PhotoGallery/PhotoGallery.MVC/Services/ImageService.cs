using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.MVC.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string path = "uploads";

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;

            var rootImagesPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(rootImagesPath))
                Directory.CreateDirectory(rootImagesPath);

            var filePath = Path.Combine(rootImagesPath, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return Path.Combine(path, uniqueFileName);
        }

        public void DeleteImage(string imagePath)
        {
            var image = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

            if (File.Exists(image))
            {
                File.Delete(image);
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
