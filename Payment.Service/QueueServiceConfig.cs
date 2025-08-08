namespace Payment.Service
{
    /// <summary>
    /// Configuration values for a queue service.
    /// </summary>
    public class QueueServiceConfig
    {
        /// <summary>
        /// The interval at which health check events occur.
        /// </summary>
        public int HealthCheckIntervalMinutes { get; init; } = 15;

        /// <summary>
        /// The maximum number of messages to request from SQS when polling a queue.
        /// </summary>
        public int MaxMessagesRequested { get; set; } = 10;

        /// <summary>
        /// The maximum number of unexpired worker tasks to allow concurrently.
        /// </summary>
        public int MaxWorkerTasks { get; init; } = 100;

        /// <summary>
        /// The interval during which a message read from an SQS queue should be made
        /// invisible to other requests to the queue.
        /// </summary>
        public int MessageVisibilityTimeoutSeconds { get; set; } = 60;

        /// <summary>
        /// The interval to wait for SQS queue polling to return at least one message.
        /// </summary>
        /// <remarks>With long polling, the SQS queue will return up to 10 messages if they
        /// are available. If no messages are available, it will wait for the configured
        /// polling timeout and return no messages or return one message if that message
        /// becomes available before the polling timeout.</remarks>
        public int QueuePollingSeconds { get; set; } = 20;

        /// <summary>
        /// The interval for which processing should be paused when a rate limit condition is detected.
        /// </summary>
        public int RateLimitDelayMilliseconds { get; init; } = 250;

        /// <summary>
        /// The SQS queue into which transaction results should be enqueued.
        /// </summary>
        public required string ResultQueueUrl { get; init; }

        /// <summary>
        /// The interval for the main process to wait when shutting down.
        /// </summary>
        /// <remarks>This value should be sufficiently high to allow all background processes to shut down.
        /// The .Net shutdown process occurs in a loop. If more than one background process is running,
        /// the first process receives a shut down signal. The next process only receives a signal once the
        /// first process has terminated. This sequential shut down occurs until all background processes have
        /// terminated or until the shutdown timeout has expired.
        /// </remarks>
        public TimeSpan ShutdownTimeout { get; init; } = TimeSpan.FromSeconds(60);

        /// <summary>
        /// The interval after which a worker task is automatically considered to be expired.
        /// </summary>
        /// <remarks>The worker service does not retain a handle to the worker tasks. Nor does
        /// it await completion. Transaction processing has built in timeouts that should
        /// terminate the worker tasks naturally if communication with the processor runs long.
        /// Worker tasks clean up after themselves; however, there is a fail-safe cleanup process
        /// within the worker service that uses the task expiration value to remove any tasks
        /// that fail to clean up after themselves.</remarks>
        public int TaskExpirationSeconds { get; init; } = 60;

        /// <summary>
        /// The SQS queue from which transaction requests will be dequeued.
        /// </summary>
        public required string TransactionQueueUrl { get; init; }
    }
}
