using Microsoft.EntityFrameworkCore;
using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Domain.Entities;
using ShopProject.Domain.Enums;
using ShopProject.Infrustructure.Context;
using System.Linq.Expressions;

namespace ShopProject.Infrustructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopProjectDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await GetWhereAsync(o => o.CustomerId == customerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await GetWhereAsync(o => o.OrderStatus == status);
        }

        public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
        {
            return await _dbSet
            .Include(o => o.orderDetails)
            .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<(IEnumerable<Order> Orders, int TotalCount)> GetPagedOrdersAsync(int pageNumber, int pageSize, int? customerId = null)
        {
            Expression<Func<Order, bool>> predicate = o => true;

            if (customerId.HasValue)
                predicate = o => o.CustomerId == customerId.Value;

            return await GetPagedAsync(pageNumber, pageSize, predicate);
        }
    }
}
