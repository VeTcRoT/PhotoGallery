using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.Application.Services;
using PhotoGallery.Domain.Interfaces.Services;
using System.Reflection;

namespace PhotoGallery.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
