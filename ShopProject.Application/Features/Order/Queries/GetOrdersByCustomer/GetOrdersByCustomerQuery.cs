using MediatR;
using ShopProject.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Features.Order.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQuery : IRequest<List<OrderSummaryDto>>
    {
        public int CustomerId { get; set; }
    }
}
