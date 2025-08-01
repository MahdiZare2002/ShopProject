using MediatR;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var product = new Domain.Entities.Product
                   (
                    request.ProductName,
                    request.ProductDescription,
                    request.ProductPrice,
                    request.ProductPriority,
                    request.StockQuantity,
                    request.IsActive
                   );

                await _unitOfWork.Repository<Domain.Entities.Product>().AddAsync(product);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return product.Id;
            }
            catch
            {
                _unitOfWork.RollbackTransactionAsync();
                throw;
            }

        }
    }
}
