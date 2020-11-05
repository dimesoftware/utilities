using System;
using System.Reflection;
using Xunit;

namespace Dime.Utilities.Tests
{
    public class EnumUtilitiesTests
    {
        [Fact]
        [Trait("Category", "Enum")]
        public void Enum_ToEnum_ValidString_ConvertsToEnum()
        {
            Assert.True("Item0".ToEnum<MockupEnum>() == MockupEnum.Item0);
        }

        [Fact]
        [Trait("Category", "Enum")]
        public void Enum_ToEnum_InvalidString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "InvalidEnumValue".ToEnum<MockupEnum>());
        }

        [Fact]
        [Trait("Category", "Enum")]
        public void Enum_GetDescription_GetsDescriptionAttributeText()
        {
            Assert.True(MockupEnum.Item0.GetDescription() == "Item0Description");
            Assert.True(MockupEnum.Item3.GetDescription() == "");
        }

        [Fact]
        [Trait("Category", "Enum")]
        public void Enum_GetDescription_TypeIsNotEnum_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => 1.GetDescription());
        }

        [Fact]
        [Trait("Category", "Enum")]
        public void Enum_GetValueFromDescription_GetsDescriptionAttributeText()
        {
            Assert.True("Item0Description".GetValueFromDescription<MockupEnum>() == MockupEnum.Item0);
            Assert.True("".GetValueFromDescription<MockupEnum>() == MockupEnum.Item3);
        }
    }
}