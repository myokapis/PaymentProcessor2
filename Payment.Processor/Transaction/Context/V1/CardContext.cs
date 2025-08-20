using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context.V1
{
    /// <summary>
    /// Describes a card and provides useful derived attributes.
    /// </summary>
    public class CardContext : ICardContext
    {
        /// <summary>
        /// The address associated with the card.
        /// </summary>
        public string? Address { get; init; }

        /// <summary>
        /// True if at least one piece of AVS data is available.
        /// </summary>
        public bool AvsPresent { get; init; } = false;

        /// <summary>
        /// An enumeration value representing the card brand.
        /// </summary>
        public required CardBrand Brand { get; init; }

        /// <summary>
        /// True if the cardholder is considered present during the transaciton.
        /// </summary>
        public required bool CardholderPresent { get; init; }

        /// <summary>
        /// True if the card is considered present during the transaction.
        /// </summary>
        public required bool CardPresent { get; init; }

        /// <summary>
        /// The verification code from the card.
        /// </summary>
        public string? CVV { get; init; }

        /// <summary>
        /// The data source that provided the card.
        /// </summary>
        public required DataSource DataSource { get; init; }

        /// <summary>
        /// True if the transaction was taken using an EMV method.
        /// </summary>
        public required bool EMV { get; init; }

        /// <summary>
        /// The expiration month of the card.
        /// </summary>
        public string? ExpirationMonth { get; init; }

        /// <summary>
        /// The expiration year of the card.
        /// </summary>
        public string? ExpirationYear { get; init; }

        /// <summary>
        /// True if the card information was manually keyed for the transaction.
        /// </summary>
        public required bool Keyed { get; init; }

        /// <summary>
        /// The name associated with the card.
        /// </summary>
        public string? Name { get; init; }

        /// <summary>
        /// The card number.
        /// </summary>
        public string? Number { get; init; }

        /// <summary>
        /// An keyed rate enumeration for how the transaction should be processed.
        /// </summary>
        public KeyedRate ProcessAs { get; init; }

        /// <summary>
        /// The service code from the card.
        /// </summary>
        public string? ServiceCode { get; init; }

        /// <summary>
        /// True if the transaction was taken by swiping the card's magnetic stripe.
        /// </summary>
        public required bool Swiped { get; init; }

        /// <summary>
        /// True if the transaction was taken by swiping the card's magnetic stripe
        /// after an EMV capable reader determined that it could not read the card using an EMV method.
        /// </summary>
        public required bool SwipedFallback { get; init; }

        /// <summary>
        /// The card transaction data represented in tag-length-value format.
        /// </summary>
        public string? TLV { get; init; }

        /// <summary>
        /// The track one data read from the card's magnetic stripe.
        /// </summary>
        public string? Track1 { get; init; }

        /// <summary>
        /// The track two data read from the card's magnetic stripe.
        /// </summary>
        public string? Track2 { get; init; }

        /// <summary>
        /// The transaction method used to acquire the card data.
        /// </summary>
        public required TransactionMethod TransactionMethod { get; init; }

        /// <summary>
        /// The zip code associated with the card.
        /// </summary>
        public string? ZipCode { get; init; }
    }
}
