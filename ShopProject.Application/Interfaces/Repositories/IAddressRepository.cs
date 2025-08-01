using ShopProject.Domain.Entities;

namespace ShopProject.Application.Interfaces.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetAllByCustomerIdAsync(int id);
    }
}
