using System;
using Xunit;

namespace Dime.System.Tests
{
    public class TryParseLongTests
    {
        [Fact]
        public void TryParse_Long_ValidString_ShouldParse()
        {
            string number = "15";
            Assert.True(number.TryParseLong() == 15);
        }

        [Fact]
        public void TryParse_Long_Empty_ShouldReturnZero()
        {
            string number = string.Empty;
            Assert.True(number.TryParseLong() == 0);
        }

        [Fact]
        public void TryParse_Long_Null_ShouldReturnZero()
        {
            string number = null;
            Assert.True(number.TryParseLong() == 0);
        }

        [Fact]
        public void TryParse_Long_InvalidString_ShouldReturnZero()
        {
            string number = "fifteen";
            Assert.True(number.TryParseLong() == 0);
        }

        [Fact]
        public void ToNullable_Long_InvalidString_ShouldReturnNull()
        {
            string number = "fifteen";
            Assert.True(number.ToNullableLong() == null);
        }

        [Fact]
        public void ToNullable_Long_Null_ShouldReturnNull()
        {
            string number = null;
            Assert.True(number.ToNullableLong() == null);
        }
    }
}