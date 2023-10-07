using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IRateRepository : IBaseRepository<Rate>
    {
        Task<Rate?> GetByImageAndUserIdsAsync(int imageId, string userId);
    }
}
