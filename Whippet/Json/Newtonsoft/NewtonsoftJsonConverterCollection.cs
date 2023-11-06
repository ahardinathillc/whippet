using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Athi.Whippet.Json.Newtonsoft
{
    /// <summary>
    /// Represents a collection of <see cref="JsonConverter"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class NewtonsoftJsonConverterCollection : List<JsonConverter>, IList<JsonConverter>, ICollection<JsonConverter>, IEnumerable<JsonConverter>, IEnumerable, IList, ICollection, IReadOnlyList<JsonConverter>, IReadOnlyCollection<JsonConverter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonConverterCollection"/> class with no arguments.
        /// </summary>
        public NewtonsoftJsonConverterCollection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonConverterCollection"/> class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity to initialize with.</param>
        /// <exception cref="ArgumentOutOfRangeException"
        public NewtonsoftJsonConverterCollection(int capacity)
            : base(capacity)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonConverterCollection"/> class with the specified initial collection.
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection of <see cref="JsonConverter"/> objects to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public NewtonsoftJsonConverterCollection(IEnumerable<JsonConverter> collection)
            : base(collection?.Distinct())
        { }

        /// <summary>
        /// Adds the specified <see cref="JsonConverter"/> object to the collection if it doesn't already exist.
        /// </summary>
        /// <param name="item"><see cref="JsonConverter"/> object to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public new void Add(JsonConverter item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (!Contains(item))
                {
                    base.Add(item);
                }
            }
        }

        /// <summary>
        /// Inserts a <see cref="JsonConverter"/> item at the specified index.
        /// </summary>
        /// <param name="index">Index to insert <paramref name="item"/> at.</param>
        /// <param name="item"><see cref="JsonConverter"/> object to insert.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        public new void Insert(int index, JsonConverter item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (!Contains(item))
                {
                    base.Insert(index, item);
                }
            }
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="List{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">Index at which to insert the collection.</param>
        /// <param name="collection">Collection of <see cref="JsonConverter"/> objects to insert.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        public new void InsertRange(int index, IEnumerable<JsonConverter> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                base.InsertRange(index, new List<JsonConverter>(collection.Where(c => !Contains(c))));
            }
        }

        public static implicit operator JsonConverter[](NewtonsoftJsonConverterCollection collection)
        {
            return (collection == null) ? null : collection.ToArray();
        }
    }
}

