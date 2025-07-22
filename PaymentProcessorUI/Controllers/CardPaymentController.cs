using Microsoft.AspNetCore.Mvc;
using TsysProcessor.Processor;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace PaymentProcessorUI.Controllers
{
    public class CardPaymentController : Controller
    {
        private readonly TsysTransactionRunner workflowRunner;

        public CardPaymentController(TsysTransactionRunner workflowRunner)
        {
            this.workflowRunner = workflowRunner;
        }

        [HttpGet("CardPayment/Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("/cardpayment/payment/")]
        public async Task<IActionResult> Payment([FromBody] TsysTransaction tsysTransaction)
        {
            if (!ModelState.IsValid)
            {
                var x = ModelState.Values.SelectMany(m => m.Errors.Select(e => e.ErrorMessage));
                // TODO: log failure messages

                return BadRequest("Transaction was improperly formatted.");
            }

            workflowRunner.WorkflowContext.Transaction = tsysTransaction;
            await workflowRunner.RunAsync();
            var request = workflowRunner.WorkflowContext.SerializedRequest;

            return Ok(request);
        }
    }
}
