using Payment.Service;

namespace TsysService
{
    public class TsysQueueServiceConfig : QueueServiceConfig
    {
        /// <summary>
        /// The SQS queue into which transaction results should be enqueued.
        /// </summary>
        public required string AutoVoidQueueUrl { get; init; }

        /// <summary>
        /// The SQS queue into which transaction results should be enqueued.
        /// </summary>
        public required string TimeoutReversalQueueUrl { get; init; }
    }
}
