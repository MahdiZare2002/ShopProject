using MediatR;
using ShopProject.Application.Dtos.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public List<CreateOrderDetailDto> Items { get; set; } = new();
    }
}
