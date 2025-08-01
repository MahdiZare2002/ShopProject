using ShopProject.Domain.Entities;

namespace ShopProject.Application.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomersByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetActiveCustomersAsync();
    }
}
