using ShopProject.Domain.Entities;

namespace ShopProject.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address?> GetByIdAsync(int id);
        Task<IEnumerable<Address>> GetAllAsync();
        Task<List<Address>> GetAllByCustomerIdAsync(int id);
        Task AddAsync(Address entity);
        void Update(Address entity);
        void Delete(Address entity);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}
