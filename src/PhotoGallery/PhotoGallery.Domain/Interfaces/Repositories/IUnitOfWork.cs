using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; }
        IImageRepository ImageRepository { get; }
        IRateRepository RateRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
