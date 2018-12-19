using Xunit;
using Xunit.Sdk;
using static Xunit.Assert;

namespace Dime.Utilities.Core.Tests
{
    public class NumberUtilitiesTests
    {
        [Theory]
        [Trait("Category", "Number")]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NullIfNegative_int_NullsAndNegatives(int? value)
            => True(value.NullIfNegative() == null);

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(1)]
        public void NullIfNegative_int_ZeroesAndPositives(int? value)
            => True(value.NullIfNegative() > 0);

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NullIfNegative_long_NullsAndNegatives(long? value)
            => True(value.NullIfNegative() == null);

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(1)]
        public void NullIfNegative_long_ZeroesAndPositives(long? value)
            => True(value.NullIfNegative() > 0);

        [Theory]
        [Trait("Category", "Number")]
        [InlineData("1", 1)]
        public void ToNullableInt_ValidIntegers(string value, int actualValue)
            => True(value.ToNullableInt() == actualValue);

        [Theory]
        [Trait("Category", "Number")]
        [InlineData("")]
        [InlineData("Hi")]
        [InlineData("15E")]
        public void ToNullableInt_InvalidIntegers(string value)
            => Null(value.ToNullableInt());

        [Theory]
        [Trait("Category", "Number")]
        [InlineData("1", 1)]
        public void ToNullableLong_ValidIntegers(string value, long actualValue)
            => True(value.ToNullableLong() == actualValue);

        [Theory]
        [Trait("Category", "Number")]
        [InlineData("")]
        [InlineData("Hi")]
        [InlineData("15E")]
        public void ToNullableLong_InvalidIntegers(string value)
            => Null(value.ToNullableInt());

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(1)]
        [InlineData(-1)]
        public void GetNullIfZero_Int_NotNull(int? value)
            => NotNull(value.GetNullIfZero());

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(null)]
        public void GetNullIfZero_Int_Null(int? value)
            => Null(value.GetNullIfZero());

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(1)]
        [InlineData(-1)]
        public void GetNullIfZero_Long_NotNull(long? value)
            => NotNull(value.GetNullIfZero());

        [Theory]
        [Trait("Category", "Number")]
        [InlineData(null)]
        public void GetNullIfZero_Long_Null(long? value)
            => Null(value.GetNullIfZero());

        [Fact]
        [Trait("Category", "Number")]
        public void Format()
        {
            Customer customer = new Customer() { Id = 1000 };
            string formattedCustomerId = customer.Id.Format<Customer>(nameof(Customer.Id));
            True(formattedCustomerId == "1.000,0");
        }
    }
}