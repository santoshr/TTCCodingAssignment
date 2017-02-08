using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTCCodingAssignment.Interfaces
{
    public interface IOfferDiscount
    {
        IProduct Product { get; set; }
        int Count { get; set; }

        int PercentDiscount { get; set; }
    }
}
