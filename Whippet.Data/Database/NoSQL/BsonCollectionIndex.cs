using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Athi.Whippet.Data.Database.NoSQL
{
    /// <summary>
    /// Represents an index of BSON collections indexed by the BSON type. The associated <see cref="string"/> value is the collection name.
    /// </summary>
    public class BsonCollectionIndex : Dictionary<Type, string>, IDictionary<Type, string>, ICollection<KeyValuePair<Type, string>>, IEnumerable<KeyValuePair<Type, string>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<Type, string>, IReadOnlyCollection<KeyValuePair<Type, string>>, ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BsonCollectionIndex"/> class with no arguments.
        /// </summary>
        public BsonCollectionIndex()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BsonCollectionIndex"/> clsas with the specified collection.
        /// </summary>
        /// <param name="entries">Collection of entries to initialize the collection with.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public BsonCollectionIndex(IEnumerable<KeyValuePair<Type, string>> entries)
            : base(entries)
        { }
    }
}

