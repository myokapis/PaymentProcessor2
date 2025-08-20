using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Provides attributes pertaining to a transaction's participation in
    /// a payment plan or card on file transaction.
    /// </summary>
    public class CardOnFileContext : ICardOnFileContext
    {
        /// <summary>
        /// True if the transaction is a card on file transaction.
        /// </summary>
        public bool CardOnFile { get; init; } = false;

        /// <summary>
        /// True if the customer initiated the transaction.
        /// </summary>
        public bool CustomerInitiated => !MerchantInitiated;

        /// <summary>
        /// True if the transaction is the first payment in a payment plan.
        /// </summary>
        public bool FirstPayment { get; init; } = false;

        /// <summary>
        /// True if the transaction is part of an installment payment plan.
        /// </summary>
        public bool InstallmentPayment { get; init; } = false;

        /// <summary>
        /// True if the merchant initiated the transaction.
        /// </summary>
        public required bool MerchantInitiated { get; init; }

        /// <summary>
        /// True if the transaction is a payment in a multipart payment plan.
        /// </summary>
        public bool MultipartPayment { get; init; } = false;

        /// <summary>
        /// True if the transaction is a one time payment.
        /// </summary>
        public bool OneTimePayment { get; init; } = false;

        /// <summary>
        /// The payment plan identifier.
        /// </summary>
        public string? PaymentPlanId { get; init; }

        /// <summary>
        /// An enumeration describing the payment plan type.
        /// </summary>
        public PaymentPlanType PaymentPlanType { get; init; }

        // TODO: see if this duplicates a field in another context
        /// <summary>
        /// An enumeration describing the platform from which the transaction was taken.
        /// </summary>
        public Platform Platform { get; init; }

        /// <summary>
        /// True if the transaction is a payment in a recurring payment plan.
        /// </summary>
        public bool RecurringPayment { get; init; } = false;

        /// <summary>
        /// True if the card should be saved as part of the transaction.
        /// </summary>
        public bool SaveCard {  get; init; } = false;

        /// <summary>
        /// True if the transaction is a scheduled payment.
        /// </summary>
        public bool ScheduledPayment { get; init; } = false;

        /// <summary>
        /// The current transaction's sequence (payment number) in a multipart payment plan.
        /// </summary>
        public int? SequenceIndicator { get; init; }

        /// <summary>
        /// The total number of scheduled payments in the payment plan.
        /// </summary>
        public int? TotalPaymentCount { get; init; }
    }
}
