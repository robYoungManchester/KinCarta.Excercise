using System;
using System.Collections.Generic;
using System.Text;

namespace KinCarta.Checkout.Models
{
    /// <summary>
    /// Business Rules to be applied at checkout
    /// </summary>
    public class PromotionRules
    {
        /// <summary>
        /// Bulk buy discount rules - we might have cut offs at various values
        /// </summary>
        public List<BulkBuyDiscount> BulkBuyDiscounts { get; set; }
        /// <summary>
        /// Discounts on individual products by ID - if there are multiple records for a product we'll just apply the first
        /// </summary>
        public List<ProductDiscount> ProductDiscounts { get; set; }
    }
}
