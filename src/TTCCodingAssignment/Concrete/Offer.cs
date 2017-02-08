using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTCCodingAssignment.Interfaces;

namespace TTCCodingAssignment.Concrete
{
    public class Offer: IOffer
    {
        List<IOfferCondition> conditions;
        List<IOfferDiscount> discounts;

        public Offer(List<IOfferCondition> conditions, List<IOfferDiscount> discounts)
        {
            this.Conditions = conditions;
            this.Discounts = discounts;
        }
public List<IOfferCondition> Conditions
        {
            get
            {
                return this.conditions;
            }

            set
            {
                if (value == null || value.Count == 0)
                    throw new Exception("At least one condition is required.");
                this.conditions = value;
            }
        }

        public List<IOfferDiscount> Discounts
        {
            get
            {
                return this.discounts;
            }

            set
            {
                if (value == null || value.Count == 0)
                    throw new Exception("At least one discount is required.");
                this.discounts = value;
            }
        }
    }
}
