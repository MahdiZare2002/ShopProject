using ShopProject.Domain.Common;

namespace ShopProject.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public decimal ProductPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        private OrderDetail() { }
        public OrderDetail(int orderId, int productId, decimal productPrice, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductPrice = productPrice;
            Quantity = quantity;
            TotalPrice = productPrice * quantity;
        }
        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            TotalPrice = quantity * ProductPrice;
        }
    }
}
