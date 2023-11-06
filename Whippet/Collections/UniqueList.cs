using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Athi.Whippet.Collections
{
    /// <summary>
    /// Represents a strongly typed list of unique objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
    /// </summary>
    /// <typeparam name="T">Type of item to store in the collection.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public class UniqueList<T> : List<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">Index of the item to get or set.</param>
        /// <returns>Item located at the specified index.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public new T this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                if (Contains(value))
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    base[index] = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public UniqueList()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList{T}"/> class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity to set the <see cref="UniqueList{T}"/> to.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public UniqueList(int capacity)
            : base(capacity)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList{T}"/> class with the specified collection.
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection to initialize with.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public UniqueList(IEnumerable<T> collection)
            : base(collection)
        { }

        /// <summary>
        /// Adds an object to the end of the <see cref="UniqueList{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the list.</param>
        /// <exception cref="InvalidOperationException" />
        public new void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException();
            }
            else
            {
                base.Add(item);
            }
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="UniqueList{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">Index of the <see cref="UniqueList{T}"/> at which insertion begins.</param>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection to insert.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            if (index < (Count - 1) && index >= 0)      // let the parent class handle exceptions
            {
                if (collection != null && collection.Any())
                {
                    foreach (T item in collection)
                    {
                        if (item != null && Contains(item))
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }
            }

            base.InsertRange(index, collection);
        }

        /// <summary>
        /// Inserts an item into the <see cref="UniqueList{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">Index at which to insert <paramref name="item"/>.</param>
        /// <param name="item">Item to insert into the collection.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public new void Insert(int index, T item)
        {
            if (index >= 0 && index < Count)
            {
                if (Contains(item))
                {
                    throw new InvalidOperationException();
                }
            }

            base.Insert(index, item);
        }
    }
}

