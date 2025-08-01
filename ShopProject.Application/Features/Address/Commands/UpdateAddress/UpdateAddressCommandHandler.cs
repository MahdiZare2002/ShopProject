using MediatR;
using ShopProject.Application.Interfaces.Repositories;

namespace ShopProject.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.Id);
            if (address == null) return false;
            

            address.Edit(
                request.State,
                request.City,
                request.CompleteAddress,
                request.NoNumber
            );

            _addressRepository.Update(address);
            return true;
        }
    }
}
