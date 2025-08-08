using Amazon.SQS.Model;

namespace Payment.Service
{
    /// <summary>
    /// Describes the values required to process a transaction through the payment service.
    /// </summary>
    /// <typeparam name="TTransaction">The type of the transaction object that will be processed.</typeparam>
    public interface IProcessingValues<TTransaction> where TTransaction : class
    {
        /// <summary>
        /// The results of transaction validation.
        /// </summary>
        bool HasValidTransaction { get; }

        /// <summary>
        /// The raw message dequeued from SQS.
        /// </summary>
        Message Message { get; }

        /// <summary>
        /// An internal unique identifier for the task that will process the transaction.
        /// </summary>
        uint TaskId { get; }

        /// <summary>
        /// The time at which the transaction was dequeued for processing.
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// A unique identifier for the transaction.
        /// </summary>
        string? Token { get; }

        /// <summary>
        /// The object describing the transaction to be processed.
        /// </summary>
        TTransaction? Transaction { get; }
    }

    /// <summary>
    /// Describes the values required to process a transaction through the payment service.
    /// </summary>
    /// <typeparam name="TTransaction">The type of the transaction object that will be processed.</typeparam>
    public class ProcessingValues<TTransaction> : IProcessingValues<TTransaction> where TTransaction : class
    {
        /// <summary>
        /// The results of transaction validation.
        /// </summary>
        public bool HasValidTransaction { get; init; } = false;

        /// <summary>
        /// The raw message dequeued from SQS.
        /// </summary>
        public required Message Message { get; init; }

        /// <summary>
        /// An internal unique identifier for the task that will process the transaction.
        /// </summary>
        public uint TaskId { get; init; }

        /// <summary>
        /// The time at which the transaction was dequeued for processing.
        /// </summary>
        public DateTime Timestamp { get; init; }

        /// <summary>
        /// A unique identifier for the transaction.
        /// </summary>
        public string? Token { get; init; }

        /// <summary>
        /// The object describing the transaction to be processed.
        /// </summary>
        public TTransaction? Transaction { get; init; }
    }
}
