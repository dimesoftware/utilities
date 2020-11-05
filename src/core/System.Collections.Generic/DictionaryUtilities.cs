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
            => source.ToDictionary<object>();

        /// <summary>
        /// Wraps an object into a dictionary
        /// </summary>
        /// <param name="source">The object to wrap into a dictionary</param>
        /// <returns>A dictionary with one record</returns>
        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                throw new ArgumentNullException("Unable to convert object to a dictionary. The source object is null.");

            Dictionary<string, T> dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                if (value is T variable)
                    dictionary.Add(property.Name, variable);
            }

            return dictionary;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : new()
        {
            if (dict.TryGetValue(key, out var val))
                return val;

            val = new TValue();
            dict.Add(key, val);

            return val;
        }
    }
}