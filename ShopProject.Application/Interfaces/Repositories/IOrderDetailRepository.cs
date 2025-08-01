using ShopProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Interfaces.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetDetailsByOrderIdAsync(int orderId);
        Task<OrderDetail> GetOrderDetailAsync(int orderId, int productId);
    }
}
