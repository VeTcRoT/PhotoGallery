using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Helpers;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Persistence.Data;

namespace PhotoGallery.Persistence.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(PhotoGalleryDbContext dbContext) : base(dbContext) { }

        public async Task<Album?> GetAlbumWithImagesAsync(int id)
        {
            return await _dbSet.Include(a => a.Images)
                .Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Album>> GetPagedAlbumsAsync(int pageNumber, int pageSize)
        {
            return await PagedList<Album>.CreateAsync(_dbSet, pageNumber, pageSize);
        }

        public async Task<PagedList<Album>> GetPagedAlbumsByUserIdAsync(string userId, int pageNumber, int pageSize)
        {
            return await PagedList<Album>.CreateAsync(_dbSet.Where(a => a.UserId == userId), pageNumber, pageSize);
        }
    }
}
