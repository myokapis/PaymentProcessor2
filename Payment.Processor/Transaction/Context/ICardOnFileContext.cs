using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public interface ICardOnFileContext : IContext
    {
        bool CardOnFile { get; set; }
        bool CustomerInitiated => !MerchantInitiated;
        bool FirstPayment { get; set; }
        bool InstallmentPayment { get; set; }
        bool MerchantInitiated { get; set; }
        bool MultipartPayment { get; set; }
        bool OneTimePayment { get; set; }
        string? PaymentPlanId { get; set; }
        PaymentPlanType PaymentPlanType { get; set; }
        Platform Platform { get; set; }
        bool RecurringPayment { get; set; }
        bool SaveCard { get; set; }
        bool ScheduledPayment { get; set; }
        int? SequenceIndicator { get; set; }
        int? TotalPaymentCount { get; set; }
    }
}
