using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Application.Dtos.Address
{
    public class AddressCreateDto
    {
        public int CustomerId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CompleteAddress { get; set; }
        public int NoNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
