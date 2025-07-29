using MediatR;

namespace ShopProject.Application.Features.Address.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
