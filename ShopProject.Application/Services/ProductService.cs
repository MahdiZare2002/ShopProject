using ShopProject.Application.Dtos.Product;
using ShopProject.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductDto> CreateAsync(ProductCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateAsync(ProductCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
