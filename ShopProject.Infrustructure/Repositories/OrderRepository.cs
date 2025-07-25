using ShopProject.Domain.Entities;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        private readonly ShopProjectDbContext _context;
        public OrderRepository(ShopProjectDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
