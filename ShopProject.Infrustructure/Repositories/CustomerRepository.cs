using ShopProject.Domain.Entities;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopProjectDbContext _context;
        public CustomerRepository(ShopProjectDbContext context)
        {
            _context = context;
        }
    }
}
