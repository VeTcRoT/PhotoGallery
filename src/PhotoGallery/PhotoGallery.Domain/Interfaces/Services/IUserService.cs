namespace PhotoGallery.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> IsAdminAsync(string userId);
    }
}
