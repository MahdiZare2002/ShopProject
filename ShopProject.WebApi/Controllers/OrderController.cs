using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Application.Dtos.Order;
using ShopProject.Application.Features.Order.Commands.AddOrderDetail;
using ShopProject.Application.Features.Order.Commands.CreateOrder;
using ShopProject.Application.Features.Order.Queries.GetOrderById;
using ShopProject.Application.Features.Order.Queries.GetOrdersByCustomer;

namespace ShopProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderByIdAsync(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<OrderSummaryDto>>> GetOrdersByCustomerAsync(int customerId)
        {
            var orders = await _mediator.Send(new GetOrdersByCustomerQuery { CustomerId = customerId });
            return Ok(orders);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateOrderAsync([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var orderId = await _mediator.Send(command);
                return Ok(orderId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to create order: {ex.Message}");
            }
        }

        [HttpPost("add-detail")]
        public async Task<IActionResult> AddOrderDetailAsync([FromBody] AddOrderDetailCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _mediator.Send(command);
                return result ? Ok() : BadRequest("Failed to add order detail.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add order detail: {ex.Message}");
            }
        }
    }
}
