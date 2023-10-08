using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Application;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Persistence.Data;
using PhotoGallery.Persistence;
using PhotoGallery.Domain.Interfaces.Services;
using PhotoGallery.MVC.Services;
using System.Reflection;

namespace PhotoGallery.MVC
{
    internal static class StartupHelperExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices();

            builder.Services.AddDbContext<PhotoGalleryDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PhotoGalleryDbContext>();

            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });

            return app;
        }
    }
}
