using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dime.Utilities.Core.Tests
{
    public class ObjectUtilitiesTests
    {
        [Fact]
        [Trait("Category", "Object")]
        public void IsNullable_ObjectIsNull_ReturnsTrue()
        {
            Customer customer = null;
            Assert.True(customer.IsNullable());
        }

        [Fact]
        [Trait("Category", "Object")]
        public void IsNullable_ObjectIsNotNull_ReturnsTrue()
        {
            Customer customer = new Customer();
            Assert.True(customer.IsNullable());
        }

        [Fact]
        [Trait("Category", "Object")]
        public void IsNullable_NullableIntIsNotNull_ReturnsTrue()
        {
            int? customerId = 1;
            Assert.True(customerId.IsNullable());
        }

        [Fact]
        [Trait("Category", "Object")]
        public void IsNullable_NullableIntIsNull_ReturnsTrue()
        {
            int? customerId = null;
            Assert.True(customerId.IsNullable());
        }

        [Fact]
        [Trait("Category", "Object")]
        public void IsNot_ReturnsTrue()
        {
            Customer customer = new Customer();
            Assert.True(customer.IsNot<string>());
        }
    }
}