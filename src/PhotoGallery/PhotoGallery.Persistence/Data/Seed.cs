using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Persistence.Data
{
    public static class Seed
    {
        public async static void SeedAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userStore = serviceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
            var emailStore = (IUserEmailStore<ApplicationUser>)userStore;

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));

                var user = new ApplicationUser();
                user.EmailConfirmed = true;
                await userStore.SetUserNameAsync(user, "admin@gmail.com", CancellationToken.None);
                await emailStore.SetEmailAsync(user, "admin@gmail.com", CancellationToken.None);
                var result = await userManager.CreateAsync(user, "Admin2232622!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }

            }

        }
    }
}
