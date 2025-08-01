using Microsoft.EntityFrameworkCore;
using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Domain.Entities;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class AddressRepository : GenericRepository<Address> , IAddressRepository
    {
        public AddressRepository(ShopProjectDbContext context) : base(context) { }

        public async Task<IEnumerable<Address>> GetAllByCustomerIdAsync(int id)
        {
            return await GetWhereAsync(a => a.CustomerId == id);
        }
    }
}
