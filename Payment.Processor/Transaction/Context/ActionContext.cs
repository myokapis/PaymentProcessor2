using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public class ActionContext : IActionContext // <ActionContext>
    {
        public required ActionType ActionType { get; init; }
        public bool AuthAction { get; init; }
        public bool AutoVoid { get; init; }
        public bool Capture { get; init; }
        public bool CardAuth { get; init; }
        public bool PreAuth { get; init; }
        public bool PrimaryAction { get; init; }
        public bool Return { get; init; }
        public bool Sale { get; init; }
        public bool TimeoutReversal { get; init; }
        public bool TransactionAction { get; init; }
        public bool Void { get; init; }

        // TODO: find a better name for this to indicate that it is any of the three
        //       types of voids
        public bool VoidAction { get; init; }

        // TODO: expose the original action on the envelope instead
        //       don't want circular dependencies between action and envelope.
        //public bool VoidAuth { get; init; }
        //public bool VoidCapture { get; init; }
        //public bool VoidReturn { get; init; }
        //public bool VoidSale { get; init; }
        //public bool VoidTransaction { get; init; }
    }
}
