using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Application.Dtos.Address;
using ShopProject.Application.Features.Address.Commands.CreateAddress;
using ShopProject.Application.Features.Address.Commands.DeleteAddress;
using ShopProject.Application.Features.Address.Commands.UpdateAddress;
using ShopProject.Application.Features.Address.Queries.GetAddressById;
using ShopProject.Application.Features.Address.Queries.GetAllAddresses;
using ShopProject.Application.Features.Address.Queries.GetAllByCustomerId;

namespace ShopProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> GetAllAsync()
        {
            var addresses = await _mediator.Send(new GetAllAddressesQuery());

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetByIdAsync(int id)
        {
            var address = await _mediator.Send(new GetAddressByIdQuery(id));
            if (address == null) return NotFound("AddressNotFound");

            return Ok(address);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<AddressDto>>> GetAllByIdCustomer(int customerId)
        {
            var addresses = await _mediator.Send(new GetAllAddressesByCustomerIdQuery(customerId));

            return Ok(addresses);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateAddressAsync([FromBody] CreateAddressCommand addressCommand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var addressId = await _mediator.Send(addressCommand);
                return Ok();
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

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateAddressAsync(int id, [FromBody] UpdateAddressCommand addressCommand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != addressCommand.Id) return BadRequest("Id mismatch");
            try
            {
                await _mediator.Send(addressCommand);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update order: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteAddressAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteAddressCommand { Id = id });
                if (!result)
                    return NotFound($"Order with ID {id} not found.");

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete order: {ex.Message}");
            }
        }
    }
}
