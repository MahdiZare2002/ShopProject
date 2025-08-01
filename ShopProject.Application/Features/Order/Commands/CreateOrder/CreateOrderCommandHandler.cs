using MediatR;
using ShopProject.Application.Interfaces.UnitOfWork;
using ShopProject.Domain.Entities;

namespace ShopProject.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerExists = await _unitOfWork.Repository<Customer>().ExistsAsync(c => c.Id == request.CustomerId);
                if (!customerExists)
                {
                    throw new Exception("Customer not found");
                }

                // Fully qualify the 'Order' type to avoid conflict with the namespace  
                var order = new Domain.Entities.Order(request.CustomerId, request.AddressId);

                // Add order details
                foreach (var item in request.Items)
                {
                    // Validate product exists
                    var productExists = await _unitOfWork.Repository<Domain.Entities.Product>()
                        .ExistsAsync(p => p.Id == item.ProductId);
                    if (!productExists)
                        throw new ArgumentException($"Product {item.ProductId} not found");

                    order.AddOrderDetail(item.ProductId, item.ProductPrice, item.Quantity);
                }

                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return order.Id;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
