using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Application.Interfaces.UnitOfWork;
using ShopProject.Infrustructure.Context;
using ShopProject.Infrustructure.Repositories;
using System.Collections.Concurrent;

namespace ShopProject.Infrustructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopProjectDbContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        public UnitOfWork(ShopProjectDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<Type, object>();
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T),
                type => new GenericRepository<T>(_context));
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
