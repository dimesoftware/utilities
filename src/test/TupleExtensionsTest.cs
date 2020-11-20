using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dime.Utilities.Tests
{
    public class TupleExtensionsTests
    {
        private class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        [Trait("Category", "Tuple")]
        public void TupleExtensions_Where_FiltersTuple()
        {
            IEnumerable<Tuple<int, MyClass>> tuple = new List<Tuple<int, MyClass>>
            {
                new Tuple<int,MyClass>(1, new MyClass { Id = 1 }),
                new Tuple<int,MyClass>(2, new MyClass { Id = 2 }),
                new Tuple<int,MyClass>(2, new MyClass { Id = 3 })
            };

            IEnumerable<MyClass> tuples = tuple.Where(2);
            Assert.True(tuples.Count() == 2);
        }
    }
}
