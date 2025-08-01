using MediatR;
using ShopProject.Application.Dtos.Product;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Product.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<Domain.Entities.Product>().GetAllAsync();
            return products.Select(MapToDto).ToList();
        }

        private ProductDto MapToDto(Domain.Entities.Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductPriority = product.ProductPriority,
                StockQuantity = product.StockQuantity,
            };
        }
    }
}
