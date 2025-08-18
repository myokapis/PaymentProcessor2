using FluentAssertions;
using Payment.Processor.Builders;
using Payment.Processor.Enums;
using Payment.Processor.Transaction.Model;
using Tests.Payment.Processor.TestHelpers;

namespace Tests.Payment.Processor.Builders
{
    public class ReaderContextBuilderTests
    {
        [Theory]
        [InlineData(ReaderType.A250, false)]
        [InlineData(ReaderType.B200, true)]
        [InlineData(ReaderType.B250, true)]
        [InlineData(ReaderType.B350, true)]
        [InlineData(ReaderType.B500, true)]
        [InlineData(ReaderType.BTMAG, false)]
        [InlineData(ReaderType.IDTECH, false)]
        [InlineData(ReaderType.M010, true)]
        [InlineData(ReaderType.NO_READER, false)]
        [InlineData(ReaderType.RAMBLER, false)]
        [InlineData(ReaderType.UNENCRYPTED, false)]
        [InlineData(ReaderType.UNKNOWN, false)]
        [InlineData(ReaderType.WALKER, true)]
        public void EmvCapable(ReaderType readerType, bool expectedValue)
        {
            var reader = GetReader(readerType);
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.EmvCapable.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void EmvEnabled(bool emvEnabled)
        {
            var reader = GetReader(ReaderType.B350, emvEnabled: emvEnabled);
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.EmvEnabled.Should().Be(emvEnabled);
        }

        [Theory]
        [InlineData(ReaderType.A250, true)]
        [InlineData(ReaderType.B200, true)]
        [InlineData(ReaderType.B250, true)]
        [InlineData(ReaderType.B350, true)]
        [InlineData(ReaderType.B500, true)]
        [InlineData(ReaderType.BTMAG, true)]
        [InlineData(ReaderType.IDTECH, true)]
        [InlineData(ReaderType.M010, true)]
        [InlineData(ReaderType.NO_READER, false)]
        [InlineData(ReaderType.RAMBLER, true)]
        [InlineData(ReaderType.UNENCRYPTED, true)]
        [InlineData(ReaderType.UNKNOWN, false)]
        [InlineData(ReaderType.WALKER, true)]
        public void MsrCapable(ReaderType readerType, bool expectedValue)
        {
            var reader = GetReader(readerType);
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.MsrCapable.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void MsrEnabled(bool msrEnabled)
        {
            var reader = GetReader(ReaderType.B350, msrEnabled: msrEnabled);
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.MsrEnabled.Should().Be(msrEnabled);
        }

        [Theory]
        [InlineData(ReaderType.A250, false)]
        [InlineData(ReaderType.B200, false)]
        [InlineData(ReaderType.B250, true)]
        [InlineData(ReaderType.B350, true)]
        [InlineData(ReaderType.B500, false)]
        [InlineData(ReaderType.BTMAG, false)]
        [InlineData(ReaderType.IDTECH, false)]
        [InlineData(ReaderType.M010, true)]
        [InlineData(ReaderType.NO_READER, false)]
        [InlineData(ReaderType.RAMBLER, false)]
        [InlineData(ReaderType.UNENCRYPTED, false)]
        [InlineData(ReaderType.UNKNOWN, false)]
        [InlineData(ReaderType.WALKER, false)]
        public void NfcCapable(ReaderType readerType, bool expectedValue)
        {
            var reader = GetReader(readerType);
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.NfcCapable.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void NfcEnabled(bool nfcEnabled)
        {
            var reader = GetReader(ReaderType.B350, nfcEnabled: nfcEnabled);
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.NfcEnabled.Should().Be(nfcEnabled);
        }

        [Theory]
        [InlineData("ABCDEFG", "ABCDEFG")]
        [InlineData("", "8675309")]
        public void SerialNumber(string serialNumber, string expectedSerialNumber)
        {
            var reader = string.IsNullOrWhiteSpace(serialNumber) ? null :
                GetReader(ReaderType.B350, serialNumber: serialNumber);

            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.SerialNumber.Should().Be(expectedSerialNumber);
        }

        [Theory]
        [MemberData(nameof(Readers))]
        public void Type(Reader? reader, ReaderType expectedReaderType)
        {
            var transaction = GetTransaction(reader);
            var builder = new ReaderContextBuilder();
            var context = builder.Build(transaction);
            context.Type.Should().Be(expectedReaderType);
        }

        public static Reader GetReader(ReaderType readerType, bool emvEnabled = true, bool msrEnabled = true, bool nfcEnabled = true, string serialNumber = "")
        {
            var readerAttributes = TransactionHelper.ReaderAttributes;
            readerAttributes["Type"] = readerType.ToString();
            readerAttributes["EmvEnabled"] = emvEnabled.ToString();
            readerAttributes["MsrEnabled"] = msrEnabled.ToString();
            readerAttributes["NfcEnabled"] = nfcEnabled.ToString();
            readerAttributes["SerialNumber"] = serialNumber;

            return TransactionHelper.BuildReader(readerAttributes);
        }

        private ITransactionModel GetTransaction(Reader? reader)
        {
            var details = TransactionHelper.BuildDetails(TransactionHelper.DetailsAttributes, TransactionHelper.DefaultMetadata, reader);
            return TransactionHelper.BuildTransaction(details, TransactionHelper.DefaultMerchant);
        }

        public static IEnumerable<object?[]> Readers()
        {
            var values = Enum.GetValues<ReaderType>()
                .Select(r => new object?[] { GetReader(r), r })
                .ToList();
            values.Add(new object?[] { null, ReaderType.UNKNOWN });

            return values;
        }
    }
}
