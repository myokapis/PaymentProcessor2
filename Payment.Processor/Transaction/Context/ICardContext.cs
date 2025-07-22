using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    interface ICardContext : IContext
    {
        string? Address { get; set; }
        bool AvsPresent { get; set; }
        CardBrand Brand { get; set; }
        bool CardholderPresent { get; set; }
        bool CardPresent { get; set; }
        string? CVV { get; set; }
        DataSource DataSource { get; set; }
        bool EMV { get; set; }
        string? ExpirationMonth { get; set; }
        string? ExpirationYear { get; set; }
        bool Keyed { get; set; }
        string? Name { get; set; }
        string? Number { get; set; }
        KeyedRate ProcessAs { get; set; }
        string? ServiceCode { get; init; }
        bool Swiped { get; set; }
        bool SwipedFallback { get; set; }
        string? TLV { get; set; }
        string? Track1 { get; set; }
        string? Track2 { get; set; }
        TransactionMethod TransactionMethod { get; set; }
        string? ZipCode { get; set; }
    }
}
