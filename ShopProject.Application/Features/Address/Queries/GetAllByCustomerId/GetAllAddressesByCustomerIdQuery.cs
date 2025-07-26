using MediatR;
using ShopProject.Application.Dtos.Address;

namespace ShopProject.Application.Features.Address.Queries.GetAllByCustomerId
{
    public record class GetAllAddressesByCustomerIdQuery(int customerId) : IRequest<IEnumerable<AddressDto>>;
}
