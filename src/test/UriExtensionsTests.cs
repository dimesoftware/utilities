using System;
using Xunit;

namespace Dime.Utilities.Core.Tests
{
    public class UriExtensionsTests
    {
        [Fact]
        [Trait("Category", "Utilities")]
        public void GetSubDomain_ValidUrl_WithSubdomain_ReturnsSubdomain()
        {
            Uri uri = new Uri("http://client1.dimescheduler.com");
            string subdomain = uri.GetSubdomain();

            Assert.True(subdomain == "client1");
        }
    }
}