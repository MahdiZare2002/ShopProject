using MediatR;
using ShopProject.Application.Dtos.Product;
using ShopProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopProject.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public ProductPriority ProductPriority { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }
}
