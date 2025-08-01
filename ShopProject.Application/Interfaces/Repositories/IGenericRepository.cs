using System.Linq.Expressions;

namespace ShopProject.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWhereWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        // Pagination support
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null);

        // Count operations
        Task<int> CountAsync();
        Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        // Command operations (for CQRS Write side)
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task DeleteByIdAsync(int id);

        // Raw queries (when needed)
        IQueryable<T> GetQueryable();
        Task<IEnumerable<T>> FromSqlRawAsync(string sql, params object[] parameters);
    }
}
