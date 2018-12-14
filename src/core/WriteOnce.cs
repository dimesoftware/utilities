namespace System.Threading
{
    /// <summary>
    /// Provides a way of setting a value exactly once.
    /// </summary>
    /// <typeparam name="T">The underlying type</typeparam>
    public sealed class WriteOnce<T>
    {
        private bool _hasValue;

        /// <summary>
        /// Gets or sets  the value
        /// </summary>
        public T Value
        {
            get
            {
                if (!_hasValue)
                    throw new InvalidOperationException("Value not set");

                return ValueOrDefault;
            }
            set
            {
                if (_hasValue)
                    throw new InvalidOperationException("Value already set");

                ValueOrDefault = value;
                _hasValue = true;
            }
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        public T ValueOrDefault { get; private set; }

        /// <summary>
        /// Represents this instance as a string
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
            => _hasValue ? Convert.ToString(ValueOrDefault) : "";

        /// <summary>
        /// Converts this instance to an instance of <typeparamref name="T"/>
        /// </summary>
        /// <param name="value">The value to convert</param>
        public static implicit operator T(WriteOnce<T> value)
            => value.Value;
    }
}