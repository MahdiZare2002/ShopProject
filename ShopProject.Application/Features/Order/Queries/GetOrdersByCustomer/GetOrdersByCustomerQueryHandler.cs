using MediatR;
using ShopProject.Application.Dtos.Order;
using ShopProject.Application.Interfaces.UnitOfWork;
using ShopProject.Domain.Entities;

namespace ShopProject.Application.Features.Order.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQuery, List<OrderSummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOrdersByCustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<OrderSummaryDto>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByCustomerIdAsync(request.CustomerId);
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(request.CustomerId);

            return orders.Select(order => new OrderSummaryDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                AddressId = order.AddressId,
                OrderStatus = order.OrderStatus,
                PaymentMethod = order.PaymentMethod,
                PaidDate = order.PaidDate,
                TotalAmount = order.TotalAmount

            }).ToList();
        }
    }
}
