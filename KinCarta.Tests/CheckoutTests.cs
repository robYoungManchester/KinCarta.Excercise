using System.Collections.Generic;
using System.Linq;
using KinCarta.Checkout.Models;
using NUnit.Framework;

namespace KinCarta.Tests
{
    public class CheckoutTests
    {
        private List<Product> _productCatalogue;
        private PromotionRules _promotionRules;

        [SetUp]
        public void Setup()
        {
            _productCatalogue = new List<Product>
            {
                new Product {Id = 1, Name = "Water Bottle", Price = 24.95M},
                new Product {Id = 2, Name = "Hoodie", Price = 65.0M},
                new Product {Id = 3, Name = "Sticker Set", Price = 3.99M}
            };

            _promotionRules = new PromotionRules
            {
                BulkBuyDiscounts = new List<BulkBuyDiscount>
                    {new BulkBuyDiscount {CutOffValue = 75.0M, Discount = 0.1M}},
                ProductDiscounts = new List<ProductDiscount>
                {
                    new ProductDiscount {DiscountedPrice = 22.99M, Quantity = 2, ProductId = 1}
                }
            };
        }

        [Test]
        public void Test1()
        {
            var expected = 103.47M;
            var actual = GetTotalFromBasket(new List<int> { 1, 1, 2, 3 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var expected = 68.97M;
            var actual = GetTotalFromBasket(new List<int> { 1, 1, 1 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var expected = 120.59M;
            var actual = GetTotalFromBasket(new List<int> { 2, 2, 3 });
            Assert.AreEqual(expected, actual);
        }

        private decimal GetTotalFromBasket(IEnumerable<int> productIds)
        {
            var checkout = new Checkout.Checkout(_promotionRules);
            var basket = new List<Product>();
            foreach (var productId in productIds)
            {
                basket.Add(_productCatalogue.First(x => x.Id == productId));
            }

            checkout.Scan(basket);

            return checkout.Total();
        }
    }
}