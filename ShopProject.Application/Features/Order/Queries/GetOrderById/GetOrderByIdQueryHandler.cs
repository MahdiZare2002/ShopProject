using MediatR;
using ShopProject.Application.Dtos.Order;
using ShopProject.Application.Dtos.OrderDetail;
using ShopProject.Application.Interfaces.UnitOfWork;
using ShopProject.Domain.Entities;

namespace ShopProject.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(request.OrderId);
            if (order == null) return null;

            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(order.CustomerId);
            var address = await _unitOfWork.Repository<Domain.Entities.Address>().GetByIdAsync(order.AddressId);

            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                AddressId = order.AddressId,
                OrderStatus = order.OrderStatus,
                PaymentMethod = order.PaymentMethod,
                PaidDate = order.PaidDate,
                orderDetails = order.orderDetails.Select(d => new OrderDetailDto
                {
                    ProductId = d.ProductId,
                    ProductPrice = d.ProductPrice,
                    Quantity = d.Quantity,
                    TotalPrice = d.TotalPrice
                }).ToList()
            };
        }
    }
}
