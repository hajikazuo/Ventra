using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventra.Domain.Enums
{
    public enum OrderStatus
    {
        Cart,
        Placed,
        Verified,
        Fulfilled,
        Delivered,
        Canceled
    }
}
