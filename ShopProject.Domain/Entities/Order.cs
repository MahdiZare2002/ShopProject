using ShopProject.Domain.Common;
using ShopProject.Domain.Enums;

namespace ShopProject.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; private set; }
        public int AddressId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public OrderPaymentMethod PaymentMethod { get; private set; }
        public DateTime? PaidDate { get; private set; }

        private Order() { }
        public Order(int customerId, int addressId, decimal totalAmount)
        {
            CustomerId = customerId;
            AddressId = addressId;
            TotalAmount = totalAmount;
            OrderStatus = OrderStatus.Pending;
            PaymentMethod = OrderPaymentMethod.NotPaid;
            PaidDate = null;
        }
        public void ChangeOrderStatus(OrderStatus orderStatus, OrderPaymentMethod paymentMethod)
        {
            if (orderStatus == OrderStatus.Paid)
            {
                OrderStatus = orderStatus;
                PaymentMethod = paymentMethod;
                PaidDate = DateTime.Now;
            }
            else
            {
                OrderStatus = orderStatus;
            }
        }

    }
}
