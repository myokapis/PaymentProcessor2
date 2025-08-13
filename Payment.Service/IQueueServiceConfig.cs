namespace Payment.Service
{
    /// <summary>
    /// Configuration values for a queue service.
    /// </summary>
    public interface IQueueServiceConfig
    {
        /// <summary>
        /// The interval at which health check events occur.
        /// </summary>
        int HealthCheckIntervalMinutes { get; init; }

        /// <summary>
        /// The maximum number of messages to request from SQS when polling a queue.
        /// </summary>
        int MaxMessagesRequested { get; set; }

        /// <summary>
        /// The maximum number of unexpired worker tasks to allow concurrently.
        /// </summary>
        int MaxWorkerTasks { get; init; }

        /// <summary>
        /// The interval during which a message read from an SQS queue should be made
        /// invisible to other requests to the queue.
        /// </summary>
        int MessageVisibilityTimeoutSeconds { get; set; }

        /// <summary>
        /// The interval to wait for SQS queue polling to return at least one message.
        /// </summary>
        /// <remarks>With long polling, the SQS queue will return up to 10 messages if they
        /// are available. If no messages are available, it will wait for the configured
        /// polling timeout and return no messages or return one message if that message
        /// becomes available before the polling timeout.</remarks>
        int QueuePollingSeconds { get; set; }

        /// <summary>
        /// The interval for which processing should be paused when a rate limit condition is detected.
        /// </summary>
        int RateLimitDelayMilliseconds { get; init; }

        /// <summary>
        /// The SQS queue into which transaction results should be enqueued.
        /// </summary>
        string ResultQueueUrl { get; init; }

        /// <summary>
        /// The interval for the main process to wait when shutting down.
        /// </summary>
        /// <remarks>This value should be sufficiently high to allow all background processes to shut down.
        /// The .Net shutdown process occurs in a loop. If more than one background process is running,
        /// the first process receives a shut down signal. The next process only receives a signal once the
        /// first process has terminated. This sequential shut down occurs until all background processes have
        /// terminated or until the shutdown timeout has expired.
        /// </remarks>
        TimeSpan ShutdownTimeout { get; init; }

        /// <summary>
        /// The interval after which a worker task is automatically considered to be expired.
        /// </summary>
        /// <remarks>The worker service does not retain a handle to the worker tasks. Nor does
        /// it await completion. Transaction processing has built in timeouts that should
        /// terminate the worker tasks naturally if communication with the processor runs long.
        /// Worker tasks clean up after themselves; however, there is a fail-safe cleanup process
        /// within the worker service that uses the task expiration value to remove any tasks
        /// that fail to clean up after themselves.</remarks>
        int TaskExpirationSeconds { get; init; }

        /// <summary>
        /// The SQS queue from which transaction requests will be dequeued.
        /// </summary>
        string TransactionQueueUrl { get; init; }
    }
}
