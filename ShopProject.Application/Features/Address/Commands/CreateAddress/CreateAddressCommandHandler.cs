using MediatR;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var address = new Domain.Entities.Address(
                    request.CustomerId,
                    request.State,
                    request.City,
                    request.CompleteAddress,
                    request.NoNumber
                );

                await _unitOfWork.Repository<Domain.Entities.Address>().AddAsync(address);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return address.Id;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
