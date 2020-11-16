using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    /// Creates a cluster of dictionaries, accessible as a single dictionary.
    /// Each node in the cluster is a strongly-typed collection and yet each cluster is independent from the other.
    /// This allows for categorizing data without having to modify its underlying data structure.
    /// </summary>
    public class ClusteredDictionary<TKey>
    {
        /// <summary>
        /// The dictionary that gathers lists of objects per <see cref="Crud"/> and <see cref="Type"/>.
        /// It is effectively a two dimensional array but with the major difference that it stores (incompatible) types
        /// </summary>
        private readonly Dictionary<Type, Dictionary<TKey, IEnumerable<object>>> _dict =
            new Dictionary<Type, Dictionary<TKey, IEnumerable<object>>>();

        /// <summary>
        /// Adds the list of items to the bucket of <see cref="crudType"/> for type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="crudType">The type of operation performed on the items</param>
        /// <param name="items">The items to store and gather in the same bucket</param>
        public void Add<T>(TKey crudType, IEnumerable<T> items) where T : class
        {
            // Get the bucket for the requested type
            Dictionary<TKey, IEnumerable<object>> outerDictionary = _dict.GetOrCreate(typeof(T));

            // This is an append operation so only initiate the collection of the key doesn't exist in the dictionary
            outerDictionary[crudType] = outerDictionary.ContainsKey(crudType)
                ? ((IEnumerable<T>)outerDictionary[crudType]).Concat(items).ToList()
                : items;
        }

        /// <summary>
        /// Gets the records of type <typeparamref name="T"/> with operation type <param name="crudType"></param>
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <param name="crudType">The crud types</param>
        /// <returns>Records of <typeparamref name="T"/> with operation type <param name="crudType"></param></returns>
        public IEnumerable<T> Get<T>(TKey crudType) where T : class
        {
            Dictionary<TKey, IEnumerable<object>> outerDictionary = _dict.GetOrCreate(typeof(T));
            return outerDictionary.ContainsKey(crudType)
                ? (outerDictionary[crudType] as IEnumerable<T>)?.ToList() ?? new List<T>()
                : new List<T>();
        }
    }
}