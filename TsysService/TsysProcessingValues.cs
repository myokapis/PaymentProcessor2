using Payment.Service;
using TsysProcessor.Transaction.Model;

namespace TsysService
{
    /// <summary>
    /// Describes a TSYS variant of the processsing values that uses a TsysTransaction.
    /// </summary>
    public class TsysProcessingValues : ProcessingValues<TsysTransaction>
    { }
}
