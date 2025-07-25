using ShopProject.Domain.Entities;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        private readonly ShopProjectDbContext _context;
        public AddressRepository(ShopProjectDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
