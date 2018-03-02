using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dime.Utilities
{
    /// <summary>
    /// Extensions on top of the <see cref="String"/> class
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Returns null if the string is null or empty
        /// </summary>
        /// <param name="str">The string to inspect</param>
        /// <returns>The string if it has a value. Otherwise it will return null.</returns>
        public static string NullIfEmpty(this string str) 
            => string.IsNullOrEmpty(str) ? null : str;

        /// <summary>
        /// Returns null if the string is null or empty
        /// </summary>
        /// <param name="str">The string to inspect</param>
        /// <returns>The string if it has a value. Otherwise it will return null.</returns>
        public static string NullIfEmptyOrWhiteSpace(this string str)
            => string.IsNullOrWhiteSpace(str) ? null : str;

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <param name="forbiddenCharacters"></param>
        /// <returns></returns>        
        public static string RemoveUnwantedCharacters(this string input, IEnumerable<char> forbiddenCharacters)
        {
            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
                if (char.IsDigit(input[i]) || !forbiddenCharacters.Contains(input[i]))
                    builder.Append(input[i]);

            return builder.ToString();
        }

        /// <summary>
        /// Encodes the string to Base64
        /// </summary>
        /// <param name="plainText">The string to encode</param>
        /// <returns>A base64 encode string</returns>
        public static string Base64Encode(this string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decodes the string to Base64
        /// </summary>
        /// <param name="encodedText">The string to decode</param>
        /// <returns>A base64 decoded string</returns>
        public static string Base64Decode(this string encodedText)
        {
            byte[] base64EncodedBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Gets the first non-empty string in the collection
        /// </summary>
        /// <param name="items">The array of strings</param>
        /// <returns>The first string that is not null or empty.</returns>        
        public static string Coalesce(params string[] items) 
            => items.FirstOrDefault(s => !string.IsNullOrEmpty(s));
    }
}