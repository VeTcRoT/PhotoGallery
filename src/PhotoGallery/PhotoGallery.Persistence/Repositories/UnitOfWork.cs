using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Persistence.Data;

namespace PhotoGallery.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAlbumRepository AlbumRepository { get; }

        public IImageRepository ImageRepository { get; }

        public IRateRepository RateRepository { get; }

        private readonly PhotoGalleryDbContext _dbContext;

        public UnitOfWork(
            IAlbumRepository albumRepository, 
            IImageRepository imageRepository, 
            IRateRepository rateRepository, 
            PhotoGalleryDbContext dbContext)
        {
            AlbumRepository = albumRepository;
            ImageRepository = imageRepository;
            RateRepository = rateRepository;
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
