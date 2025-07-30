using ShopProject.Domain.Common;
using ShopProject.Domain.Enums;

namespace ShopProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public decimal? ProductPrice { get; private set; }
        public ProductPriority ProductPriority { get; private set; }
        public int StockQuantity { get; private set; }
        public string ProductSlug { get; private set; }
        public bool IsActive { get; private set; }

        private Product() { }
        public Product(string productName, string productDescription, decimal? productPrice, ProductPriority productpriority, int stockQuantity, bool isActive)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductPriority = productpriority;
            IsActive = isActive;
            StockQuantity = stockQuantity;
            ProductSlug = GenerateProductSlug(productName);
        }

        public void Edit(string productName, string productDescription, decimal? productPrice, ProductPriority productpriority, int stockQuantity)
        {
            ProductName = productName;
            ProductSlug = GenerateProductSlug(productName);
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductPriority = productpriority;
            StockQuantity = stockQuantity;
        }
        private string GenerateProductSlug(string productName) => productName.ToLower().Replace(" ", "-").Replace("--", "-").Trim();
        

        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));

            StockQuantity += quantity;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));

            if (!HasSufficientStock(quantity))
                throw new InvalidOperationException("Insufficient stock.");

            StockQuantity -= quantity;
        }
        
        public bool HasSufficientStock(int quantity)
        {
            return StockQuantity >= quantity;
        }
    }
}
