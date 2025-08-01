using MediatR;
using ShopProject.Application.Dtos.Address;
using ShopProject.Application.Interfaces.Repositories;

namespace ShopProject.Application.Features.Address.Queries.GetAllByCustomerId
{
    public class GetAllAddressesByCustomerIdQueryHandler : IRequestHandler<GetAllAddressesByCustomerIdQuery, IEnumerable<AddressDto>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAllAddressesByCustomerIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllByCustomerIdAsync(request.customerId);
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
