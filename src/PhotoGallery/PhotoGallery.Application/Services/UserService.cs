using Microsoft.AspNetCore.Identity;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> IsAdminAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            return await _userManager.IsInRoleAsync(user, "Admin");
        }
    }
}
