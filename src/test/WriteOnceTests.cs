using System;
using System.Threading;
using Xunit;

namespace Dime.Utilities.Core.Tests
{
    public class WriteOnceTests
    {
        [Fact]
        [Trait("Category", "WriteOnce")]
        public void WriteOnce_SetsAndGets_ReturnsInstance()
        {
            WriteOnce<string> txt = new WriteOnce<string> { Value = "Hello world" };
            Assert.True(txt.Value == "Hello world");
            Assert.True(txt.ToString() == "Hello world");
            Assert.True(txt.ValueOrDefault == "Hello world");
            Assert.True((string)txt == "Hello world");
        }

        [Fact]
        [Trait("Category", "WriteOnce")]
        public void WriteOnce_GetsBeforeSets_ThrowsError()
        {
            WriteOnce<string> txt = new WriteOnce<string>();
            Assert.Throws<InvalidOperationException>(() => txt.Value == "Hello world");
        }

        [Fact]
        [Trait("Category", "WriteOnce")]
        public void WriteOnce_SetsTwice_ThrowsError()
        {
            WriteOnce<string> txt = new WriteOnce<string> { Value = "Hello world" };
            Assert.True(txt.Value == "Hello world");
            Assert.Throws<InvalidOperationException>(() => txt.Value = "Hello again");
        }
    }
}
