using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dime.Utilities.Tests
{
    public class ListExtensionsTests
    {
        [Fact]
        [Trait("Category", "List")]
        public void List_AddIfNotNull_ValueIsNull_DoesNotAdd()
        {
            List<Customer> customers = [new Customer { Id = 1, Name = "Handsome B. Wonderful" }];
            customers.AddIfNotNull(null);

            Assert.True(customers.Count == 1);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_AddIfNotNull_ValueIsNotNull_DoesAdd()
        {
            List<Customer> customers = [new Customer { Id = 1, Name = "Handsome B. Wonderful" }];
            customers.AddIfNotNull(new Customer() { Id = 2, Name = "Max Power" });

            Assert.True(customers.Count == 2);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_AddIf_ConditionIsTrue_DoesAdd()
        {
            List<Customer> customers = [new Customer { Id = 1, Name = "Handsome B. Wonderful" }];
            customers.AddIf(new Customer() { Id = 2, Name = "Max Power" }, x => x.Id == 2);

            Assert.True(customers.Count == 2);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_AddIf_ConditionIsFalse_DoesNotAdd()
        {
            List<Customer> customers = [new Customer { Id = 1, Name = "Handsome B. Wonderful" }];
            customers.AddIf(new Customer() { Id = 2, Name = "Max Power" }, x => x.Id == 3);

            Assert.True(customers.Count == 1);
        }

        [Fact]
        [Trait("Category", "List")]
        public void List_Split_ShouldSplitList()
        {
            List<Customer> customers =
            [
                new Customer { Id = 1, Name = "Handsome B. Wonderful" },
                new Customer { Id = 2, Name = "Max Power" },
                new Customer { Id = 3, Name = "Hercules Rockefeller" },
                new Customer { Id = 4, Name = "Guy Gadbois" },
                new Customer { Id = 5, Name = "Jacques Clouseau" }
            ];

            (IEnumerable<Customer> smallerThan3, IEnumerable<Customer> largerThan3) = customers.Split(x => x.Id < 3);
            Assert.True(smallerThan3.Count() == 2);
            Assert.True(largerThan3.Count() == 3);
        }
    }
}