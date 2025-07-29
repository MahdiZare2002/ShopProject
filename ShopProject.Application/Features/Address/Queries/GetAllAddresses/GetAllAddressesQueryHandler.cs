using MediatR;
using ShopProject.Application.Dtos.Address;
using ShopProject.Domain.Interfaces.Repositories;

namespace ShopProject.Application.Features.Address.Queries.GetAllAddresses
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressDto>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAllAddressesQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync();

            return addresses.Select(a => new AddressDto
            {
                Id = a.Id,
                State = a.State,
                CustomerId = a.CustomerId,
                City = a.City,
                CompleteAddress = a.CompleteAddress,
                NoNumber = a.NoNumber
            });
        }
    }
}
