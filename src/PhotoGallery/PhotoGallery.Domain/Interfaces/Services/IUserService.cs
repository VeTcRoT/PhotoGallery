using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> IsAdminAsync(string userId);
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
    }
}
