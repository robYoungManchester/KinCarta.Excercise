using System.Collections.Generic;
using System.Linq;
using KinCarta.Checkout.Models;

namespace KinCarta.Checkout
{
    /// <summary>
    /// Applies business rules to the checkout
    /// </summary>
    public class Checkout
    {
        private readonly PromotionRules _rules;
        private decimal _totalBasketValue;
        public Checkout(PromotionRules rules)
        {
            _rules = rules;
        }

        public void Scan(IEnumerable<Product> basket)
        {
            var groupedBasket = basket.GroupBy(p => p);

            _totalBasketValue = groupedBasket.Sum(x => LineValue(x.Key, x.Count()));

            var highestBasketValueDiscount = _rules.BulkBuyDiscounts.OrderBy(x => x.CutOffValue)
                .LastOrDefault(x => x.CutOffValue < _totalBasketValue);

            if (highestBasketValueDiscount != null)
            {
                _totalBasketValue =
                    decimal.Round(_totalBasketValue * (1.0M - highestBasketValueDiscount.Discount), 2);
            }
        }

        private decimal LineValue(Product product, int quantity)
        {
            var firstApplicableRule =
                _rules.ProductDiscounts.FirstOrDefault(p => p.ProductId == product.Id && quantity >= p.Quantity);

            return quantity * (firstApplicableRule?.DiscountedPrice ?? product.Price);
        }

        public decimal Total()
        {
            return _totalBasketValue;
        }
    }
}
