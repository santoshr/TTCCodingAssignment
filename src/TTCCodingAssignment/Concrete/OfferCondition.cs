using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTCCodingAssignment.Interfaces;

namespace TTCCodingAssignment.Concrete
{
    public class OfferCondition : IOfferCondition
    {
        public OfferCondition(IProduct product, int count)
        {
            this.Product = product;
            this.Count = count;
        }
        int count;
        IProduct product;
        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                if (value <= 0)
                    throw new Exception("Product count must be greater than zero.");
                this.count = value;
            }
        }

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

       
    }
}
