using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTCCodingAssignment.Interfaces;

namespace TTCCodingAssignment.Concrete
{
    public class BasketItem : IBasketItem
    {
        public BasketItem(IProduct product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        IProduct product;
        int quantity;

        public IProduct Product
        {
            get
            {
                return this.product;
            }

            set
            {
                if (value == null)
                    throw new NullReferenceException("Product cannot be null.");
                this.product = value;
                  
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                if (value <= 0)
                    throw new Exception("Quantity must be greater than zero.");
                this.quantity = value;
            }
        }
    }
}
