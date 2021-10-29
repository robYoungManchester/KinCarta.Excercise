namespace KinCarta.Checkout.Models
{
    /// <summary>
    /// A bulk buy discount rule
    /// </summary>
    public class BulkBuyDiscount
    {
        /// <summary>
        /// Total basket value at which discount kicks in
        /// </summary>
        public decimal CutOffValue { get; set; }
        /// <summary>
        /// Discount as a double - e.g. 70% = 0.7
        /// </summary>
        public decimal Discount { get; set; }
    }
}