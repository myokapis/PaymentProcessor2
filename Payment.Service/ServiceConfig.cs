namespace Payment.Service
{
    public class ServiceConfig
    {
        public int HealthCheckIntervalMinutes { get; init; } = 15;
        public int MaxMessagesRequested { get; set; } = 10;
        public int MaxWorkerTasks { get; init; } = 100;
        public int MessageVisibilityTimeoutSeconds { get; set; } = 60;
        public int QueuePollingSeconds { get; set; } = 20;
        public int RateLimitDelayMilliseconds { get; init; } = 250;
        public required string ResultQueueUrl { get; init; }
        public TimeSpan ShutdownTimeout { get; init; } = TimeSpan.FromSeconds(60);
        public int TaskExpirationSeconds { get; init; } = 60;
        public required string TransactionQueueUrl { get; init; }
    }
}
