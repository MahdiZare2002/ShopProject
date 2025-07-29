using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public required string CompleteAddress { get; set; }
        public int NoNumber { get; set; }
    }
}
