using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a list of <see cref="WhippetMvcSecurityPermission"/> objects that can be accessed by index. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMvcSecurityPermissionCollection : IWhippetPermissionCollection<WhippetMvcSecurityPermission>, IList<WhippetMvcSecurityPermission>, ICollection<WhippetMvcSecurityPermission>, IEnumerable<WhippetMvcSecurityPermission>, IEnumerable, IList, IReadOnlyList<WhippetMvcSecurityPermission>, IReadOnlyCollection<WhippetMvcSecurityPermission>, ICollection
    {
        private WhippetPermissionCollection<WhippetMvcSecurityPermission> _collection;

        /// <summary>
        /// Gets or sets the internal <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/> object.
        /// </summary>
        private WhippetPermissionCollection<WhippetMvcSecurityPermission> InternalCollection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = new WhippetPermissionCollection<WhippetMvcSecurityPermission>();
                }

                return _collection;
            }
            set
            {
                _collection = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetMvcSecurityPermission"/> object at the specified index.
        /// </summary>
        /// <param name="index">Index at which to get or set the object.</param>
        /// <returns><see cref="WhippetMvcSecurityPermission"/> object located at the specified index.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetMvcSecurityPermission this[int index]
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
        /// Gets or sets the <see cref="WhippetMvcSecurityPermission" /> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetMvcSecurityPermission" /> to get or set.</param>
        /// <returns><see cref="WhippetMvcSecurityPermission" /> with the specified ID or <see langword="null"/> if the permission could not be found.</returns>
        public WhippetMvcSecurityPermission this[Guid id]
        {
            get
            {
                return InternalCollection[id];
            }
            set
            {
                InternalCollection[id] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetMvcSecurityPermission"/> object at the specified index.
        /// </summary>
        /// <param name="index">Index at which to get or set the object.</param>
        /// <returns><see cref="WhippetMvcSecurityPermission"/> object located at the specified index.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                ((IList)(InternalCollection))[index] = value;
            }
        }

        /// <summary>
        /// Indicates whether access to the <see cref="ICollection"/> is synchronized (thread safe). This property is read-only.
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get
            {
                return ((ICollection)(InternalCollection)).IsSynchronized;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>. This property is read-only.
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                return ((ICollection)(InternalCollection)).SyncRoot;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="IList"/> has a fixed size. This property is read-only.
        /// </summary>
        bool IList.IsFixedSize
        {
            get
            {
                return ((IList)(InternalCollection)).IsFixedSize;
            }
        }

        /// <summary>
        /// Indicates whether the current collection is read-only. This property is read-only.
        /// </summary>
        bool IList.IsReadOnly
        {
            get
            {
                return ((ICollection<WhippetMvcSecurityPermission>)(this)).IsReadOnly;
            }
        }

        /// <summary>
        /// Gets the total number of objects in the current collection. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return InternalCollection.Count;
            }
        }

        /// <summary>
        /// Indicates whether the current collection is read-only. This property is read-only.
        /// </summary>
        bool ICollection<WhippetMvcSecurityPermission>.IsReadOnly
        {
            get
            {
                return ((ICollection<WhippetMvcSecurityPermission>)(InternalCollection)).IsReadOnly;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityPermissionCollection"/> class with no arguments.
        /// </summary>
        public WhippetMvcSecurityPermissionCollection()
            : this(new WhippetPermissionCollection<WhippetMvcSecurityPermission>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityPermissionCollection"/> class with the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetMvcSecurityPermissionCollection(IEnumerable<WhippetMvcSecurityPermission> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                InternalCollection = new WhippetPermissionCollection<WhippetMvcSecurityPermission>(collection);
            }
        }

        /// <summary>
        /// Adds the <see cref="WhippetMvcSecurityPermission"/> object to the end of the <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/> list if the permission object does not already exist in the collection.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> object to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(WhippetMvcSecurityPermission permission)
        {
            InternalCollection.Add(permission);
        }

        /// <summary>
        /// Adds the <see cref="WhippetMvcSecurityPermission"/> object to the end of the <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/> list if the permission object does not already exist in the collection.
        /// </summary>
        /// <param name="value"><see cref="WhippetMvcSecurityPermission"/> object to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        int IList.Add(object value)
        {
            return ((IList)(InternalCollection)).Add(value);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/> list for each permission object that does not already exist in the collection.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddRange(IEnumerable<WhippetMvcSecurityPermission> collection)
        {
            InternalCollection.AddRange(collection);
        }

        /// <summary>
        /// Determines whether the collection contains the specified <see cref="WhippetMvcSecurityPermission"/> object.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> object to check the collection for.</param>
        /// <returns><see langword="true"/> if the collection contains the object; otherwise, <see langword="false"/>.</returns>
        public bool Contains(WhippetMvcSecurityPermission permission)
        {
            return InternalCollection.Contains(permission);
        }

        /// <summary>
        /// Determines whether the collection contains the specified <see cref="WhippetMvcSecurityPermission"/> object.
        /// </summary>
        /// <param name="value"><see cref="WhippetMvcSecurityPermission"/> object to check the collection for.</param>
        /// <returns><see langword="true"/> if the collection contains the object; otherwise, <see langword="false"/>.</returns>
        bool IList.Contains(object value)
        {
            return ((IList)(InternalCollection)).Contains(value);
        }

        /// <summary>
        /// Inserts the specified <see cref="WhippetMvcSecurityPermission"/> object into the collection at the specified index if the object is not already contained in the list.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void Insert(int index, WhippetMvcSecurityPermission item)
        {
            InternalCollection.Insert(index, item);
        }

        /// <summary>
        /// Inserts the specified <see cref="WhippetMvcSecurityPermission"/> object into the collection at the specified index if the object is not already contained in the list.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">The object to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        void IList.Insert(int index, object value)
        {
            ((IList)(InternalCollection)).Insert(index, value);
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/> at the specified index for each object that is not already contained in the list.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the <see cref="WhippetPermissionCollection{WhippetMvcSecurityPermission}"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void InsertRange(int index, IEnumerable<WhippetMvcSecurityPermission> collection)
        {
            InternalCollection.InsertRange(index, collection);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="WhippetMvcSecurityPermissionCollection"/>.
        /// </summary>
        /// <param name="item"><see cref="WhippetMvcSecurityPermission"/> object to search for.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="item"/> within the entire <see cref="WhippetMvcSecurityPermissionCollection"/> or -1 if the object was not found.</returns>
        public int IndexOf(WhippetMvcSecurityPermission item)
        {
            return InternalCollection.IndexOf(item);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="WhippetMvcSecurityPermissionCollection"/>.
        /// </summary>
        /// <param name="value"><see cref="WhippetMvcSecurityPermission"/> object to search for.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="value"/> within the entire <see cref="WhippetMvcSecurityPermissionCollection"/> or -1 if the object was not found.</returns>
        int IList.IndexOf(object value)
        {
            return ((IList)(InternalCollection)).IndexOf(value);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="WhippetMvcSecurityPermissionCollection"/>.
        /// </summary>
        /// <param name="index">Index of the object to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public void RemoveAt(int index)
        {
            InternalCollection.RemoveAt(index);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="WhippetMvcSecurityPermissionCollection"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="WhippetMvcSecurityPermissionCollection"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="item"/> was successfully removed from the <see cref="WhippetMvcSecurityPermissionCollection"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="NotSupportedException" />
        public bool Remove(WhippetMvcSecurityPermission item)
        {
            return InternalCollection.Remove(item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="WhippetMvcSecurityPermissionCollection"/>.
        /// </summary>
        /// <param name="value">The object to remove from the <see cref="WhippetMvcSecurityPermissionCollection"/>.</param>
        /// <exception cref="NotSupportedException" />
        void IList.Remove(object? value)
        {
            ((IList)(InternalCollection)).Remove(value);
        }

        /// <summary>
        /// Removes all elements from the <see cref="WhippetMvcSecurityPermissionCollection"/>.
        /// </summary>
        public void Clear()
        {
            InternalCollection.Clear();
        }

        /// <summary>
        /// Copies the elements of the <see cref="WhippetMvcSecurityPermissionCollection"/> collection to an array, starting at a particular array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from <see cref="WhippetMvcSecurityPermissionCollection"/>. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public void CopyTo(WhippetMvcSecurityPermission[] array, int arrayIndex)
        {
            InternalCollection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies the elements of the <see cref="WhippetMvcSecurityPermissionCollection"/> collection to an array, starting at a particular array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from <see cref="WhippetMvcSecurityPermissionCollection"/>. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)(InternalCollection)).CopyTo(array, index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> object that can be used to iterate through the collection.</returns>
        IEnumerator<WhippetMvcSecurityPermission> IEnumerable<WhippetMvcSecurityPermission>.GetEnumerator()
        {
            return InternalCollection.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalCollection.GetEnumerator();
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> that filters the current collection's contents to the specified <see cref="WhippetViewProfile"/>.
        /// </summary>
        /// <param name="view"><see cref="WhippetViewProfile"/> to filter by.</param>
        /// <returns><see cref="IEnumerable{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<WhippetMvcSecurityPermission> ForView(WhippetViewProfile view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }
            else
            {
                List<WhippetMvcSecurityPermission> permissions = new List<WhippetMvcSecurityPermission>(this.Where(p => view.Equals(p.View)).ToList());
                return permissions.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> of all <see cref="WhippetViewProfile"/> objects stored in the collection with their associated <see cref="WhippetMvcSecurityPermission"/> objects.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        public IReadOnlyDictionary<WhippetViewProfile, WhippetMvcSecurityPermissionReadOnlyCollection> GroupByViews()
        {
            Dictionary<WhippetViewProfile, WhippetMvcSecurityPermissionReadOnlyCollection> permissionGroups = new Dictionary<WhippetViewProfile, WhippetMvcSecurityPermissionReadOnlyCollection>();

            foreach (WhippetViewProfile view in this.Select(p => p.View).Distinct())
            {
                if (!permissionGroups.ContainsKey(view))
                {
                    permissionGroups.Add(view, new WhippetMvcSecurityPermissionReadOnlyCollection(new WhippetMvcSecurityPermissionCollection(ForView(view))));
                }
            }

            return new ReadOnlyDictionary<WhippetViewProfile, WhippetMvcSecurityPermissionReadOnlyCollection>(permissionGroups);
        }

        /// <summary>
        /// Gets the index of the <see cref="WhippetMvcSecurityPermission" /> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetMvcSecurityPermission" /> to retrieve the index for.</param>
        /// <returns>Index of the <see cref="WhippetMvcSecurityPermission" /> object with the specified ID or -1 if the object could not be found.</returns>
        public int IndexOf(Guid id)
        {
            int index = -1;

            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].ID.Equals(id))
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        public static implicit operator WhippetPermissionCollection<WhippetMvcSecurityPermission>(WhippetMvcSecurityPermissionCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }

        /// <summary>
        /// Represents a read-only list of <see cref="WhippetMvcSecurityPermission"/> objects that can be accessed by index. This class cannot be inherited.
        /// </summary>
        public sealed class WhippetMvcSecurityPermissionReadOnlyCollection : ReadOnlyCollection<WhippetMvcSecurityPermission>, IWhippetPermissionReadOnlyCollection<WhippetMvcSecurityPermission>, IReadOnlyList<WhippetMvcSecurityPermission>, IReadOnlyCollection<WhippetMvcSecurityPermission>
        {
            private static WhippetMvcSecurityPermissionReadOnlyCollection _empty;

            /// <summary>
            /// Gets an empty <see cref="WhippetMvcSecurityPermissionReadOnlyCollection"/> object. This property is read-only.
            /// </summary>
            public static WhippetMvcSecurityPermissionReadOnlyCollection Empty
            {
                get
                {
                    if (_empty == null)
                    {
                        _empty = new WhippetMvcSecurityPermissionReadOnlyCollection();
                    }

                    return _empty;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="WhippetMvcSecurityPermission" /> object with the specified ID.
            /// </summary>
            /// <param name="id">Unique ID of the <see cref="WhippetMvcSecurityPermission" /> to get or set.</param>
            /// <returns><see cref="WhippetMvcSecurityPermission" /> with the specified ID or <see langword="null"/> if the permission could not be found.</returns>
            public WhippetMvcSecurityPermission this[Guid id]
            {
                get
                {
                    return this[IndexOf(id)];
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="WhippetMvcSecurityPermissionReadOnlyCollection"/> with no arguments.
            /// </summary>
            private WhippetMvcSecurityPermissionReadOnlyCollection()
                : this(new WhippetMvcSecurityPermissionCollection())
            { }

            /// <summary>
            /// Initializes a new instance of the <see cref="WhippetMvcSecurityPermissionReadOnlyCollection"/> with the specified <see cref="IWhippetPermissionCollection{TPermission}"/> object.
            /// </summary>
            /// <param name="collection"><see cref="IWhippetPermissionCollection{TPermission}"/> object to initialize with.</param>
            /// <exception cref="ArgumentNullException" />
            public WhippetMvcSecurityPermissionReadOnlyCollection(IWhippetPermissionCollection<WhippetMvcSecurityPermission> collection)
                : base((collection is WhippetMvcSecurityPermissionCollection) ? collection : new WhippetMvcSecurityPermissionCollection(collection))
            { }

            /// <summary>
            /// Gets the index of the <see cref="WhippetMvcSecurityPermission" /> object with the specified ID.
            /// </summary>
            /// <param name="id">ID of the <see cref="WhippetMvcSecurityPermission" /> to retrieve the index for.</param>
            /// <returns>Index of the <see cref="WhippetMvcSecurityPermission" /> object with the specified ID or -1 if the object could not be found.</returns>
            public int IndexOf(Guid id)
            {
                int index = -1;

                if (Count > 0)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (this[i].ID.Equals(id))
                        {
                            index = i;
                            break;
                        }
                    }
                }

                return index;
            }
        }
    }
}

