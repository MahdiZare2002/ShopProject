using MediatR;
using ShopProject.Application.Dtos.Address;

namespace ShopProject.Application.Features.Address.Queries.GetAddressById
{
    public record class GetAddressByIdQuery(int addressId) : IRequest<AddressDto>;
}
