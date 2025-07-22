namespace Payment.Processor.Transaction.Model
{
    public class PaymentPlan
    {
        public string? PaymentPlanId { get; set; }
        public string? PaymentPlanType { get; set; }
        public int? SequenceIndicator { get; set; }
        public int? TotalPaymentCount { get; set; }
    }
}
