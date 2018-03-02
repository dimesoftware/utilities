using System;
using Xunit;
using static Xunit.Assert;

namespace Dime.Utilities.Core.Tests
{
    public class UriExtensionsTests
    {
        [Theory]
        [Trait("Category", "URI")]
        [InlineData("client1")]
        [InlineData("client-1")]     
        public void GetSubDomain_ValidUrl_WithSubdomain_ReturnsSubdomain(string sub)
        {
            Uri uri = new Uri($"http://{sub}.dimescheduler.com");
            string subdomain = uri.GetSubdomain();  
            True(sub == subdomain);
        }
    }
}