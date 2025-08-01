using ShopProject.Domain.Entities;
using ShopProject.Domain.Enums;

namespace ShopProject.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderWithDetailsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<(IEnumerable<Order> Orders, int TotalCount)> GetPagedOrdersAsync(int pageNumber, int pageSize, int? customerId = null);
    }
}
