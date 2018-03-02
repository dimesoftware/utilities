using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// Extensions on top of the generic <see cref="List{T}"/> class
    /// </summary>    
    public static class ListExtensions
    {
        /// <summary>
        /// Adds an object to the end of the System.Collections.Generic.List`1, but only if the value is not null. 
        /// </summary>
        /// <param name="collection">The current collection</param>       
        /// <param name="value">The object to be added to the end of the System.Collections.Generic.List`1. 
        /// The value can be null for reference types but it will be ignored.</param>
        public static void AddIfNotNull<T>(this List<T> collection, T value)
        {
            if (value != null)
                collection.Add(value);
        }

        /// <summary>
        /// Adds an object to the end of the System.Collections.Generic.List`1, but only if the value meets the predicate. 
        /// </summary>
        /// <param name="collection">The current collection</param>       
        /// <param name="value">The object to be added to the end of the System.Collections.Generic.List`1. 
        /// The value can be null for reference types but it will be ignored.</param>      
        /// <param name="predicate">The filter to meet before it is allowed to the collection</param>
        public static void AddIf<T>(this List<T> collection, T value, Func<T, bool> predicate)
        {
            if (predicate(value))
                collection.Add(value);
        }
    }
}