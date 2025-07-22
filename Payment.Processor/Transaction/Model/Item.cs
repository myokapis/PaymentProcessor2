using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string? ItemType { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
