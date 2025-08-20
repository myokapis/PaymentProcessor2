namespace Payment.Processor.Transaction.Model.V1
{
    /// <summary>
    /// Describes a payment plan associated with a transaction.
    /// </summary>
    public class PaymentPlan
    {
        /// <summary>
        /// A unique identifier for the payment plan.
        /// </summary>
        public string? PaymentPlanId { get; set; }

        /// <summary>
        /// The type of payment plan.
        /// </summary>
        /// <remarks>Plans are usually one-time, recurring, or installment.</remarks>
        public string? PaymentPlanType { get; set; }

        /// <summary>
        /// The sequence number of the current payment within a series of payments.
        /// </summary>
        public int? SequenceIndicator { get; set; }

        /// <summary>
        /// The total number of payments expected withing the payment plan.
        /// </summary>
        public int? TotalPaymentCount { get; set; }
    }
}
