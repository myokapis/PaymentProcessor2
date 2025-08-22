using FluentAssertions;
using Moq;
using Payment.Processor.Builders.V1;
using Payment.Processor.Transaction.Context.V1;
using Payment.Processor.Transaction.Model.V1;
using Tests.Payment.Processor.TestHelpers;

namespace Tests.Payment.Processor.Builders
{
    public class TransactionContextBuilderTests
    {
        [Fact]
        public async Task Build()
        {
            var envelope = new TestEnvelope();
            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var expectedContext = GetTransactionContext(transaction, envelope);

            var mockActionContextBuilder = new Mock<IBuilder<ActionContext>>();
            mockActionContextBuilder.Setup(m => m.Build(transaction))
                .Returns(TestContexts.ActionContext);

            var mockCardContextBuilder = new Mock<ICardContextBuilder>();
            mockCardContextBuilder.Setup(m => m.BuildAsync(transaction))
                .Returns(Task.FromResult(TestContexts.CardContext));

            var mockCofContextBuilder = new Mock<ICardOnFileContextBuilder>();
            mockCofContextBuilder.Setup(m => m.Build(transaction, TestContexts.ActionContext))
                .Returns(TestContexts.CardOnFileContext);

            var mockEnvelopeBuilder = new Mock<IBuilder<TestEnvelope>>();
            mockEnvelopeBuilder.Setup(m => m.Build(transaction))
                .Returns(envelope);

            var mockReaderContextBuilder = new Mock<IBuilder<ReaderContext>>();
            mockReaderContextBuilder.Setup(m => m.Build(transaction))
                .Returns(TestContexts.ReaderContext);

            var builder = new TransactionContextBuilder<TestEnvelope, TestProcessorAttributes>(
                mockActionContextBuilder.Object,
                mockCardContextBuilder.Object,
                mockCofContextBuilder.Object,
                mockEnvelopeBuilder.Object,
                mockReaderContextBuilder.Object
            );

            var context = await builder.BuildAsync<TestTransactionContext>(transaction);
            context.Should().BeEquivalentTo(expectedContext);
        }

        private TransactionContext<TestEnvelope, TestProcessorAttributes> GetTransactionContext(ITransactionModel transaction, TestEnvelope testEnvelope)
        {
            return new TransactionContext<TestEnvelope, TestProcessorAttributes>()
            {
                ActionContext = TestContexts.ActionContext,
                CardContext = TestContexts.CardContext,
                CardOnFileContext = TestContexts.CardOnFileContext,
                Details = transaction.Details,
                Envelope = testEnvelope,
                Merchant = transaction.Merchant,
                ProcessorAttributes = (TestProcessorAttributes)transaction.ProcessorAttributes,
                ReaderContext = TestContexts.ReaderContext
            };
        }
    }
}
