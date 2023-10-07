using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Persistence.Repositories;

namespace PhotoGallery.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
