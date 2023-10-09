using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Helpers;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<PagedList<Image>> GetImagesByAlbumIdAndPagedAsync(int albumId, int pageNumber, int pageSize);
        Task<Image?> GetByIdWithAlbumAsync(int id);
    }
}
