using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    public class TransactionContext<TEnvelope, TAttributes> : // ITransactionContext,
                                                              ITransactionContext<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        public required CardContext CardContext { get; set; }
        public required CardOnFileContext CardOnFileContext { get; set; }
        public required Details Details { get; set; }
        // TODO: see if this really needs to be an accessible message.
        //       Couldn't implementers add accessibility to their envelope if they needed it?
        public TEnvelope? Envelope { get; set; }
        public required Merchant Merchant { get; set; }
        public required TAttributes ProcessorAttributes { get; set; }
        public required ReaderContext ReaderContext { get; set; }
        public required ActionContext ActionContext { get; set; }

        // TODO: simplify this generic nonsense
        //IEnvelope? ITransactionContext.Envelope { get => Envelope; set => Envelope = (TEnvelope?)value; }

        //IEnvelope<TEnvelope>? ITransactionContext<TEnvelope, TAttributes>.Envelope
        //{ 
        //    get => Envelope; 
        //    set => Envelope = (TEnvelope?)value; 
        //}

        //IProcessorAttributes ITransactionContext.ProcessorAttributes
        //{
        //    get => ProcessorAttributes;
        //    set => ProcessorAttributes = (TAttributes)value;
        //}
    }
}
