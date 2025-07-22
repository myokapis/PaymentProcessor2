using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public class CardContext : ICardContext
    {
        public string? Address { get; set; }
        public bool AvsPresent { get; set; } = false;
        public required CardBrand Brand { get; set; }
        public required bool CardholderPresent { get; set; }
        public required bool CardPresent { get; set; }
        public string? CVV { get; set; }
        public required DataSource DataSource { get; set; }
        public required bool EMV { get; set; }
        public string? ExpirationMonth { get; set; }
        public string? ExpirationYear { get; set; }
        public required bool Keyed { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public KeyedRate ProcessAs { get; set; }
        public string? ServiceCode { get; init; }
        public required bool Swiped { get; set; }
        public required bool SwipedFallback { get; set; }
        public string? TLV { get; set; }
        public string? Track1 { get; set; }
        public string? Track2 { get; set; }
        public required TransactionMethod TransactionMethod { get; set; }
        public string? ZipCode { get; set; }
    }
}
