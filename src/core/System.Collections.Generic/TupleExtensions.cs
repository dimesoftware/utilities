using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Generic
{
    public static class TupleExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="tuples"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<TValue> Where<TKey, TValue>(this IEnumerable<Tuple<TKey, TValue>> tuples, TKey value)
            => tuples.Where(x => x.Item1.Equals(value)).Select(x => x.Item2);
    }
}