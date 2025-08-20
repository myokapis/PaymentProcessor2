using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context.V1
{
    /// <summary>
    /// Provides attributes pertaining to a transaction's participation in
    /// a payment plan or card on file transaction.
    /// </summary>
    public interface ICardOnFileContext : IContext
    {
        /// <summary>
        /// True if the transaction is a card on file transaction.
        /// </summary>
        bool CardOnFile { get; init; }

        /// <summary>
        /// True if the customer initiated the transaction.
        /// </summary>
        bool CustomerInitiated => !MerchantInitiated;

        /// <summary>
        /// True if the transaction is the first payment in a payment plan.
        /// </summary>
        bool FirstPayment { get; init; }

        /// <summary>
        /// True if the transaction is part of an installment payment plan.
        /// </summary>
        bool InstallmentPayment { get; init; }

        /// <summary>
        /// True if the merchant initiated the transaction.
        /// </summary>
        bool MerchantInitiated { get; init; }

        /// <summary>
        /// True if the transaction is a payment in a multipart payment plan.
        /// </summary>
        bool MultipartPayment { get; init; }

        /// <summary>
        /// True if the transaction is a one time payment.
        /// </summary>
        bool OneTimePayment { get; init; }

        /// <summary>
        /// The payment plan identifier.
        /// </summary>
        string? PaymentPlanId { get; init; }

        /// <summary>
        /// An enumeration describing the payment plan type.
        /// </summary>
        PaymentPlanType PaymentPlanType { get; init; }

        // TODO: see if this duplicates a field in another context
        /// <summary>
        /// An enumeration describing the platform from which the transaction was taken.
        /// </summary>
        Platform Platform { get; init; }

        /// <summary>
        /// True if the transaction is a payment in a recurring payment plan.
        /// </summary>
        bool RecurringPayment { get; init; }

        /// <summary>
        /// True if the card should be saved as part of the transaction.
        /// </summary>
        bool SaveCard { get; init; }

        /// <summary>
        /// True if the transaction is a scheduled payment.
        /// </summary>
        bool ScheduledPayment { get; init; }

        /// <summary>
        /// The current transaction's sequence (payment number) in a multipart payment plan.
        /// </summary>
        int? SequenceIndicator { get; init; }

        /// <summary>
        /// The total number of scheduled payments in the payment plan.
        /// </summary>
        int? TotalPaymentCount { get; init; }
    }
}
