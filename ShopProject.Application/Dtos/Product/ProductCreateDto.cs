using ShopProject.Domain.Enums;

namespace ShopProject.Application.Dtos.Product
{
    public class ProductCreateDto
    {
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductPriority ProductPriority { get; set; }
        public bool IsActive { get; set; }
    }
}
