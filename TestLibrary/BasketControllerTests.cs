using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TTCCodingAssignment.Controllers;
using TTCCodingAssignment.Concrete;
using TTCCodingAssignment.Interfaces;

namespace TestLibrary
{
    public class ProductsFixture : IDisposable
    {
        public ProductsFixture()
        {
            Products = CreateProducts();
            OfferCalculator = new OfferCalculator(CreateOffers(this.Products));

        }

        public void Dispose()
        {
        }

        private Dictionary<string, IProduct> CreateProducts()
        {
            Dictionary<string, IProduct> products = new Dictionary<string, IProduct>();
            products.Add("Butter", new Product("Butter", 0.80m));
            products.Add("Milk", new Product("Milk", 1.15m));
            products.Add("Bread", new Product("Bread", 1.00m));
            return products;
        }

        private List<IOffer> CreateOffers(Dictionary<string, IProduct> products)
        {
            List<IOffer> offers = new List<IOffer>();

            List<IOfferCondition> conditions1 = new List<IOfferCondition>();
            conditions1.Add(new OfferCondition(products["Butter"], 2));
            conditions1.Add(new OfferCondition(products["Bread"], 1));

            List<IOfferDiscount> discounts1 = new List<IOfferDiscount>();
            discounts1.Add(new OfferDiscount(1, 50, products["Bread"]));
            offers.Add(new Offer(conditions1, discounts1));

            List<IOfferCondition> conditions2 = new List<IOfferCondition>();
            conditions2.Add(new OfferCondition(products["Milk"], 4));

            List<IOfferDiscount> discounts2 = new List<IOfferDiscount>();
            discounts2.Add(new OfferDiscount(1, 100, products["Milk"]));
            offers.Add(new Offer(conditions2, discounts2));

            return offers;
        }
        public IOfferCalculator OfferCalculator { get; private set; }
        public Dictionary<string, IProduct> Products { get; private set; }

    }
    public class BasketControllerTests : IClassFixture<ProductsFixture>
    {
        ProductsFixture fixture;
        public BasketControllerTests(ProductsFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void NoDiscountScenario1()
        {
           
            IBasket basket = new BasketController(fixture.OfferCalculator);
            basket.Add(new BasketItem(fixture.Products["Bread"], 1));
            basket.Add(new BasketItem(fixture.Products["Butter"], 1));
            basket.Add(new BasketItem(fixture.Products["Milk"], 1));

            Assert.Equal(2.95m, basket.CalculateTotal());
        }

        [Fact]
        public void DiscountScenario1()
        {
            IBasket basket = new BasketController(fixture.OfferCalculator);
            basket.Add(new BasketItem(fixture.Products["Bread"], 2));
            basket.Add(new BasketItem(fixture.Products["Butter"], 2));
            
            Assert.Equal(3.10m, basket.CalculateTotal());
        }

        [Fact]
        public void DiscountScenario2()
        {
            IBasket basket = new BasketController(fixture.OfferCalculator);
            basket.Add(new BasketItem(fixture.Products["Milk"], 4));
            
            Assert.Equal(3.45m, basket.CalculateTotal());
        }

        [Fact]
        public void DiscountScenario3()
        {
            IBasket basket = new BasketController(fixture.OfferCalculator);
            basket.Add(new BasketItem(fixture.Products["Bread"], 1));
            basket.Add(new BasketItem(fixture.Products["Butter"], 2));
            basket.Add(new BasketItem(fixture.Products["Milk"], 8));

            Assert.Equal(9.00m, basket.CalculateTotal());
        }
        
    }
}
