using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context.V1
{
    /// <summary>
    /// Describes the properties of an action context.
    /// </summary>
    public interface IActionContext : IContext
    {
        /// <summary>
        /// An enumeration value representing the action.
        /// </summary>
        ActionType ActionType { get; init; }

        /// <summary>
        /// True is the action is an authorization.
        /// </summary>
        bool AuthAction { get; init; }

        /// <summary>
        /// True if the action is an automatic void.
        /// </summary>
        bool AutoVoid { get; init; }

        /// <summary>
        /// True if the action is a capture.
        /// </summary>
        bool Capture { get; init; }

        /// <summary>
        /// True if the action is a card authorization.
        /// </summary>
        bool CardAuth { get; init; }

        /// <summary>
        /// True if the action is an authorization to hold funds but not capture the funds.
        /// </summary>
        bool PreAuth { get; init; }

        /// <summary>
        /// True if the action does not involve a modification to an existing transaction.
        /// </summary>
        bool PrimaryAction { get; init; }

        /// <summary>
        /// True if the action is a return or refund.
        /// </summary>
        bool Return { get; init; }

        /// <summary>
        /// True if the action is a sale.
        /// </summary>
        bool Sale { get; init; }

        /// <summary>
        /// True if the action is a timeout reversal.
        /// </summary>
        bool TimeoutReversal { get; init; }

        /// <summary>
        /// True if the action will result in moving money.
        /// </summary>
        bool TransactionAction { get; init; }

        /// <summary>
        /// True if the action voids an existing transaction but is not a system initiated reversal.
        /// </summary>
        bool Void { get; init; }

        // TODO: find a better name for this to indicate that it is any of the three
        //       types of voids
        /// <summary>
        /// True if the action is one of those that voids an existing transaction.
        /// </summary>
        public bool VoidAction { get; init; }
    }
}
