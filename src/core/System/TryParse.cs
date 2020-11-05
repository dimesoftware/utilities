namespace System
{
    public static class TryParse
    {
        /// <summary>
        /// Tries to parse the string into an integer.
        /// </summary>
        /// <param name="value">The text to parse</param>
        /// <returns>An integer</returns>
        public static int TryParseInt(this string value)
            => string.IsNullOrEmpty(value) ? 0 : int.TryParse(value, out int i) ? i : 0;

        /// <summary>
        /// Tries to parse the string into a long.
        /// </summary>
        /// <param name="value">The text to parse</param>
        /// <returns>A long</returns>
        public static long TryParseLong(this string value)
            => string.IsNullOrEmpty(value) ? 0 : long.TryParse(value, out long i) ? i : 0;

        /// <summary>
        /// Tries to parse the string into a nullable integer.
        /// </summary>
        /// <param name="value">The text to parse</param>
        /// <returns>A nullable integer</returns>
        public static int? ToNullableInt(this string value)
            => int.TryParse(value, out int i) ? (int?)i : null;

        /// <summary>
        /// Tries to parse the string into a nullable long.
        /// </summary>
        /// <param name="value">The text to parse</param>
        /// <returns>A nullable long</returns>
        public static long? ToNullableLong(this string value)
            => long.TryParse(value, out long i) ? (long?)i : null;
    }
}