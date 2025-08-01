using ShopProject.Domain.Enums;

namespace ShopProject.Application.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductPriority ProductPriority { get; set; }
        public int StockQuantity { get; set; }
    }
}
