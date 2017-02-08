using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTCCodingAssignment.Interfaces
{
    public interface IBasket
    {
        void Add(IBasketItem basketItem);
        decimal CalculateTotal();
    }
}
