using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTCCodingAssignment.Interfaces
{
    public interface IBasketItem
    {
        IProduct Product { get; set; }
        int Quantity { get; set; }
    }
}
