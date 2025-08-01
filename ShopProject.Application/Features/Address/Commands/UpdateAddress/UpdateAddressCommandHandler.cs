using MediatR;
using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var address = await _unitOfWork.Repository<Domain.Entities.Address>().GetByIdAsync(request.Id);
                if (address == null) throw new Exception("Address Not Found!!");

                address.Edit(request.State, request.City, request.CompleteAddress, request.NoNumber);

                _unitOfWork.Repository<Domain.Entities.Address>().Update(address);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
