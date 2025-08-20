using Payment.Processor.Enums;
using Payment.Processor.Extensions;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    /// <summary>
    /// Builds an action context.
    /// </summary>
    public class ActionContextBuilder : IBuilder<ActionContext>
    {
        /// <summary>
        /// Creates an instance of the action context builder.
        /// </summary>
        public ActionContextBuilder()
        { }

        /// <summary>
        /// Builds an action context from a transaction model.
        /// </summary>
        /// <param name="transaction">The transaction model providing the data.</param>
        /// <returns>An instance of an action context corresponding to the data in the transaction model.</returns>
        public ActionContext Build(ITransactionModel transaction)
        {
            var action = transaction.Details.Action;
            var actionType = ActionType.None.Parse(action);

            return new ActionContext()
            {
                ActionType = actionType,
                AuthAction = actionType.OneOf(ActionType.CardAuth, ActionType.PreAuth),
                AutoVoid = (actionType == ActionType.AutoVoid),
                Capture = (actionType == ActionType.Capture),
                CardAuth = CardAuthentication(actionType, transaction.Details),
                PreAuth = (actionType == ActionType.PreAuth),
                PrimaryAction = actionType.OneOf(ActionType.CardAuth, ActionType.PreAuth, ActionType.Sale),
                Return = (actionType == ActionType.Return),
                Sale = (actionType == ActionType.Sale),
                TimeoutReversal = (actionType == ActionType.TimeoutReversal),

                // TODO: rename this to indicate that these are transactions that move money
                TransactionAction = actionType.OneOf(ActionType.Return, ActionType.Sale),

                Void = (actionType == ActionType.Void),
                VoidAction = actionType.OneOf(ActionType.AutoVoid, ActionType.TimeoutReversal, ActionType.Void),
            };
        }

        protected bool CardAuthentication(ActionType actionType, Details transactionDetails)
        {
            if (actionType == ActionType.CardAuth) return true;

            var metadata = transactionDetails.Metadata;
            if (metadata == null) return false;

            return metadata.CardAuthentication && (actionType == ActionType.PreAuth);
        }
    }
}
