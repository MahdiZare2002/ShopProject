using MediatR;
using ShopProject.Application.Dtos.Address;
using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Address.Queries.GetAllAddresses
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAddressesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _unitOfWork.Repository<Domain.Entities.Address>().GetAllAsync();

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
