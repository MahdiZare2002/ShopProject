using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Dtos.OrderDetail
{
    public class CreateOrderDetailDto
    {
        [Required]
        public int ProductId { get; private set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product price must be greater than 0")]
        public decimal ProductPrice { get; private set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; private set; }
    }
}
