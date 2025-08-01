using ShopProject.Domain.Entities;
using ShopProject.Application.Interfaces.Repositories;


namespace ShopProject.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        public IOrderRepository Orders { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
