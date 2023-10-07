using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Persistence.Data;

namespace PhotoGallery.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : EntityBase
    {

        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(PhotoGalleryDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.Entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);  
        }

        public async Task<IReadOnlyCollection<TEntity>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
