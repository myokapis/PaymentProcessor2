namespace Payment.Processor.Transaction.Context
{
    public interface IEnvelope
    {
        /// <summary>
        /// This property indicates that the envelope is a default, empty envelope.
        /// </summary>
        bool Empty { get; set; }
    }
}
