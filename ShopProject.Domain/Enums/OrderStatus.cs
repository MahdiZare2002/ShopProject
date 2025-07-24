using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Paid = 1,
        Confirmed = 2,
        Canceled = 3,
    }
}
