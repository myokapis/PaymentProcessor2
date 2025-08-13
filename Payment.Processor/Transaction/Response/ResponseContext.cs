namespace Payment.Processor.Transaction.Response
{
    public class ResponseContext<TTransaction> : IResponseContext<TTransaction>
    {
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

        
        public TTransaction? TimeoutReversalModel { get; init; }
    }
}
