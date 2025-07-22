using Payment.Processor.Transaction.Context;

namespace Payment.Processor.Services
{
    public interface IDecryptionService
    {
        Task<Card> DecryptCardData(string encryptedCardData);
    }
}
