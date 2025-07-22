using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public interface IActionContext : IContext
    {
        ActionType ActionType { get; init; }
        bool AuthAction { get; init; }
        bool AutoVoid { get; init; }
        bool Capture { get; init; }
        bool CardAuth { get; init; }
        bool PreAuth { get; init; }
        bool PrimaryAction { get; init; }
        bool Return { get; init; }
        bool Sale { get; init; }
        bool TimeoutReversal { get; init; }
        bool TransactionAction { get; init; }
        bool Void { get; init; }

        // TODO: find a better name for this to indicate that it is any of the three
        //       types of voids
        public bool VoidAction { get; init; }
    }
}
