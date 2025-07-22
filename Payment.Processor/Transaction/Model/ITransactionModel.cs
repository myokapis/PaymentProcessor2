namespace Payment.Processor.Transaction.Model
{
    public interface ITransactionModel
    {
        Details Details { get; init; }

        Merchant Merchant { get; init; }

       IProcessorAttributes ProcessorAttributes { get; init; }
    }

    public interface ITransactionModel<TAttributes> where TAttributes : IProcessorAttributes
    {
        TAttributes ProcessorAttributes { get; init; }
    }
}
