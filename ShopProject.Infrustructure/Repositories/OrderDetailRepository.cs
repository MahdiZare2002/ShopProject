using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Domain.Entities;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ShopProjectDbContext context) : base(context) { }
        public async Task<IEnumerable<OrderDetail>> GetDetailsByOrderIdAsync(int orderId)
        {
            return await GetWhereAsync(od => od.OrderId == orderId);
        }

        public async Task<OrderDetail> GetOrderDetailAsync(int orderId, int productId)
        {
            return await GetFirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }
    }
}
