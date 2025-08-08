using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Describes the payment processing action used in a transaction.
    /// </summary>
    public class ActionContext : IActionContext
    {
        /// <summary>
        /// An enumeration value representing the action.
        /// </summary>
        public required ActionType ActionType { get; init; }

        /// <summary>
        /// True is the action is an authorization.
        /// </summary>
        public bool AuthAction { get; init; }

        /// <summary>
        /// True if the action is an automatic void.
        /// </summary>
        public bool AutoVoid { get; init; }

        /// <summary>
        /// True if the action is a capture.
        /// </summary>
        public bool Capture { get; init; }

        /// <summary>
        /// True if the action is a card authorization.
        /// </summary>
        public bool CardAuth { get; init; }

        /// <summary>
        /// True if the action is an authorization to hold funds but not capture the funds.
        /// </summary>
        public bool PreAuth { get; init; }

        /// <summary>
        /// True if the action does not involve a modification to an existing transaction.
        /// </summary>
        public bool PrimaryAction { get; init; }

        /// <summary>
        /// True if the action is a return or refund.
        /// </summary>
        public bool Return { get; init; }

        /// <summary>
        /// True if the action is a sale.
        /// </summary>
        public bool Sale { get; init; }

        /// <summary>
        /// True if the action is a timeout reversal.
        /// </summary>
        public bool TimeoutReversal { get; init; }

        /// <summary>
        /// True if the action will result in moving money.
        /// </summary>
        public bool TransactionAction { get; init; }

        /// <summary>
        /// True if the action voids an existing transaction but is not a system initiated reversal.
        /// </summary>
        public bool Void { get; init; }

        // TODO: find a better name for this to indicate that it is any of the three
        //       types of voids
        /// <summary>
        /// True if the action is one of those that voids an existing transaction.
        /// </summary>
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
