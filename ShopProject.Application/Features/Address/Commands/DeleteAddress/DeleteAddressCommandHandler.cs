using MediatR;
using ShopProject.Domain.Interfaces.Repositories;

namespace ShopProject.Application.Features.Address.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.Id);

            if (address == null) return false;

            _addressRepository.Delete(address);
            return true;
        }
    }
}
