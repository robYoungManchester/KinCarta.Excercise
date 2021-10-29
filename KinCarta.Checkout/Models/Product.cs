namespace KinCarta.Checkout.Models
{
    /// <summary>
    /// A product line
    /// </summary>
    public class Product
    {
        /// <summary>
        /// unique identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Human Readable Title in English
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Price in £ - will be migrated to pricing table and subject to currency fluctuations
        /// This is the base price
        /// </summary>
        public decimal Price { get; set; }
    }
}
