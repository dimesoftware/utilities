namespace System.Reflection
{
    /// <summary>
    ///
    /// </summary>
    public static class ObjectUtilities
    {
        /// <summary>
        /// Verifies if the object is nullable
        /// </summary>
        /// <typeparam name="T">The object's type</typeparam>
        /// <param name="obj">The object to check if it is nullable</param>
        /// <returns>True if it is nullable</returns>
        public static bool IsNullable<T>(this T obj)
        {
            if (obj == null)
                return true;

            Type type = typeof(T);
            if (!type.GetTypeInfo().IsValueType)
                return true;

            if (Nullable.GetUnderlyingType(type) != null)
                return true;

            return false;
        }

        /// <summary>
        /// Verifies if the type of the current matches does not match the requested generic type
        /// </summary>
        /// <typeparam name="T">The type to compare the object to</typeparam>
        /// <param name="obj">The current object</param>
        /// <returns>True if the current object doesn't match <typeparamref name="T"/></returns>
        public static bool IsNot<T>(this object obj)
        {
            return !(obj is T);
        }
    }
}