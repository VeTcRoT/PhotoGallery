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

        public async Task<bool> IsAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.IsInRoleAsync(user, "Admin");
        }

        public async Task<bool> UserExists(string userId)
        {
            return await _userManager.FindByIdAsync(userId) != null;
        }
    }
}
