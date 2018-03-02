using System;

namespace Dime.Utilities
{
    /// <summary>
    /// Extensions on top the <see cref="Uri"/> class.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Gets the subdomain from the uri
        /// </summary>
        /// <param name="uri">The uri to dissect</param>
        /// <returns>The subdomain</returns>
        public static string GetSubdomain(this Uri uri)
        {
            if (uri.HostNameType != UriHostNameType.Dns)
                return null;

            int amountOfNodes = 0;
            int startNode = 0;

            string host = uri.Host;
            string[] nodes = host.Split('.');

            amountOfNodes = nodes.Length;

            if (nodes[0] == "www")
            {
                startNode = 1;
                amountOfNodes -= 1;
            }

            return amountOfNodes >= 2 ? string.Format("{0}", nodes[startNode]) : string.Empty;
        }
    }
}