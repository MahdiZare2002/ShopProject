using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Domain.Entities;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(ShopProjectDbContext context) : base(context) {}

        public async Task<Product> GetProductBySlugAsync(string slug)
        {
            return await GetFirstOrDefaultAsync(p => p.ProductSlug == slug);
        }
    }
}
