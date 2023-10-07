using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<IReadOnlyCollection<Image>> GetImagesByAlbumIdAndPagedAsync(int albumId, int pageNumber, int pageSize);
        Task<Image> GetByIdWithAlbumAsync(int id);
    }
}
