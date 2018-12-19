using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dime.Utilities.Core.Tests
{
    public class DictionaryUtilitiesTests
    {
        [Fact]
        [Trait("Category", "Dictionary")]
        public void ToDictionary_SourceIsNull_ThrowsArgumentNullException()
        {
            Customer cust = null;
            Assert.Throws<ArgumentNullException>(() => cust.ToDictionary());
        }

        [Fact]
        [Trait("Category", "Dictionary")]
        public void ToDictionary_SourceIsNotNull_ConvertsObjectToDictionary()
        {
            Customer cust = new Customer() { Id = 1, Name = "Handsome B. Wonderful" };
            IDictionary<string, object> customerDictionary = cust.ToDictionary();

            Assert.True(customerDictionary.Count == 2);
            Assert.True((string)customerDictionary[nameof(Customer.Name)] == "Handsome B. Wonderful");
            Assert.True((int)customerDictionary[nameof(Customer.Id)] == 1);
        }

        [Fact]
        [Trait("Category", "Dictionary")]
        public void GetOrCreate_NoMatchingKey_Creates()
        {
            IDictionary<string, Customer> customerDictionary = new Dictionary<string, Customer>
            {
                { "Max Power", new Customer { Id = 1, Name = "Max Power" } }
            };

            Customer newCustomer = customerDictionary.GetOrCreate("Handsome B. Wonderful");
            Assert.True(newCustomer.Id == default(int));
            Assert.True(newCustomer.Name == default(string));
        }

        [Fact]
        [Trait("Category", "Dictionary")]
        public void GetOrCreate_MatchingKey_Gets()
        {
            IDictionary<string, Customer> customerDictionary = new Dictionary<string, Customer>
            {
                { "Max Power", new Customer { Id = 1, Name = "Max Power" } },
                { "Handsome B. Wonderful", new Customer { Id = 2, Name = "Handsome B. Wonderful" } }
            };

            Customer newCustomer = customerDictionary.GetOrCreate("Handsome B. Wonderful");
            Assert.True(newCustomer.Id == 2);
            Assert.True(newCustomer.Name == "Handsome B. Wonderful");
        }
    }
}