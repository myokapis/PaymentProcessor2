using Payment.Processor.Enums;
using Payment.Processor.Extensions;
using Payment.Processor.Transaction.Context.V1;
using Payment.Processor.Transaction.Model.V1;

namespace Payment.Processor.Builders.V1
{
    /// <summary>
    /// Builds a card on file context.
    /// </summary>
    public class CardOnFileContextBuilder : ICardOnFileContextBuilder
    {
        /// <summary>
        /// Creates an instance of the card on file context builder.
        /// </summary>
        public CardOnFileContextBuilder() { }

        /// <summary>
        /// Builds a card on file context from a transaction model and action context.
        /// </summary>
        /// <param name="transaction">The transaction model providing the data.</param>
        /// <param name="actionContext">The action context providing the data.</param>
        /// <returns>An instance of a card on file context corresponding to the data in the transaction model and action context.</returns>
        public CardOnFileContext Build(ITransactionModel transaction, IActionContext actionContext)
        {
            var metadata = transaction.Details.Metadata;
            var sequenceIndicator = SequenceIndicator(transaction);
            var platform = Platform.Unknown.Parse(metadata?.Platform);
            var paymentPlanType = PaymentPlanType.None.Parse(metadata?.PaymentPlan?.PaymentPlanType);

            return new CardOnFileContext()
            {
                CardOnFile = CardOnFile(transaction, actionContext),
                FirstPayment = (sequenceIndicator == 1),
                InstallmentPayment = paymentPlanType == PaymentPlanType.Installment,
                MerchantInitiated = platform == Platform.ScheduledPayment,
                MultipartPayment = paymentPlanType.OneOf(PaymentPlanType.Installment, PaymentPlanType.Recurring),
                OneTimePayment = paymentPlanType == PaymentPlanType.Single,
                PaymentPlanId = metadata?.PaymentPlan?.PaymentPlanId,
                PaymentPlanType = paymentPlanType,
                Platform = platform,
                RecurringPayment = paymentPlanType == PaymentPlanType.Recurring,
                SaveCard = SaveCard(transaction, actionContext),
                ScheduledPayment = platform == Platform.ScheduledPayment,
                SequenceIndicator = SequenceIndicator(transaction),
                TotalPaymentCount = TotalPaymentCount(transaction)
            };
        }

        protected bool CardOnFile(ITransactionModel transaction, IActionContext actionContext)
        {
            if (actionContext.Return) return false;
            if (SaveCard(transaction, actionContext)) return false;
            // TODO: see if the CardOnFile attribute is still being sent by Gateway
            return !string.IsNullOrWhiteSpace(transaction.Details.CardOnFile?.ToString());
        }

        protected bool SaveCard(ITransactionModel transaction, IActionContext actionContext)
        {
            if (actionContext.CardAuth) return true;

            var metadata = transaction.Details.Metadata;
            var saveCard = metadata?.Customer?.SaveCard;

            return (saveCard != null);
        }

        protected int? SequenceIndicator(ITransactionModel transaction)
        {
            var metadata = transaction.Details.Metadata;
            var value = metadata?.PaymentPlan?.SequenceIndicator?.ToString();

            if (!int.TryParse(value, out var sequenceIndicator))
                return null;

            return sequenceIndicator > 0 ? sequenceIndicator : null;
        }

        protected int? TotalPaymentCount(ITransactionModel transaction)
        {
            var metadata = transaction.Details.Metadata;
            var value = metadata?.PaymentPlan?.TotalPaymentCount?.ToString();

            if (!int.TryParse(value, out var totalPaymentCount))
                return null;

            return totalPaymentCount > 0 ? totalPaymentCount : null;
        }
    }
}
