using ShopProject.Domain.Entities;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopProjectDbContext _context;
        public ProductRepository(ShopProjectDbContext context)
        {
            _context = context;
        }
    }
}
