using ShopProject.Domain.Common;
using ShopProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public decimal? ProductPrice { get; private set; }
        public ProductQuantity ProductQuantity { get; private set; }

        private Product() { }
        public Product(string productName, string productDescription, decimal? productPrice, ProductQuantity productQuantity)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }

        public void Edit(string productName, string productDescription, decimal? productPrice, ProductQuantity productQuantity)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}
