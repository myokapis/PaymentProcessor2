using FluentAssertions;
using Payment.Processor.Builders;
using Payment.Processor.Enums;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;
using Tests.Payment.Processor.TestHelpers;

namespace Tests.Payment.Processor.Builders
{
    public class ActionContextBuilderTests
    {
        [Fact]
        public void ActionType_()
        {
            var detailAttributes = TransactionHelper.DetailsAttributes;
            var testBuilder = new ActionContextBuilder();

            foreach (var testActionType in actionTypes)
            {
                detailAttributes["Action"] = testActionType.ToString();
                var details = TransactionHelper.BuildDetailsWithDefaults(detailAttributes);

                var transaction = TransactionHelper.BuildTransactionWithDefaults(details);
                var actionContext = testBuilder.Build(transaction);
                actionContext.ActionType.Should().Be(testActionType);
            }
        }

        [Fact]
        public void AuthAction()
        {
            TestActionGroup((actionContext) => actionContext.AuthAction,
                ActionType.CardAuth, ActionType.PreAuth);
        }

        [Fact]
        public void AutoVoid()
        {
            var actionType = ActionType.AutoVoid;
            TestActionTypes(actionType, (actionContext) => actionContext.AutoVoid);
        }

        [Fact]
        public void Capture()
        {
            var actionType = ActionType.Capture;
            TestActionTypes(actionType, (actionContext) => actionContext.Capture);
        }

        [Fact]
        public void CardAuth()
        {
            var actionType = ActionType.CardAuth;
            TestActionTypes(actionType, (actionContext) => actionContext.CardAuth);
        }

        [Fact]
        public void CardAuth_NoMetadata()
        {
            var testBuilder = new ActionContextBuilder();
            var transaction = SetupTransactionForCardAuth(ActionType.PreAuth, false);
            var actionContext = testBuilder.Build(transaction);

            actionContext.CardAuth.Should().BeFalse();
        }

        [Fact]
        public void CardAuth_MetadataFlagFalse_PreAuth()
        {
            var testBuilder = new ActionContextBuilder();
            var transaction = SetupTransactionForCardAuth(ActionType.PreAuth, false);
            var actionContext = testBuilder.Build(transaction);

            actionContext.CardAuth.Should().BeFalse();
        }

        [Fact]
        public void CardAuth_MetadataFlagTrue_PreAuth()
        {
            var testBuilder = new ActionContextBuilder();
            var transaction = SetupTransactionForCardAuth(ActionType.PreAuth, true);
            var actionContext = testBuilder.Build(transaction);

            actionContext.CardAuth.Should().BeTrue();
        }

        [Fact]
        public void CardAuth_MetadataFlagFalse_NotPreAuth()
        {
            var testBuilder = new ActionContextBuilder();
            var transaction = SetupTransactionForCardAuth(ActionType.Sale, true);
            var actionContext = testBuilder.Build(transaction);

            actionContext.CardAuth.Should().BeFalse();
        }

        [Fact]
        public void CardAuth_MetadataFlagTrue_NotPreAuth()
        {
            var testBuilder = new ActionContextBuilder();
            var transaction = SetupTransactionForCardAuth(ActionType.Sale, true);
            var actionContext = testBuilder.Build(transaction);

            actionContext.CardAuth.Should().BeFalse();
        }

        [Fact]
        public void PreAuth()
        {
            var actionType = ActionType.PreAuth;
            TestActionTypes(actionType, (actionContext) => actionContext.PreAuth);
        }

        [Fact]
        public void PrimaryAction()
        {
            TestActionGroup((actionContext) => actionContext.PrimaryAction,
                ActionType.CardAuth, ActionType.PreAuth, ActionType.Sale);
        }

        [Fact]
        public void Return()
        {
            var actionType = ActionType.Return;
            TestActionTypes(actionType, (actionContext) => actionContext.Return);
        }

        [Fact]
        public void Sale()
        {
            var actionType = ActionType.Sale;
            TestActionTypes(actionType, (actionContext) => actionContext.Sale);
        }

        [Fact]
        public void TimeoutReversal()
        {
            var actionType = ActionType.TimeoutReversal;
            TestActionTypes(actionType, (actionContext) => actionContext.TimeoutReversal);
        }

        [Fact]
        public void TransactionAction()
        {
            TestActionGroup((actionContext) => actionContext.TransactionAction,
                ActionType.Return, ActionType.Sale);
        }

        [Fact]
        public void VoidAction()
        {
            TestActionGroup((actionContext) => actionContext.VoidAction,
                ActionType.AutoVoid, ActionType.TimeoutReversal, ActionType.Void);
        }

        private static ActionType[] actionTypes =
        {
            ActionType.None,
            ActionType.AutoVoid,
            ActionType.BalanceInquiry,
            ActionType.Capture,
            ActionType.CardAuth,
            ActionType.PartialReversal,
            ActionType.PreAuth,
            ActionType.Return,
            ActionType.Sale,
            ActionType.TimeoutReversal,
            ActionType.Void
        };

        private ITransactionModel SetupTransactionForCardAuth(ActionType actionType, bool cardAuthFlag)
        {
            Metadata? metadata = null;

            var metadataAttributes = TransactionHelper.MetadataAttributes;
            metadataAttributes["CardAuthentication"] = cardAuthFlag.ToString();
            metadata = TransactionHelper.BuildMetadata(metadataAttributes);
            
            var detailAttributes = TransactionHelper.DetailsAttributes;
            detailAttributes["Action"] = actionType.ToString();
            var details = TransactionHelper.BuildDetails(detailAttributes, metadata, TransactionHelper.DefaultReader);

            return TransactionHelper.BuildTransactionWithDefaults(details);
        }

        private void TestActionGroup(Func<ActionContext, bool> methodValueFunc, params ActionType[] matchTypes)
        {
            var detailAttributes = TransactionHelper.DetailsAttributes;
            var testBuilder = new ActionContextBuilder();

            foreach (var testActionType in actionTypes)
            {
                detailAttributes["Action"] = testActionType.ToString();
                var details = TransactionHelper.BuildDetailsWithDefaults(detailAttributes);
                var transaction = TransactionHelper.BuildTransactionWithDefaults(details);
                var actionContext = testBuilder.Build(transaction);
                methodValueFunc(actionContext).Should().Be(matchTypes.Any(t => t == testActionType));
            }
        }

        private void TestActionTypes(ActionType actionType, Func<ActionContext, bool> methodValueFunc)
        {
            var detailAttributes = TransactionHelper.DetailsAttributes;
            var testBuilder = new ActionContextBuilder();

            foreach (var testActionType in actionTypes)
            {
                detailAttributes["Action"] = testActionType.ToString();
                var details = TransactionHelper.BuildDetailsWithDefaults(detailAttributes);
                var transaction = TransactionHelper.BuildTransactionWithDefaults(details);
                var actionContext = testBuilder.Build(transaction);
                methodValueFunc(actionContext).Should().Be(testActionType == actionType);
            }
        }
    }
}
