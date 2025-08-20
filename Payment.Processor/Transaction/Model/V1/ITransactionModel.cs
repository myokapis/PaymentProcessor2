using Payment.Processor.Transaction.Context.V1;

namespace Payment.Processor.Transaction.Model.V1
{
    /// <summary>
    /// Describes the basic behavior of a transaction.
    /// </summary>
    public interface ITransactionModel
    {
        Details Details { get; init; }

        Merchant Merchant { get; init; }

       IProcessorAttributes ProcessorAttributes { get; init; }
    }

    /// <summary>
    /// Describes the basic behavior of a transaction that uses a specific type of processor attributes.
    /// </summary>
    /// <typeparam name="TAttributes"></typeparam>
    public interface ITransactionModel<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        TAttributes ProcessorAttributes { get; init; }
    }
}
