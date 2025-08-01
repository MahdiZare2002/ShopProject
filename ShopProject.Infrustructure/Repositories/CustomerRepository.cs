using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Domain.Entities;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopProjectDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetActiveCustomersAsync()
        {
            return await GetWhereAsync(c => c.IsActive);
        }

        public async Task<Customer> GetCustomersByEmailAsync(string email)
        {
            return await GetFirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
