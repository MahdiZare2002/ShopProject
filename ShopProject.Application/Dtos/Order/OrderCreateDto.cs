using ShopProject.Application.Dtos.OrderDetail;

namespace ShopProject.Application.Dtos.Order
{
    public class OrderCreateDto
    {
        public int CustomerId { get; set; }
        public List<OrderDetailCreateDto> OrderDetails { get; set; } = new();
    }
}
