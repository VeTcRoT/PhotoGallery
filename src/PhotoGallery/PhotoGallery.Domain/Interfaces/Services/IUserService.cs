namespace PhotoGallery.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> UserExists(string userId);
        Task<bool> IsAdmin(string userId);
    }
}
