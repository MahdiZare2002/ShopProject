using MediatR;
using ShopProject.Application.Interfaces.Repositories;

namespace ShopProject.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressRepository _addressRepository;
        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Domain.Entities.Address(
                request.CustomerId,
                request.State,
                request.City,
                request.CompleteAddress,
                request.NoNumber
            );

            await _addressRepository.AddAsync(address);
            return address.Id;
        }
    }
}
