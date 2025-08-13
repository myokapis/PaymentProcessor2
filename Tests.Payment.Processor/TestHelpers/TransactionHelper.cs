using Payment.Processor.Extensions;
using Payment.Processor.Transaction.Model;

namespace Tests.Payment.Processor.TestHelpers
{
    public static class TransactionHelper
    {
        public static ITransactionModel BuildTransaction(Details details, Merchant merchant)
        {
            return new TransactionModel<TestEnvelope, TestProcessorAttributes>()
            {
                Details = details, // ?? BuildDetails(DetailsAttributes, metadata, reader),
                Merchant = merchant, // ?? BuildMerchant(MerchantAttributes),
                ProcessorAttributes = new TestProcessorAttributes()
            };
        }

        public static ITransactionModel BuildTransactionWithDefaults(Details? details = null, Merchant? merchant = null)
        {
            return new TransactionModel<TestEnvelope, TestProcessorAttributes>()
            {
                Details = details ?? DefaultDetails,
                Merchant = merchant ?? DefaultMerchant,
                ProcessorAttributes = new TestProcessorAttributes()
            };
        }

        //public static ITransactionModel BuildTransactionWithDefaults(
        //    Details? details = null,
        //    Merchant merchant = null,
        //    Metadata? metadata = null,
        //    Reader? reader = null)
        //{
        //    return new TransactionModel<TestProcessorAttributes>()
        //    {
        //        Details = details ?? BuildDetails(DetailsAttributes, metadata, reader),
        //        Merchant = merchant, // ?? BuildMerchant(MerchantAttributes),
        //        ProcessorAttributes = new TestProcessorAttributes()
        //    };
        //}

        public static Details BuildDetails(Dictionary<string, string> detailsAttributes, Metadata? metadata, Reader reader)
        {
            return new Details()
            {
                Action = detailsAttributes["Action"] ?? "sale",
                AssociatedId = detailsAttributes["AssociatedId"],
                CardOnFile = detailsAttributes["CardOnFile"],
                EncryptedCardData = detailsAttributes["EncryptedCardData"],
                Metadata = metadata,
                Reader = reader
            };
        }

        public static Details BuildDetailsWithDefaults(Dictionary<string, string> detailsAttributes)
        {
            return BuildDetails(detailsAttributes, DefaultMetadata, DefaultReader);
        }

        public static Merchant BuildMerchant(Dictionary<string, string> merchantAttributes)
        {
            return new Merchant()
            {
                AccountToken = merchantAttributes["AccountToken"],
                AsMerchantAccountType = merchantAttributes["AsMerchantAccountType"],
                BatchTime = merchantAttributes["BatchTime"],
                Industry = merchantAttributes["Industry"],
                KeyedRate = merchantAttributes["KeyedRate"],
                Name = merchantAttributes["Name"],
                State = merchantAttributes["State"],
                Status = merchantAttributes["Status"],
                TimeZone = merchantAttributes["TimeZone"]
            };
        }

        public static Metadata BuildMetadata(Dictionary<string, string> metadataAttributes)
        {
            return new Metadata()
            {
                 CardAuthentication = false.Parse(metadataAttributes["CardAuthentication"]),
                 Platform = metadataAttributes["Platform"]
            };
        }

        public static Reader BuildReader(Dictionary<string, string> readerAttributes)
        {
            return new Reader()
            {
                SerialNumber = readerAttributes["SerialNumber"],
                Type = readerAttributes["Type"]
            };
        }

        public static Details DefaultDetails => BuildDetails(DetailsAttributes, DefaultMetadata, DefaultReader);
        public static Merchant DefaultMerchant => BuildMerchant(MerchantAttributes);
        public static Metadata DefaultMetadata => BuildMetadata(MetadataAttributes);
        public static Reader DefaultReader => BuildReader(ReaderAttributes);

        public static Dictionary<string, string> DetailsAttributes => new Dictionary<string, string>()
        {
            { "Action", "sale" },
            { "AssociatedId", "" },
            { "CardOnFile", "" },
            { "EncryptedCardData", "" }
        };

        public static Dictionary<string, string> MerchantAttributes => new Dictionary<string, string>()
        {
            { "AccountToken", "acc_123" },
            { "AsMerchantAccountType", "TsysDirect" },
            { "BatchTime", "9:00 pm" },
            { "Industry", "retail" },
            { "KeyedRate", "moto" },
            { "Name", "Some Merchant" },
            { "State", "OK" },
            { "Status", "active" },
            { "TimeZone", "US/Central" }
        };

        public static Dictionary<string, string> MetadataAttributes => new Dictionary<string, string>()
        {
            { "CardAuthentication", "false" },
            { "Platform", "virtual_terminal" }
        };

        public static Dictionary<string, string> ReaderAttributes => new Dictionary<string, string>()
        {
            { "SerialNumber", "8675309" },
            { "Type", "B350" }
        };
    }
}
