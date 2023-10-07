using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; }
        IBaseRepository<TEntity> GetRepository<TEntity>()
            where TEntity : EntityBase;
        Task<int> SaveChangesAsync();
    }
}
