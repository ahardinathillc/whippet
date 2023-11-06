using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a unique set of <see cref="WhippetMvcSecurityTreeEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMvcSecurityTreeEntryCollection : HashSet<WhippetMvcSecurityTreeEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryCollection"/> with the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        public WhippetMvcSecurityTreeEntryCollection()
            : this(WhippetMvcSecurityTreeEntry.WhippetMvcSecurityTreeEntryEqualityComparer.IdOnlyIncludeParent)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryCollection"/> with the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="capacity">Initial capacity to set the collection to.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetMvcSecurityTreeEntryCollection(int capacity)
            : base(capacity, WhippetMvcSecurityTreeEntry.WhippetMvcSecurityTreeEntryEqualityComparer.IdOnlyIncludeParent)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryCollection"/> with the specified <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="equalityComparer"><see cref="IEqualityComparer{T}"/> object used to compare each element in the collection.</param>
        public WhippetMvcSecurityTreeEntryCollection(IEqualityComparer<WhippetMvcSecurityTreeEntry> equalityComparer)
            : base(equalityComparer ?? WhippetMvcSecurityTreeEntry.WhippetMvcSecurityTreeEntryEqualityComparer.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryCollection"/> with the specified <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="equalityComparer"><see cref="IEqualityComparer{T}"/> object used to compare each element in the collection.</param>
        /// <param name="capacity">Initial capacity to set the collection to.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetMvcSecurityTreeEntryCollection(int capacity, IEqualityComparer<WhippetMvcSecurityTreeEntry> equalityComparer)
            : base(capacity, equalityComparer ?? WhippetMvcSecurityTreeEntry.WhippetMvcSecurityTreeEntryEqualityComparer.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryCollection"/> with the specified serialization information.
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object that contains the information required to serialize the <see cref="WhippetMvcSecurityTreeEntryCollection"/> object.</param>
        /// <param name="context">A <see cref="StreamingContext"/> structure that contains the source and destination of the serialized stream associated with the <see cref="WhippetMvcSecurityTreeEntryCollection"/> object.</param>
        public WhippetMvcSecurityTreeEntryCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
