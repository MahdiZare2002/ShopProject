using Microsoft.EntityFrameworkCore;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ShopProjectDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ShopProjectDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
