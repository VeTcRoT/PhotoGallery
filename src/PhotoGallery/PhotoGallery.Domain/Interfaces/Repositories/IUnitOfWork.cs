using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; }
        IImageRepository ImageRepository { get; }
        IBaseRepository<TEntity> GetRepository<TEntity>()
            where TEntity : EntityBase;
        Task<int> SaveChangesAsync();
    }
}
