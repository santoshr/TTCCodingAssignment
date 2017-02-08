using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTCCodingAssignment.Interfaces;
using TTCCodingAssignment.Concrete;

namespace TTCCodingAssignment.Controllers
{
    public class BasketController : Controller, IBasket
    {
        Dictionary<string,IBasketItem> basketItems = new Dictionary<string, IBasketItem>();
        IOfferCalculator offerCalulator;

        public BasketController(IOfferCalculator offerCalc)
        {
            if (offerCalc == null)
                throw new NullReferenceException("Offer Calculator cannot be null.");
            this.offerCalulator = offerCalc;
        }
        public void Add(IBasketItem basketItem)
        {
            if (basketItem == null)
                throw new NullReferenceException("Basket Item cannot be null.");
            if (basketItems.ContainsKey(basketItem.Product.Name))
            {
                basketItems[basketItem.Product.Name].Quantity += basketItem.Quantity;
            }
            else
            {
                basketItems.Add(basketItem.Product.Name, basketItem);
            }
        }

        public decimal CalculateTotal()
        {
            decimal total = 0.00m;
            foreach (KeyValuePair<string, IBasketItem> basketitem in basketItems)
            {
                total += basketitem.Value.Product.Price * basketitem.Value.Quantity;
            }
            decimal discount = offerCalulator.CalculateDiscount(basketItems);
            return (total - discount);
        }

       
    }
}
