using MediatR;
using ShopProject.Application.Dtos.Address;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Address.Queries.GetAllByCustomerId
{
    public class GetAllAddressesByCustomerIdQueryHandler : IRequestHandler<GetAllAddressesByCustomerIdQuery, IEnumerable<AddressDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAddressesByCustomerIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _unitOfWork.Repository<Domain.Entities.Address>().GetWhereAsync(a => a.CustomerId == request.customerId);
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
