using MediatR;
using ShopProject.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Features.Product.Queries.GetAllProducts
{
    public record class GetProductsQuery : IRequest<List<ProductDto>>;
}
