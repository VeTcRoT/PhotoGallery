using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Persistence.Data;

namespace PhotoGallery.Persistence.Repositories
{
    public class RateRepository : BaseRepository<Rate>, IRateRepository
    {
        public RateRepository(PhotoGalleryDbContext dbContext) : base(dbContext) { }

        public async Task<Rate?> GetByImageAndUserIdsAsync(int imageId, string userId)
        {
            return await _dbSet.Where(r => r.ImageId == imageId && r.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
