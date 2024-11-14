using System.Diagnostics.CodeAnalysis;

namespace System
{
    /// <summary>
    /// Represents an attribute for the default display of fields
    /// </summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultDisplayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDisplayAttribute"/> class
        /// </summary>
        /// <param name="name">The name o the attribute</param>
        public DefaultDisplayAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

    }
}