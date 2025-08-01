using MediatR;
using ShopProject.Application.Interfaces.UnitOfWork;
using ShopProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Features.Order.Commands.AddOrderDetail
{
    public class AddOrderDetailCommandHandler : IRequestHandler<AddOrderDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddOrderDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(AddOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var order = await _unitOfWork.Repository<Domain.Entities.Order>().GetByIdAsync(request.OrderId);
                if (order == null)
                    throw new ArgumentException("Order not found");

                if (order.OrderStatus != OrderStatus.Pending)
                    throw new InvalidOperationException("Cannot modify order that is not pending");

                var productExists = await _unitOfWork.Repository<Domain.Entities.Product>()
                    .ExistsAsync(p => p.Id == request.ProductId);
                if (!productExists)
                    throw new ArgumentException("Product not found");

                order.AddOrderDetail(request.ProductId, request.ProductPrice, request.Quantity);

                _unitOfWork.Orders.Update(order);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
