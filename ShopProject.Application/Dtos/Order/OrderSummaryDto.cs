using ShopProject.Application.Dtos.OrderDetail;
using ShopProject.Domain.Enums;

namespace ShopProject.Application.Dtos.Order
{
    public class OrderSummaryDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderPaymentMethod PaymentMethod { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
