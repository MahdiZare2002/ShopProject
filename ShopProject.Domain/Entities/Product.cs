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
        public bool IsActive { get; private set; }

        private Product() { }
        public Product(string productName, string productDescription, decimal? productPrice, ProductPriority productpriority , bool isActive)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductPriority = productpriority;
            IsActive = isActive;
        }

        public void Edit(string productName, string productDescription, decimal? productPrice, ProductPriority productpriority)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductPriority = productpriority;
        }
    }
}
