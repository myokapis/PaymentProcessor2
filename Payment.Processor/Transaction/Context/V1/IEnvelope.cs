namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Describes the basic atrributes of an envelope.
    /// </summary>
    public interface IEnvelope
    {
        /// <summary>
        /// This property indicates that the envelope is a default, empty envelope.
        /// </summary>
        bool Empty { get; set; }
    }
}
