using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Athi.Whippet.Collections.Extensions;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Represents a unique set of <see cref="ICategory"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class CategoryCollection : HashSet<ICategory>, ICollection<ICategory>, IEnumerable<ICategory>, IReadOnlyCollection<ICategory>, IReadOnlySet<ICategory>, ISet<ICategory>, IDeserializationCallback, ISerializable, IEquatable<CategoryCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCollection"/> class with no arguments.
        /// </summary>
        public CategoryCollection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCollection"/> class with the specified <see cref="IEnumerable{T}"/> collection of <see cref="ICategory"/> objects. 
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection of <see cref="ICategory"/> objects.</param>
        /// <exception cref="DuplicateCategoryException"></exception>
        public CategoryCollection(IEnumerable<ICategory> collection)
            : base(collection)
        {
            if (collection.ContainsDuplicates() || collection.Duplicates(c => c.ID).Any())
            {
                throw new DuplicateCategoryException();
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCollection"/> class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial size of the <see cref="CategoryCollection"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CategoryCollection(int capacity)
            : base(capacity)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCollection"/> class with the serialized data.
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object that contains the information required to serialize the <see cref="CategoryCollection"/> object.</param>
        /// <param name="context">A <see cref="StreamingContext"/> structure that contains the source and destination of the serialized stream associated with the <see cref="CategoryCollection"/>.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal CategoryCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="category"><see cref="ICategory"/> object to add to the set.</param>
        /// <exception cref="DuplicateCategoryException"></exception>
        public new void Add(ICategory category)
        {
            if (!base.Add(category) || this.Duplicates(c => c.ID).Any())
            {
                throw new DuplicateCategoryException();
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is HashSet<ICategory>)) ? false : InternalEquals((HashSet<ICategory>)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CategoryCollection obj)
        {
            return (obj == null) ? false : InternalEquals(obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        private bool InternalEquals(HashSet<ICategory> obj)
        {
            bool equals = false;

            if (obj != null)
            {
                if (obj is CategoryCollection)
                {
                    equals = GetHashCode() == ((CategoryCollection)(obj)).GetHashCode();
                }
                else
                {
                    equals = (Count == obj.Count);

                    if (equals)
                    {
                        equals = this.SequenceEqual(obj);
                    }
                }
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current instance. 
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            this.ForEach(c => hash.Add(c));

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <param name="categoryIdOnly">If <see langword="true"/>, returns a comma-delimited list of all category IDs in the current collection.</param>
        /// <returns>String representation of the current object.</returns>
        public string ToString(bool categoryIdOnly)
        {
            StringBuilder builder = new StringBuilder();
            int counter = 0;
            
            if (categoryIdOnly && Count > 0)
            {
                foreach (ICategory category in this)
                {
                    builder.Append(category.ID);
                    
                    if (counter < Count - 1)
                    {
                        builder.Append(',');
                    }
                }
            }
            else
            {
                builder.Append(ToString());
            }

            return builder.ToString();
        }
    }
}
