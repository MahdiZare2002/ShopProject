using ShopProject.Application.Dtos.Product;

namespace ShopProject.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductCreateDto dto);
        Task<ProductDto> UpdateAsync(ProductCreateDto dto);
        Task DeleteAsync(int id);
    }
}
