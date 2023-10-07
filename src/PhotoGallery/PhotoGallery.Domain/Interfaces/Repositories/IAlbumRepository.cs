using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
        Task<IReadOnlyCollection<Album>> GetPagedAlbumsAsync(int pageNumber, int pageSize);
    }
}
