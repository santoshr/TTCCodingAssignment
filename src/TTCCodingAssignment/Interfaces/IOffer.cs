using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTCCodingAssignment.Interfaces
{
    public interface IOffer
    {
        List<IOfferCondition> Conditions { get; set; }
        List<IOfferDiscount> Discounts { get; set; }
    }
}
