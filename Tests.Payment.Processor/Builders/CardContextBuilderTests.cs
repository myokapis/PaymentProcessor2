using System.Reflection.Emit;
using Amazon.Runtime.Telemetry;
using FluentAssertions;
using Moq;
using Payment.Processor.Builders;
using Payment.Processor.Enums;
using Payment.Processor.Services;
using Payment.Processor.Transaction.Context;
using Tests.Payment.Processor.TestHelpers;

namespace Tests.Payment.Processor.Builders
{
    public class CardContextBuilderTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("1456 Way St.")]
        public async Task Address(string? value)
        {
            var attributes = new Dictionary<string, string?>(defaultCardAttributes);
            attributes["Address"] = value;
            var card = SetupCard(attributes);
            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.Address.Should().Be(value);
        }

        [Theory]
        [InlineData(null, null, false)]
        [InlineData("", "", false)]
        [InlineData("1456 Way St.", null, true)]
        [InlineData(null, "86754", true)]
        [InlineData("1456 Way St.", "86754", true)]
        public async Task AvsPresent(string? address, string? zipCode, bool expectedResult)
        {
            var attributes = new Dictionary<string, string?>(defaultCardAttributes);
            attributes["Address"] = address;
            attributes["ZipCode"] = zipCode;
            var card = SetupCard(attributes);
            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.AvsPresent.Should().Be(expectedResult);
        }

        [Fact]
        public async Task Brand()
        {
            var attributes = new Dictionary<string, string?>(defaultCardAttributes);
            var card = SetupCard(attributes);
            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.Brand.Should().Be(CardBrand.Visa);
        }

        [Theory]
        [InlineData("dipped", "iOS", null, true)]
        [InlineData("qc_dipped", "iOS", null, true)]
        [InlineData("swiped", "iOS", null, true)]
        [InlineData("swiped_fallback", "iOS", null, true)]
        [InlineData("tapped", "iOS", null, true)]
        [InlineData("unknown", "virtual_terminal", "retail", false)]
        [InlineData("keyed", "scheduled_payment", "retail", false)]
        [InlineData("keyed", "virtual_terminal", "retail", true)]
        [InlineData("keyed", "virtual_terminal", "moto", false)]
        public async Task CardholderPresent(string transactionMethod, string platform, string? keyedRate, bool expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var merchantAttributes = TransactionHelper.MerchantAttributes;
            merchantAttributes["KeyedRate"] = keyedRate;
            var merchant = TransactionHelper.BuildMerchant(merchantAttributes);

            var metadataAttributes = TransactionHelper.MetadataAttributes;
            metadataAttributes["Platform"] = platform;
            var metadata = TransactionHelper.BuildMetadata(metadataAttributes);

            // TODO: build details and add the metadata to it
            var detailsAttributes = TransactionHelper.DetailsAttributes;
            var details = TransactionHelper.BuildDetails(detailsAttributes, metadata, TransactionHelper.DefaultReader);

            var transaction = TransactionHelper.BuildTransaction(details, merchant);
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.CardholderPresent.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("dipped", true)]
        [InlineData("qc_dipped", true)]
        [InlineData("swiped", true)]
        [InlineData("swiped_fallback", true)]
        [InlineData("tapped", true)]
        [InlineData("unknown", false)]
        public async Task CardPresent(string transactionMethod, bool expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.CardPresent.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("123")]
        public async Task CVV(string? cvv)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["CVV"] = cvv;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.CVV.Should().Be(cvv);
        }

        [Theory]
        [InlineData("application", DataSource.Application)]
        [InlineData("mobile_device", DataSource.MobileDevice)]
        [InlineData("reader", DataSource.Reader)]
        [InlineData("", DataSource.Unknown)]
        public async Task DataSource_(string dataSource, DataSource expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["DataSource"] = dataSource;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.DataSource.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("dipped", true)]
        [InlineData("qc_dipped", true)]
        [InlineData("tapped", true)]
        [InlineData("keyed", false)]
        public async Task EMV(string transactionMethod, bool expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.EMV.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("12")]
        public async Task ExpirationMonth(string? expirationMonth)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["ExpirationMonth"] = expirationMonth;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ExpirationMonth.Should().Be(expirationMonth);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("29")]
        public async Task ExpirationYear(string? expirationYear)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["ExpirationYear"] = expirationYear;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ExpirationYear.Should().Be(expirationYear);
        }

        [Theory]
        [InlineData("tapped", false)]
        [InlineData("keyed", true)]
        public async Task Keyed(string transactionMethod, bool expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.Keyed.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("George Jones")]
        public async Task Name(string? name)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["Name"] = name;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.Name.Should().Be(name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("2914567319350012")]
        public async Task Number(string? number)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["Number"] = number;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.Number.Should().Be(number);
        }

        [Theory]
        [InlineData("tapped", "iOS", null, KeyedRate.Any)]
        [InlineData("unknown", "virtual_terminal", "retail", KeyedRate.Any)]
        [InlineData("keyed", "scheduled_payment", "retail", KeyedRate.MOTO)]
        [InlineData("keyed", "virtual_terminal", "retail", KeyedRate.Retail)]
        [InlineData("keyed", "virtual_terminal", "moto", KeyedRate.MOTO)]
        public async Task ProcessAs(string transactionMethod, string platform, string? keyedRate, KeyedRate expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var merchantAttributes = TransactionHelper.MerchantAttributes;
            merchantAttributes["KeyedRate"] = keyedRate ?? "";
            var merchant = TransactionHelper.BuildMerchant(merchantAttributes);

            var metadataAttributes = TransactionHelper.MetadataAttributes;
            metadataAttributes["Platform"] = platform;
            var metadata = TransactionHelper.BuildMetadata(metadataAttributes);

            var detailAttributes = TransactionHelper.DetailsAttributes;
            var details = TransactionHelper.BuildDetails(detailAttributes, metadata, TransactionHelper.DefaultReader);
            var transaction = TransactionHelper.BuildTransaction(details, merchant);

            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ProcessAs.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("602")]
        public async Task ServiceCode(string? serviceCode)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["ServiceCode"] = serviceCode;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ServiceCode.Should().Be(serviceCode);
        }

        [Theory]
        [InlineData("dipped", false)]
        [InlineData("swiped", true)]
        [InlineData("swiped_fallback", false)]
        [InlineData("keyed", false)]
        public async Task Swiped(string transactionMethod, bool expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.Swiped.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("dipped", false)]
        [InlineData("swiped", false)]
        [InlineData("swiped_fallback", true)]
        [InlineData("keyed", false)]
        public async Task SwipedFallback(string transactionMethod, bool expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.SwipedFallback.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("9F1A0612345")]
        public async Task TLV(string? tlv)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TLV"] = tlv;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.TLV.Should().Be(tlv);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("B4111111111111113^John/Doe                  ^12296020000123000")]
        public async Task Track1(string? serviceCode)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["ServiceCode"] = serviceCode;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ServiceCode.Should().Be(serviceCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("4111111111111113=1229602123400001230")]
        public async Task Track2(string? serviceCode)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["ServiceCode"] = serviceCode;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ServiceCode.Should().Be(serviceCode);
        }

        [Theory]
        [InlineData(null, TransactionMethod.Unknown)]
        [InlineData("keyed", TransactionMethod.Keyed)]
        [InlineData("swiped", TransactionMethod.Swiped)]
        [InlineData("swiped_fallback", TransactionMethod.SwipedFallback)]
        [InlineData("dipped", TransactionMethod.Dipped)]
        [InlineData("qc_dipped", TransactionMethod.QuickChip)]
        [InlineData("tapped", TransactionMethod.Tapped)]
        [InlineData("token", TransactionMethod.Token)]
        public async Task TransactionMethod_(string? transactionMethod, TransactionMethod expectedResult)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["TransactionMethod"] = transactionMethod;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.TransactionMethod.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("73044")]
        public async Task ZipCode(string? zipCode)
        {
            var cardAttributes = new Dictionary<string, string?>(defaultCardAttributes);
            cardAttributes["ZipCode"] = zipCode;
            var card = SetupCard(cardAttributes);

            var transaction = TransactionHelper.BuildTransactionWithDefaults();
            var decryptionServiceMock = SetupDecryptionService(card);
            var testBuilder = new CardContextBuilder(decryptionServiceMock.Object);
            var cardContext = await testBuilder.BuildAsync(transaction);

            cardContext.ZipCode.Should().Be(zipCode);
        }

        private Card SetupCard(Dictionary<string, string?> attributes)
        {
            return new Card()
            {
                Address = attributes["Address"],
                Brand = attributes["Brand"],
                CVV = attributes["CVV"],
                DataSource = attributes["DataSource"],
                ExpirationMonth = attributes["ExpirationMonth"],
                ExpirationYear = attributes["ExpirationYear"],
                Name = attributes["Name"],
                Number = attributes["Number"],
                ServiceCode = attributes["ServiceCode"],
                TLV = attributes["TLV"],
                Track1 = attributes["Track1"],
                Track2 = attributes["Track2"],
                TransactionMethod = attributes["TransactionMethod"],
                ZipCode = attributes["ZipCode"]
            };
        }

        private Mock<IDecryptionService> SetupDecryptionService(Card card)
        {
            var mock = new Mock<IDecryptionService>();
            mock.Setup(m => m.DecryptCardData(It.IsAny<string>()))
                .Returns(Task.FromResult(card));
            return mock;
        }

        private Dictionary<string, string?> defaultCardAttributes = new Dictionary<string, string?>()
        {
            { "Address", "1456 Way St." },
            { "Brand", "VISA" },
            { "CVV", "123" },
            { "DataSource", "virtual_terminal" },
            { "ExpirationMonth", "12" },
            { "ExpirationYear", "29" },
            { "Name", "John Doe" },
            { "Number", "4111111111111111" },
            { "ServiceCode", "601" },
            { "TLV", "951A" },
            { "Track1", "TRACK1" },
            { "Track2", "TRACK2" },
            { "TransactionMethod", "SALE" },
            { "ZipCode", "76345" }
        };
    }
}
