using System;
using System.Collections.Generic;
using System.Linq;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a list of <see cref="IWhippetPermission"/> objects that can be accessed by index. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="TPermission"><see cref="IWhippetPermission"/> type that is stored in the collection.</typeparam>
    public sealed class WhippetPermissionCollection<TPermission> : List<TPermission>, IWhippetPermissionCollection<TPermission>
        where TPermission : IWhippetPermission
    {
        /// <summary>
        /// Gets or sets the <typeparamref name="TPermission"/> object at the specified index.
        /// </summary>
        /// <param name="index">Index at which to get or set the object.</param>
        /// <returns><typeparamref name="TPermission"/> object located at the specified index.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        public new TPermission this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    if (!Contains(value))
                    {
                        base[index] = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the <typeparamref name="TPermission"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <typeparamref name="TPermission"/> object to get or set.</param>
        /// <returns><typeparamref name="TPermission"/> object with the specified ID.</returns>
        public TPermission this[Guid id]
        {
            get
            {
                return this[IndexOf(id)];
            }
            set
            {
                this[IndexOf(id)] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPermissionCollection{TPermission}"/> class with no arguments.
        /// </summary>
        public WhippetPermissionCollection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPermissionCollection{TPermission}"/> class with the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetPermissionCollection(IEnumerable<TPermission> collection)
            : base(collection == null ? null : collection.Distinct())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPermissionCollection{TPermission}"/> class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetPermissionCollection(int capacity)
            : base(capacity)
        { }

        /// <summary>
        /// Adds the <typeparamref name="TPermission"/> object to the end of the <see cref="WhippetPermissionCollection{TPermission}"/> list if the permission object does not already exist in the collection.
        /// </summary>
        /// <param name="permission"><typeparamref name="TPermission"/> object to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public new void Add(TPermission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            else if (!Contains(permission))
            {
                base.Add(permission);
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="WhippetPermissionCollection{TPermission}"/> list for each permission object that does not already exist in the collection.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="WhippetPermissionCollection{TPermission}"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public new void AddRange(IEnumerable<TPermission> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                List<TPermission> filteredList = new List<TPermission>(collection.Count());

                foreach (TPermission permission in collection.Distinct())
                {
                    if ((permission != null) && !Contains(permission))
                    {
                        filteredList.Add(permission);
                    }
                }

                base.AddRange(filteredList);
            }
        }

        /// <summary>
        /// Determines whether the collection contains the specified <typeparamref name="TPermission"/> object.
        /// </summary>
        /// <param name="permission"><typeparamref name="TPermission"/> object to check the collection for.</param>
        /// <returns><see langword="true"/> if the collection contains the object; otherwise, <see langword="false"/>.</returns>
        public new bool Contains(TPermission permission)
        {
            bool hasPermission = false;

            if (permission != null)
            {
                hasPermission = (from p in this where p.Equals(permission) || p.ID.Equals(permission.ID) select p).Any();
            }

            return hasPermission;
        }

        /// <summary>
        /// Inserts the specified <typeparamref name="TPermission"/> object into the collection at the specified index if the object is not already contained in the list.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public new void Insert(int index, TPermission item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (item == null)
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
        /// Inserts the elements of a collection into the <see cref="WhippetPermissionCollection{TPermission}"/> at the specified index for each object that is not already contained in the list.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the <see cref="WhippetPermissionCollection{TPermission}"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public new void InsertRange(int index, IEnumerable<TPermission> collection)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                List<TPermission> filteredList = new List<TPermission>(collection.Count());

                foreach (TPermission permission in collection.Distinct())
                {
                    if ((permission != null) && !Contains(permission))
                    {
                        filteredList.Add(permission);
                    }
                }

                base.InsertRange(index, filteredList);
            }
        }

        /// <summary>
        /// Gets the index of the <typeparamref name="TPermission"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <typeparamref name="TPermission"/> to retrieve the index for.</param>
        /// <returns>Index of the <typeparamref name="TPermission"/> object with the specified ID or -1 if the object could not be found.</returns>
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

