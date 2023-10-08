using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
        Task<IReadOnlyCollection<Album>> GetPagedAlbumsAsync(int pageNumber, int pageSize);
        Task<IReadOnlyCollection<Album>> GetPagedAlbumsByUserIdAsync(string userId, int pageNumber, int pageSize);
        Task<Album?> GetAlbumWithImagesAsync(int id);
    }
}
