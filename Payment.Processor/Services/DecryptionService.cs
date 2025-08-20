using System.Text;
using System.Text.Json;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Payment.Processor.Enums;
using Payment.Processor.Transaction.Context.V1;

namespace Payment.Processor.Services
{
    public class DecryptionService : IDecryptionService
    {
        protected IAmazonKeyManagementService kmsClient;

        public DecryptionService(IAmazonKeyManagementService kmsClient)
        {
            this.kmsClient = kmsClient;
        }

        public async Task<Card> DecryptCardData(string encryptedCardData)
        {
            return new Card()
            {
                Brand = "VISA",
                DataSource = "READER",
                ExpirationMonth = "12",
                ExpirationYear = "27",
                TransactionMethod = "SWIPED"
            };

            //var region = Amazon.RegionEndpoint.GetBySystemName("us-east-1");
            //var client = new AmazonKeyManagementServiceClient(region);

            // TODO: reinstate this after testing
            var bytes = Encoding.UTF8.GetBytes(encryptedCardData);
            var stream = new MemoryStream(bytes);

            var request = new DecryptRequest()
            {
                CiphertextBlob = stream
            };

            var response = await kmsClient.DecryptAsync(request);
            var jsonCard = Encoding.UTF8.GetString(response.Plaintext.ToArray());
            var card = JsonSerializer.Deserialize<Card>(jsonCard);

            if (card == null) throw new Exception("Invalid card data.");

            return card;
        }
    }
}
