using FluentAssertions;
using Moq;
using Payment.Processor.Builders;
using Payment.Processor.Enums;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;
using Tests.Payment.Processor.TestHelpers;

namespace Tests.Payment.Processor.Builders
{
    public class CardOnFileContextBuilderTests
    {
        [Theory]
        [InlineData(false, "recurring", 3, null, false)]
        [InlineData(false, null, null, "card_auth", false)]
        [InlineData(false, null, null, "details", true)]
        [InlineData(false, null, null, "metadata", false)]
        [InlineData(false, null, null, null, false)]
        [InlineData(true, null, null, null, false)]

        public void CardOnFile(bool isReturn, string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(isReturn, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.CardOnFile.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, true)]
        [InlineData("installment", 2, null, false)]
        [InlineData(null, null, null, false)]
        public void FirstPayment(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.FirstPayment.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, true)]
        [InlineData("recurring", 2, null, false)]
        [InlineData(null, null, null, false)]
        public void InstallmentPayment(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.InstallmentPayment.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, true)]
        [InlineData("recurring", 2, null, true)]
        [InlineData(null, null, null, false)]
        public void MerchantInitiated(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.MerchantInitiated.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, true)]
        [InlineData("recurring", 2, null, true)]
        [InlineData("single", 1, null, false)]
        [InlineData(null, null, null, false)]
        public void MultipartPayment(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.MultipartPayment.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, false)]
        [InlineData("recurring", 2, null, false)]
        [InlineData("single", 1, null, true)]
        [InlineData(null, null, null, false)]
        public void OneTimePayment(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.OneTimePayment.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, "PLAN001")]
        [InlineData("recurring", 2, null, "PLAN001")]
        [InlineData("single", 1, null, "PLAN001")]
        [InlineData(null, null, null, null)]
        public void PaymentPlanId(string? paymentPlanType, int? paymentNumber, string? cardState, string? expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.PaymentPlanId.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, Platform.ScheduledPayment)]
        [InlineData("recurring", 2, null, Platform.ScheduledPayment)]
        [InlineData("single", 1, null, Platform.ScheduledPayment)]
        [InlineData(null, null, null, Platform.VirtualTerminal)]
        public void Platform_(string? paymentPlanType, int? paymentNumber, string? cardState, Platform expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.Platform.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, false)]
        [InlineData("recurring", 2, null, true)]
        [InlineData("single", 1, null, false)]
        [InlineData(null, null, null, false)]
        public void RecurringPayment(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.RecurringPayment.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(null, null, "card_auth", true)]
        [InlineData(null, null, "details", false)]
        [InlineData(null, null, "metadata", true)]
        [InlineData(null, null, null, false)]

        public void SaveCard(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.SaveCard.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 1, null, true)]
        [InlineData("recurring", 2, null, true)]
        [InlineData("single", 1, null, true)]
        [InlineData(null, null, null, false)]
        public void ScheduledPayment(string? paymentPlanType, int? paymentNumber, string? cardState, bool expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.ScheduledPayment.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 3, null, 3)]
        [InlineData("recurring", 2, null, 2)]
        [InlineData("single", 1, null, 1)]
        [InlineData(null, null, null, null)]
        public void SequenceIndicator(string? paymentPlanType, int? paymentNumber, string? cardState, int? expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.SequenceIndicator.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("installment", 3, null, 4)]
        [InlineData("recurring", 2, null, null)]
        [InlineData("single", 1, null, 1)]
        [InlineData(null, null, null, null)]
        public void TotalPaymentCount(string? paymentPlanType, int? paymentNumber, string? cardState, int? expectedValue)
        {
            var transaction = SetupTransaction(paymentPlanType, paymentNumber, cardState);
            var actionContext = SetupActionContext(false, cardState);
            var testBuilder = new CardOnFileContextBuilder();
            var testContext = testBuilder.Build<ActionContext>(transaction, actionContext.Object);
            testContext.TotalPaymentCount.Should().Be(expectedValue);
        }

        #region private methods

        private Mock<IActionContext> SetupActionContext(bool isReturn, string? cardState)
        {
            var saveCard = cardState == "card_auth";
            var actionType = isReturn ? ActionType.Return : saveCard ? ActionType.CardAuth : ActionType.Sale;
            var mock = new Mock<IActionContext>();
            mock.Setup(m => m.ActionType).Returns(actionType);
            mock.Setup(m => m.CardAuth).Returns(saveCard);
            mock.Setup(m => m.Return).Returns(isReturn);
            
            return mock;
        }

        private ITransactionModel SetupTransaction(string? paymentPlanType, int? paymentNumber, string? cardState)
        {
            var detailsAttributes = TransactionHelper.DetailsAttributes;
            var metadata = TransactionHelper.BuildMetadata(TransactionHelper.MetadataAttributes);

            if (paymentPlanType != null && paymentNumber.HasValue)
            {
                int? sequenceIndicator = (paymentPlanType == "single") ? 1 : paymentNumber;
                int? totalPaymentCount = (paymentPlanType == "single") ? 1 :
                    (paymentPlanType == "recurring") ? null : 4;

                metadata.PaymentPlan = new PaymentPlan()
                {
                    PaymentPlanId = "PLAN001",
                    PaymentPlanType = paymentPlanType,
                    SequenceIndicator = sequenceIndicator,
                    TotalPaymentCount = totalPaymentCount
                };

                metadata.Platform = "scheduled_payment";
            }
            
            if (cardState == "metadata") metadata.Customer = new Customer() { SaveCardAlt1 = true };


            if (cardState == "details") detailsAttributes["CardOnFile"] = "true";
            var details = TransactionHelper.BuildDetails(detailsAttributes, metadata, TransactionHelper.DefaultReader);

            return TransactionHelper.BuildTransactionWithDefaults(details);
        }

        #endregion
    }
}
