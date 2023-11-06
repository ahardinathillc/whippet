using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet
{
    /// <summary>
    /// A collection of arguments to pass to <see cref="String.Format(string, object?[])"/> indexed by the order that the parameters must be passed. This class cannot be inherited.
    /// </summary>
    public sealed class StringFormatParameterCollection : SortedList<int, object>, IEnumerable<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringFormatParameterCollection"/> class with no arguments.
        /// </summary>
        public StringFormatParameterCollection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringFormatParameterCollection"/> class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity to set the collection to.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public StringFormatParameterCollection(int capacity)
            : base(capacity)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringFormatParameterCollection"/> class with the specified collection.
        /// </summary>
        /// <param name="collection"><see cref="IDictionary{TKey, TValue}"/> of parameters to initialize the collection with.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public StringFormatParameterCollection(IDictionary<int, object> collection)
            : base(collection)
        { }

        /// <summary>
        /// Gets an array of the values sorted by their index.
        /// </summary>
        /// <returns><see cref="Array"/> of objects sorted by their index values.</returns>
        public object[] ToValueArray()
        {
            return Values.ToArray();
        }

        /// <summary>
        /// Gets an enumerator of all values stored in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> of type <see cref="object"/>.</returns>
        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return Values.GetEnumerator();
        }
    }
}
