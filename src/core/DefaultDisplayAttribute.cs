namespace System
{
    /// <summary>
    /// Represents an attribute for the default display of fields
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class DefaultDisplayAttribute : Attribute
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDisplayAttribute"/> class
        /// </summary>
        /// <param name="name">The name o the attribute</param>
        public DefaultDisplayAttribute(string name)
        {
            Name = name;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}