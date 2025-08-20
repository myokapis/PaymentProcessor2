using Payment.Processor.Enums;
using Payment.Processor.Transaction.Context.V1;

namespace Tests.Payment.Processor.TestHelpers
{
    public class TestContexts
    {
        public static ActionContext ActionContext { get; } = new ActionContext() { ActionType = ActionType.Void };

        public static CardContext CardContext { get; } = new CardContext()
        {
            Brand = CardBrand.MasterCard,
            CardholderPresent = true,
            CardPresent = true,
            DataSource = DataSource.Application,
            EMV = true,
            Keyed = false,
            Swiped = false,
            SwipedFallback = false,
            TransactionMethod = TransactionMethod.QuickChip
        };

        public static CardOnFileContext CardOnFileContext { get; } = new CardOnFileContext()
        {
            MerchantInitiated = false
        };

        public static ReaderContext ReaderContext { get; } = new ReaderContext()
        {
            SerialNumber = "9876543",
            Type = ReaderType.B350
        };
    }
}
