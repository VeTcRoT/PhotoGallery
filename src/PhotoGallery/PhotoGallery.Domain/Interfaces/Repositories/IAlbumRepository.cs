using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Helpers;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
        Task<PagedList<Album>> GetPagedAlbumsAsync(int pageNumber, int pageSize);
        Task<PagedList<Album>> GetPagedAlbumsByUserIdAsync(string userId, int pageNumber, int pageSize);
        Task<Album?> GetAlbumWithImagesAsync(int id);
    }
}
