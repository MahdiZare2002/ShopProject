using MediatR;

namespace ShopProject.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public required string CompleteAddress { get; set; }
        public int NoNumber { get; set; }
    }
}
