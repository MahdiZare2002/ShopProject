using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ShopProject.Application.Features.Order.Commands.AddOrderDetail
{
    public class AddOrderDetailCommand : IRequest<bool>
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal ProductPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
