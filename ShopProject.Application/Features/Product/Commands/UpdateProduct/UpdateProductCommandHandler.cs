using MediatR;
using ShopProject.Application.Dtos.Product;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(request.Id);
                if (product == null) throw new Exception("Product Not Found");

                product.Edit(request.ProductName, request.ProductDescription, request.ProductPrice, request.ProductPriority, request.StockQuantity);

                _unitOfWork.Repository<Domain.Entities.Product>().Update(product);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return new ProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductPriority = product.ProductPriority,
                    StockQuantity = product.StockQuantity
                };
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }

        }
    }
}
