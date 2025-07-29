using MediatR;
using ShopProject.Application.Dtos.Address;

namespace ShopProject.Application.Features.Address.Queries.GetAllAddresses
{
    public record class GetAllAddressesQuery() : IRequest<IEnumerable<AddressDto>>;
}
