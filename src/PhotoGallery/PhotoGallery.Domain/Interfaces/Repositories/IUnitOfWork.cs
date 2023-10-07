using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> GetRepository<TEntity>()
            where TEntity : EntityBase;
        Task<int> SaveChangesAsync();
    }
}
