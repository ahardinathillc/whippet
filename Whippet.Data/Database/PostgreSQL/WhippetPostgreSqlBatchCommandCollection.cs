using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Npgsql;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a collection of <see cref="WhippetPostgreSqlBatchCommand"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlBatchCommandCollection : DbBatchCommandCollection, IList<WhippetPostgreSqlBatchCommand>, IEnumerable<WhippetPostgreSqlBatchCommand>, IEnumerable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlBatchCommandCollection"/> object.
        /// </summary>
        private NpgsqlBatchCommandCollection InternalCollection
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WhippetPostgreSqlBatchCommand"/> object at the specified index.
        /// </summary>
        /// <param name="index">Index of the item to retrieve.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        WhippetPostgreSqlBatchCommand IList<WhippetPostgreSqlBatchCommand>.this[int index]
        {
            get
            {
                return InternalCollection[index];
            }
            set
            {
                InternalCollection[index] = value;
            }
        }

        /// <summary>
        /// Gets the total number of items in the collection. This property is read-only.
        /// </summary>
        public override int Count
        {
            get
            {
                return InternalCollection.Count;
            }
        }

        /// <summary>
        /// Indicates whether the collection is read-only. This property is read-only.
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                return InternalCollection.IsReadOnly;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatchCommandCollection"/> object with no arguments.
        /// </summary>
        private WhippetPostgreSqlBatchCommandCollection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatchCommandCollection"/> object with the specified <see cref="NpgsqlBatchCommandCollection"/> object.
        /// </summary>
        /// <param name="collection"><see cref="NpgsqlBatchCommandCollection"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlBatchCommandCollection(NpgsqlBatchCommandCollection collection)
            : this()
        {
            ArgumentNullException.ThrowIfNull(collection);
            InternalCollection = collection;
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<WhippetPostgreSqlBatchCommand> IEnumerable<WhippetPostgreSqlBatchCommand>.GetEnumerator()
        {
            foreach (NpgsqlBatchCommand c in InternalCollection)
            {
                yield return new WhippetPostgreSqlBatchCommand(c);
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        public override IEnumerator<DbBatchCommand> GetEnumerator()
        {
            return ((IEnumerable<WhippetPostgreSqlBatchCommand>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetPostgreSqlBatchCommand"/> object to the collection.
        /// </summary>
        /// <param name="item"><see cref="WhippetPostgreSqlBatchCommand"/> object to add.</param>
        public void Add(WhippetPostgreSqlBatchCommand item)
        {
            InternalCollection.Add(item);
        }

        /// <summary>
        /// Adds the specified <see cref="DbBatchCommand"/> object to the collection.
        /// </summary>
        /// <param name="item"><see cref="DbBatchCommand"/> object to add.</param>
        /// <exception cref="InvalidCastException"></exception>
        public override void Add(DbBatchCommand item)
        {
            InternalCollection.Add(item);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public override void Clear()
        {
            InternalCollection.Clear();
        }

        /// <summary>
        /// Checks the collection to see if it contains the specified <see cref="WhippetPostgreSqlBatchCommand"/> object.
        /// </summary>
        /// <param name="item"><see cref="WhippetPostgreSqlBatchCommand"/> object to search for.</param>
        /// <returns><see langword="true"/> if the object is present in the collection; otherwise, <see langword="false"/>.</returns>
        public bool Contains(WhippetPostgreSqlBatchCommand item)
        {
            return InternalCollection.Contains(item);
        }

        /// <summary>
        /// Checks the collection to see if it contains the specified <see cref="DbBatchCommand"/> object.
        /// </summary>
        /// <param name="item"><see cref="DbBatchCommand"/> object to search for.</param>
        /// <returns><see langword="true"/> if the object is present in the collection; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(DbBatchCommand item)
        {
            return InternalCollection.Contains(item);
        }

        /// <summary>
        /// Copies the entire <see cref="List{T}"/> to a compatible one-dimensional array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="List{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void CopyTo(WhippetPostgreSqlBatchCommand[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            else if (arrayIndex > array.Length || arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            else if (InternalCollection.Count > 0)
            {
                NpgsqlBatchCommand[] _array = new NpgsqlBatchCommand[InternalCollection.Count];
                InternalCollection.CopyTo(_array, 0);

                foreach (NpgsqlBatchCommand item in _array)
                {
                    array[arrayIndex] = new WhippetPostgreSqlBatchCommand(item);
                    arrayIndex++;
                }
            }
        }

        /// <summary>
        /// Copies the entire <see cref="List{T}"/> to a compatible one-dimensional array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="List{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public override void CopyTo(DbBatchCommand[] array, int arrayIndex)
        {
            InternalCollection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="List{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="List{T}"/>. The value can be <see langword="null"/> for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="item"/> within the entire <see cref="List{T}"/>, if found; otherwise, -1.</returns>
        public int IndexOf(WhippetPostgreSqlBatchCommand item)
        {
            return InternalCollection.IndexOf(item);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="List{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="List{T}"/>. The value can be <see langword="null"/> for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="item"/> within the entire <see cref="List{T}"/>, if found; otherwise, -1.</returns>
        public override int IndexOf(DbBatchCommand item)
        {
            return InternalCollection.IndexOf(item);
        }

        /// <summary>
        /// Inserts an element into the <see cref="List{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert. The value can be <see langword="null"/> for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int index, WhippetPostgreSqlBatchCommand item)
        {
            InternalCollection.Insert(index, item);
        }

        /// <summary>
        /// Inserts an element into the <see cref="List{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert. The value can be <see langword="null"/> for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void Insert(int index, DbBatchCommand item)
        {
            InternalCollection.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="List{T}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="List{T}"/>. The value can be <see langword="null"/> for reference types.</param>
        /// <returns><see langword="true"/> if <paramref name="item"/> is successfully removed; otherwise, <see langword="false"/>. This method also returns <see langword="false"/> if <paramref name="item"/> was not found in the <see cref="List{T}"/>.</returns>
        public bool Remove(WhippetPostgreSqlBatchCommand item)
        {
            return InternalCollection.Remove(item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="List{T}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="List{T}"/>. The value can be <see langword="null"/> for reference types.</param>
        /// <returns><see langword="true"/> if <paramref name="item"/> is successfully removed; otherwise, <see langword="false"/>. This method also returns <see langword="false"/> if <paramref name="item"/> was not found in the <see cref="List{T}"/>.</returns>
        public override bool Remove(DbBatchCommand item)
        {
            return InternalCollection.Remove(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="List{T}"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void RemoveAt(int index)
        {
            InternalCollection.RemoveAt(index);
        }

        /// <summary>
        /// Gets the <see cref="DbBatchCommand"/> object at the specified index.
        /// </summary>
        /// <param name="index">Index of the command to retrieve.</param>
        /// <returns></returns>
        protected override DbBatchCommand GetBatchCommand(int index)
        {
            return this[index];
        }

        /// <summary>
        /// Sets the <see cref="DbBatchCommand"/> at the specified index.
        /// </summary>
        /// <param name="index">Index at which to set the command.</param>
        /// <param name="batchCommand"><see cref="DbBatchCommand"/> object.</param>
        protected override void SetBatchCommand(int index, DbBatchCommand batchCommand)
        {
            InternalCollection[index] = batchCommand as NpgsqlBatchCommand;
        }
        
        public static implicit operator WhippetPostgreSqlBatchCommandCollection(NpgsqlBatchCommandCollection collection)
        {
            return (collection == null) ? null : new WhippetPostgreSqlBatchCommandCollection(collection);
        }

        public static implicit operator NpgsqlBatchCommandCollection(WhippetPostgreSqlBatchCommandCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }
    }
}
