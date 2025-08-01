using ShopProject.Domain.Entities;

namespace ShopProject.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductBySlugAsync(string slug);
    }
}
