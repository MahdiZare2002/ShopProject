using MediatR;
using ShopProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public decimal ProductPrice { get; private set; }
        public ProductPriority ProductPriority { get; private set; }
        public int StockQuantity { get; private set; }
        public string ProductSlug { get; private set; }
        public bool IsActive { get; private set; }
    }
}
