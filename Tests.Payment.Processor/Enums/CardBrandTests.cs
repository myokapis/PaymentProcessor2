using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class CardBrandTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, CardBrand expectedValue)
        {
            var parsedValue = CardBrand.Unknown.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, CardBrand.Unknown },
                new object?[] { "", CardBrand.Unknown },
                new object?[] { "amex", CardBrand.Amex },
                new object?[] { "AMEX", CardBrand.Amex },
                new object?[] { "diners_club", CardBrand.DinersClub },
                new object?[] { "DINERS_CLUB", CardBrand.DinersClub },
                new object?[] { "discover", CardBrand.Discover },
                new object?[] { "DISCOVER", CardBrand.Discover },
                new object?[] { "jcb", CardBrand.JCB },
                new object?[] { "JCB", CardBrand.JCB },
                new object?[] { "master_card", CardBrand.MasterCard },
                new object?[] { "MASTER_CARD", CardBrand.MasterCard },
                new object?[] { "union_pay", CardBrand.UnionPay },
                new object?[] { "UNION_PAY", CardBrand.UnionPay },
                new object?[] { "visa", CardBrand.Visa },
                new object?[] { "VISA", CardBrand.Visa }
            };
        }
    }
}
