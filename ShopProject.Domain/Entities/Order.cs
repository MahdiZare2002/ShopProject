using ShopProject.Domain.Common;
using ShopProject.Domain.Enums;
using System.Collections.ObjectModel;

namespace ShopProject.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; private set; }
        public int AddressId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public OrderPaymentMethod PaymentMethod { get; private set; }
        public DateTime? PaidDate { get; private set; }
        private readonly List<OrderDetail> _orderDetails = new();
        public ReadOnlyCollection<OrderDetail> orderDetails => _orderDetails.AsReadOnly();
        public decimal TotalAmount => _orderDetails.Sum(d => d.TotalPrice);

        private Order() { }
        public Order(int customerId, int addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
            OrderStatus = OrderStatus.Pending;
            PaymentMethod = OrderPaymentMethod.NotPaid;
            PaidDate = null;
        }
        public void ChangeOrderStatus(OrderStatus orderStatus, OrderPaymentMethod paymentMethod = 0)
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

        public void AddOrderDetail(int productId, decimal productPrice, int quantity)
        {
            if (_orderDetails.Any(d => d.ProductId == productId)) throw new ArgumentException("product already exist in order");
            var detail = new OrderDetail(Id, productId, productPrice, quantity);
            _orderDetails.Add(detail);
        }
    }
}