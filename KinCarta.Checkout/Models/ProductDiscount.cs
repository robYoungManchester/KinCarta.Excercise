namespace KinCarta.Checkout.Models
{
    public class ProductDiscount
    {
        /// <summary>
        /// References ID in the product class
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Quantity of this product in the basket where the discount applies
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Discounted price - suggest this later appears as a percentage discount so it cannot be higher then the actual price
        /// </summary>
        public decimal DiscountedPrice { get; set; }
    }
}