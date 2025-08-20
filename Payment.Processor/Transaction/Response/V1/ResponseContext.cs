namespace Payment.Processor.Transaction.Response.V1
{
    public class ResponseContext<TTransaction> : IResponseContext<TTransaction>
    {
        /// <summary>
        /// A transaction model representing an auto-void request.
        /// </summary>
        public TTransaction? AutoVoidModel { get; init; }

        /// <summary>
        /// Indicates if the transaction must be automatically voided.
        /// </summary>
        /// <remarks>This property only applies to expired transactions and partial approvals.
        /// It is not true for the timeout reversal use case.</remarks>
        public bool RequiresVoiding { get; init; }

        /// <summary>
        /// Indicates if the transaction must be voided due to a timeout.
        /// </summary>
        public bool RequiresTimeoutReversal { get; init; }

        /// <summary>
        /// A transaction model representing a timeout reversal request.
        /// </summary>
        public TTransaction? TimeoutReversalModel { get; init; }
    }
}
