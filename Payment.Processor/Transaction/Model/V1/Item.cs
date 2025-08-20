using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model.V1
{
    /// <summary>
    /// Describes an item being purchased as part of the transaction.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The item identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item classification.
        /// </summary>
        public string? ItemType { get; set; }

        /// <summary>
        /// The item name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The unit price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The quantity of the item being purchased as part of the current transaction.
        /// </summary>
        public int Quantity { get; set; }
    }
}
