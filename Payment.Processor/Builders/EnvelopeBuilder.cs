using Payment.Processor.Enums;
using Payment.Processor.Services;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public class EnvelopeBuilder<TEnvelope> : IBuilder<TEnvelope> where TEnvelope : class, IEnvelope, new()
    {
        private readonly IDatabaseService gatewayDataService;

        public EnvelopeBuilder(IDatabaseService gatewayDataService)
        { 
            this.gatewayDataService = gatewayDataService;
        }

        public TEnvelope Build(ITransactionModel transaction)
        {
            var transactionDetails = transaction.Details;
            var actionType = GetActionType(transactionDetails);

            switch (actionType)
            {
                case ActionType.Capture:
                case ActionType.Void:
                    return AssociatedEnvelope(transactionDetails);
                case ActionType.Return:
                    return ReturnEnvelope(transactionDetails);
                case ActionType.Sale:
                    return OriginalEnvelope(transactionDetails);
                default:
                    return DefaultEnvelope();
            }
        }

        protected TEnvelope AssociatedEnvelope(Details transactionDetails)
        {
            var associatedId = transactionDetails.AssociatedId;

            if (associatedId == null)
                throw new ArgumentNullException(nameof(associatedId));

            // TODO: query database and deserialize TEnvelope from Json
            return new TEnvelope();
        }

        protected TEnvelope DefaultEnvelope()
        {
            return new TEnvelope() { Empty = true };
        }

        protected ActionType GetActionType(Details transactionDetails)
        {
            var action = transactionDetails.Action;
            Enum.TryParse<ActionType>(action, true, out var actionType);
            return actionType;
        }

        protected TEnvelope OriginalEnvelope(Details transactionDetails)
        {
            var originalId = transactionDetails.OriginalId;

            if(originalId == null) return DefaultEnvelope();

            // TODO: query database and deserialize TEnvelope from Json
            return new TEnvelope();
        }

        protected TEnvelope ReturnEnvelope(Details transactionDetails)
        {
            var associatedId = transactionDetails.AssociatedId;

            if (associatedId == null) return DefaultEnvelope();

            return AssociatedEnvelope(transactionDetails);
        }
    }
}
