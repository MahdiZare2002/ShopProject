using MediatR;
using ShopProject.Application.Dtos.Address;
using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Address.Queries.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAddressByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _unitOfWork.Repository<Domain.Entities.Address>().GetByIdAsync(request.addressId);
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
