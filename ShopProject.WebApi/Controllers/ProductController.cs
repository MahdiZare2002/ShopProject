using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Application.Dtos.Product;
using ShopProject.Application.Features.Product.Commands.CreateProduct;
using ShopProject.Application.Features.Product.Commands.DeleteProduct;
using ShopProject.Application.Features.Product.Commands.UpdateProduct;
using ShopProject.Application.Features.Product.Queries.GetAllProducts;
using ShopProject.Application.Features.Product.Queries.GetProductById;

namespace ShopProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var productId = await _mediator.Send(command);
                return Ok(productId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to create product: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProductAsync(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id) return BadRequest("Product ID mismatch.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updatedProduct = await _mediator.Send(command);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProductCommand { Id = id });
                return result ? NoContent() : NotFound();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete product: {ex.Message}");
            }
        }
    }
}
