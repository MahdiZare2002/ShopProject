using MediatR;
using ShopProject.Application.Interfaces.Repositories;
using ShopProject.Application.Interfaces.UnitOfWork;

namespace ShopProject.Application.Features.Address.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                
                var address = await _unitOfWork.Repository<Domain.Entities.Address>().GetByIdAsync(request.Id);
                if (address == null) throw new Exception("Address Not Found");

                _unitOfWork.Repository<Domain.Entities.Address>().Delete(address);
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
