using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Helpers;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Persistence.Data;

namespace PhotoGallery.Persistence.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(PhotoGalleryDbContext dbContext) : base(dbContext) { }

        public async Task<Image?> GetByIdWithAlbumAsync(int id)
        {
            return await _dbSet.Include(i => i.Album).Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Image>> GetImagesByAlbumIdAndPagedAsync(int albumId, int pageNumber, int pageSize)
        {
            return await PagedList<Image>.CreateAsync(_dbSet.Include(i => i.Rate)
                .Where(i => i.AlbumId == albumId), pageNumber, pageSize);
        }
    }
}
