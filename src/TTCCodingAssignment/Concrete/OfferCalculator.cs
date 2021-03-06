﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTCCodingAssignment.Interfaces;

namespace TTCCodingAssignment.Concrete
{
    public class OfferCalculator : IOfferCalculator
    {
        List<IOffer> offers;

        public OfferCalculator(List<IOffer> offers)
        {
            if (offers == null)
                throw new NullReferenceException("Offers cannot be null");
            this.offers = offers;
        }


        public decimal CalculateDiscount(Dictionary<string,IBasketItem> basketItems)
        {

            decimal discount = 0.00m;
            if (basketItems == null || basketItems.Count <=0)
                return discount;

            bool anyDiscountsApplied = true;
            while (basketItems.Count > 0 && anyDiscountsApplied)
            {
                //reset at the start of the loop
                anyDiscountsApplied = false;

                foreach (IOffer offer in offers)
                {
                    bool conditionsMet = false;
                    foreach (IOfferCondition condition in offer.Conditions)
                    {
                        if (!(basketItems.ContainsKey(condition.Product.Name) &&
                            (basketItems[condition.Product.Name].Quantity >= condition.Count)))
                        {
                            conditionsMet = false;
                            break;
                        }
                        conditionsMet = true;
                        
                        //if quantity is now 0 remove tht item as we don't care about it anymore
                        if ((basketItems[condition.Product.Name].Quantity - condition.Count) == 0)
                            basketItems.Remove(condition.Product.Name);
                        else
                            //deduct the quantity matched
                            basketItems[condition.Product.Name].Quantity -= condition.Count;

                    }
                    if (conditionsMet)
                    {
                        anyDiscountsApplied = true;
                        foreach (IOfferDiscount offerDiscount in offer.Discounts)
                        {
                            discount += ((offerDiscount.Product.Price * offerDiscount.PercentDiscount) / 100) * offerDiscount.Count;
                        }
                    }
                }
            }
            
            return discount;
            
        }
    }
}
