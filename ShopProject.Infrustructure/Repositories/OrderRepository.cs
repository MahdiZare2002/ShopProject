using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Domain.Entities;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopProjectDbContext context) : base(context) { }
    }
}
