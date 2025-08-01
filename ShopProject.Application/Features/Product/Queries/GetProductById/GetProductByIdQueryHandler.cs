using MediatR;
using ShopProject.Application.Dtos.Product;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(request.Id);
            if (product == null) throw new Exception("product not found");

            return new ProductDto
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductPriority = product.ProductPriority,
                StockQuantity = product.StockQuantity,
            };
        }
    }
}
