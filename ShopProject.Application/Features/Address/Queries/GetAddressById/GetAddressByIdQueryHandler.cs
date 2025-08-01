using MediatR;
using ShopProject.Application.Dtos.Address;
using ShopProject.Application.Interfaces.Repositories;

namespace ShopProject.Application.Features.Address.Queries.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressByIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.addressId);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {request.addressId} not found.");
            }
            return new AddressDto
            {
                Id = address.Id,
                State = address.State,
                CustomerId = address.CustomerId,
                City = address.City,
                CompleteAddress = address.CompleteAddress,
                NoNumber = address.NoNumber
            };
        }
    }
}
