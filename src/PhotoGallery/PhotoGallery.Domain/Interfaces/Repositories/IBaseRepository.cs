using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
        where T : EntityBase
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyCollection<T>> ListAllAsync();
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
