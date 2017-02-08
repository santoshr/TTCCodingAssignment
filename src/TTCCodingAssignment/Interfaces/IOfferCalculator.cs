using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTCCodingAssignment.Interfaces
{
    public interface IOfferCalculator
    {
        decimal CalculateDiscount(Dictionary<string,IBasketItem> basketItems);
    }
}
