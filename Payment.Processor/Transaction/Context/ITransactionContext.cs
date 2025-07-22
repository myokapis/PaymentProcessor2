using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    // TODO: do we need separate plain and generic interfaces for this?
    public interface ITransactionContext<TEnvelope, TAttributes> // : ITransactionContext
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        CardContext CardContext { get; set; }
        Details Details { get; set; }
        //IEnvelope? Envelope { get; set; }
        Merchant Merchant { get; set; }
        //IProcessorAttributes ProcessorAttributes { get; set; }
        ReaderContext ReaderContext { get; set; }
        ActionContext ActionContext { get; set; }

        TEnvelope? Envelope { get; set; }
        TAttributes ProcessorAttributes { get; set; }
    }

    //public interface ITransactionContext
    //{
    //    Card Card { get; set; }
    //    Details Details { get; set; }
    //    //IEnvelope? Envelope { get; set; }
    //    Merchant Merchant { get; set; }
    //    //IProcessorAttributes ProcessorAttributes { get; set; }
    //    Reader Reader { get; set; }
    //    ActionContext ActionContext { get; set; }
    //}
}
