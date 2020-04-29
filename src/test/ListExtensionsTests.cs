using System.Collections.Generic;
using Xunit;

namespace Dime.Utilities.Tests
{
    public class ListExtensionsTests
    {
        [Fact]
        [Trait("Category", "List")]
        public void List_AddIfNotNull_ValueIsNull_DoesNotAdd()
        {
            List<Customer> customers = new List<Customer> { new Customer { Id = 1, Name = "Handsome B. Wonderful" } };
            customers.AddIfNotNull(null);

            Assert.True(customers.Count == 1);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_AddIfNotNull_ValueIsNotNull_DoesAdd()
        {
            List<Customer> customers = new List<Customer> { new Customer { Id = 1, Name = "Handsome B. Wonderful" } };
            customers.AddIfNotNull(new Customer() { Id = 2, Name = "Max Power" });

            Assert.True(customers.Count == 2);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_AddIf_ConditionIsTrue_DoesAdd()
        {
            List<Customer> customers = new List<Customer> { new Customer { Id = 1, Name = "Handsome B. Wonderful" } };
            customers.AddIf(new Customer() { Id = 2, Name = "Max Power" }, x => x.Id == 2);

            Assert.True(customers.Count == 2);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_AddIf_ConditionIsFalse_DoesNotAdd()
        {
            List<Customer> customers = new List<Customer> { new Customer { Id = 1, Name = "Handsome B. Wonderful" } };
            customers.AddIf(new Customer() { Id = 2, Name = "Max Power" }, x => x.Id == 3);

            Assert.True(customers.Count == 1);
        }
    }
}