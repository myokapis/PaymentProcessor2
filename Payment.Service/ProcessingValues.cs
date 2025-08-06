using Amazon.SQS.Model;

namespace Payment.Service
{
    public interface IProcessingValues<TTransaction> where TTransaction : class
    {
        bool HasValidTransaction { get; }
        Message Message { get; }
        uint TaskId { get; }
        DateTime Timestamp { get; }
        string? Token { get; }
        TTransaction? Transaction { get; }
    }

    public class ProcessingValues<TTransaction> : IProcessingValues<TTransaction> where TTransaction : class
    {
        public bool HasValidTransaction { get; init; } = false;
        public required Message Message { get; init; }
        public uint TaskId { get; init; }
        public DateTime Timestamp { get; init; }
        public string? Token { get; init; }
        public TTransaction? Transaction { get; init; }
    }
}
