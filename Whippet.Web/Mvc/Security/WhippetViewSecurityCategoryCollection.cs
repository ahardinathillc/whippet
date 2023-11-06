using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a collection of <see cref="WhippetViewSecurityCategory"/> objects with their associated <see cref="WhippetViewProfile"/> objects. This class cannot be inherited.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public sealed class WhippetViewSecurityCategoryCollection : Dictionary<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>, IDictionary<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>, ICollection<KeyValuePair<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>>, IEnumerable<KeyValuePair<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>, IReadOnlyCollection<KeyValuePair<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>>, ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewSecurityCategoryCollection"/> class that is empty and has the default initial capacity.
        /// </summary>
        public WhippetViewSecurityCategoryCollection()
            : base(WhippetViewSecurityCategory.WhippetViewSecurityCategoryEqualityComparer.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewSecurityCategoryCollection"/> class with the specified <see cref="IEnumerable{T}"/> collection.
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetViewSecurityCategory"/> objects and their associated <see cref="WhippetViewProfile"/> objects.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public WhippetViewSecurityCategoryCollection(IEnumerable<KeyValuePair<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>>> collection)
            : base(collection)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewSecurityCategoryCollection"/> class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity to set the collection to.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetViewSecurityCategoryCollection(int capacity)
            : base(capacity)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewSecurityCategoryCollection"/> class with serialized data.
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required to serialize the <see cref="WhippetViewSecurityCategoryCollection"/> instance.</param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the source and destination of the serialized stream associated with the <see cref="WhippetViewSecurityCategoryCollection"/> instance.</param>
        public WhippetViewSecurityCategoryCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Adds the specified <see cref="WhippetViewSecurityCategory"/> and <see cref="WhippetViewProfile"/> objects to the collection. If the category is already present, the values are appended.
        /// </summary>
        /// <param name="category"><see cref="WhippetViewSecurityCategory"/> to add.</param>
        /// <param name="profiles">Associated <see cref="WhippetViewProfile"/> objects.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public new void Add(WhippetViewSecurityCategory category, IEnumerable<WhippetViewProfile> profiles)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                if ((from k in Keys where k.ID.Equals(category.ID) select k).Any())
                {
                    Append(category, profiles);
                }
                else
                {
                    base.Add(category, profiles);
                }
            }
        }

        /// <summary>
        /// Attempts to add the specified <see cref="WhippetViewSecurityCategory"/> and <see cref="WhippetViewProfile"/> objects to the collection. If the category is already present, the values are appended.
        /// </summary>
        /// <param name="category"><see cref="WhippetViewSecurityCategory"/> to add.</param>
        /// <param name="profiles">Associated <see cref="WhippetViewProfile"/> objects.</param>
        /// <returns><see langword="true"/> if the values were successfully added; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public new bool TryAdd(WhippetViewSecurityCategory category, IEnumerable<WhippetViewProfile> profiles)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                bool success = true;

                if ((from k in Keys where k.ID.Equals(category.ID) select k).Any())
                {
                    try
                    {
                        Append(category, profiles);
                    }
                    catch
                    {
                        success = false;
                    }
                }
                else
                {
                    success = base.TryAdd(category, profiles);
                }

                return success;
            }
        }

        /// <summary>
        /// Appends the <see cref="WhippetViewProfile"/> collection associated with the specified <see cref="WhippetViewSecurityCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="WhippetViewSecurityCategory"/> object.</param>
        /// <param name="profiles"><see cref="WhippetViewProfile"/> collection to append.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        public void Append(WhippetViewSecurityCategory category, IEnumerable<WhippetViewProfile> profiles)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else if (profiles == null)
            {
                throw new ArgumentNullException(nameof(profiles));
            }
            {
                WhippetViewSecurityCategory internalCategory = null;

                if (profiles.Any())
                {
                    if (!(from k in Keys where k.ID.Equals(category.ID) select k).Any())
                    {
                        throw new KeyNotFoundException();
                    }
                    else
                    {
                        internalCategory = (from k in Keys where k.ID.Equals(category.ID) select k).First();

                        if (this[internalCategory] == null || !this[internalCategory].Any())
                        {
                            this[internalCategory] = profiles;
                        }
                        else
                        {
                            this[internalCategory] = this[internalCategory].Concat(profiles);
                            this[internalCategory] = new WhippetViewProfileCollection(this[internalCategory].DistinctBy(wvp => wvp.ViewID));
                        }
                    }
                }
            }
        }
    }
}

