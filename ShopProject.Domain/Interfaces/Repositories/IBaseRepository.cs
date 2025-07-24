namespace ShopProject.Domain.Interfaces.Repositories
{
    internal interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> ExistsAsync(TKey id);
        Task SaveChangesAsync();
    }
}
