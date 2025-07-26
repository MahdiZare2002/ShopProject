using ShopProject.Domain.Entities;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopProjectDbContext _context;
        public OrderRepository(ShopProjectDbContext context)
        {
            _context = context;
        }
    }
}
