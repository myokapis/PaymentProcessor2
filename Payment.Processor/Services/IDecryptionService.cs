using Payment.Processor.Transaction.Context.V1;

namespace Payment.Processor.Services
{
    public interface IDecryptionService
    {
        Task<Card> DecryptCardData(string encryptedCardData);
    }
}
