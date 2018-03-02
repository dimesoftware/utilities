using System.ComponentModel;

namespace System.Collections.Generic
{
    /// <summary>
    /// Extensions to work with <see cref="IDictionary{TKey, TValue}"/> classes more efficiently.
    /// </summary>
    public static class DictionaryUtilities
    {
        /// <summary>
        /// Wraps an object into a dictionary
        /// </summary>
        /// <param name="source">The object to wrap into a dictionary</param>
        /// <returns>A dictionary with one record</returns>
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        /// <summary>
        /// Wraps an object into a dictionary
        /// </summary>
        /// <param name="source">The object to wrap into a dictionary</param>
        /// <returns>A dictionary with one record</returns>
        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "Unable to convert object to a dictionary. The source object is null.");

            Dictionary<string, T> dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                if (value is T)
                    dictionary.Add(property.Name, (T)value);
            }

            return dictionary;
        }
    }
}