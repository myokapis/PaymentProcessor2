using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public class CardOnFileContext : ICardOnFileContext
    {
        public bool CardOnFile { get; set; } = false;
        public bool CustomerInitiated => !MerchantInitiated;
        public bool FirstPayment { get; set; } = false;
        public bool InstallmentPayment { get; set; } = false;
        public required bool MerchantInitiated { get; set; }
        public bool MultipartPayment { get; set; } = false;
        public bool OneTimePayment { get; set; } = false;
        public string? PaymentPlanId { get; set; }
        public PaymentPlanType PaymentPlanType { get; set; }
        public Platform Platform { get; set; }
        public bool RecurringPayment { get; set; } = false;
        public bool SaveCard {  get; set; } = false;
        public bool ScheduledPayment { get; set; } = false;
        public int? SequenceIndicator { get; set; }
        public int? TotalPaymentCount { get; set; }
    }
}
