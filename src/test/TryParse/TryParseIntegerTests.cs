using System;
using Xunit;

namespace Dime.System.Tests
{
    public class TryParseIntegerTests
    {
        [Fact]
        public void TryParse_Int_ValidString_ShouldParse()
        {
            string number = "15";
            Assert.True(number.TryParseInt() == 15);
        }

        [Fact]
        public void TryParse_Int_Empty_ShouldReturnZero()
        {
            string number = string.Empty;
            Assert.True(number.TryParseInt() == 0);
        }

        [Fact]
        public void TryParse_Int_Null_ShouldReturnZero()
        {
            string number = null;
            Assert.True(number.TryParseInt() == 0);
        }

        [Fact]
        public void TryParse_Int_InvalidString_ShouldReturnZero()
        {
            string number = "fifteen";
            Assert.True(number.TryParseInt() == 0);
        }

        [Fact]
        public void ToNullable_Int_InvalidString_ShouldReturnNull()
        {
            string number = "fifteen";
            Assert.True(number.ToNullableInt() == null);
        }

        [Fact]
        public void ToNullable_Int_Null_ShouldReturnNull()
        {
            string number = null;
            Assert.True(number.ToNullableInt() == null);
        }
    }
}