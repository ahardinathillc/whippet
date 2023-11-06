using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a list of <see cref="IWhippetPermission"/> objects that can be accessed by index.
    /// </summary>
    /// <typeparam name="TPermission"><see cref="IWhippetPermission"/> type that is stored in the collection.</typeparam>
    public interface IWhippetPermissionCollection<TPermission> : IList<TPermission>, ICollection<TPermission>, IEnumerable<TPermission>, IEnumerable, IList, ICollection, IReadOnlyList<TPermission>, IReadOnlyCollection<TPermission>, IWhippetPermissionReadOnlyCollection<TPermission>
        where TPermission : IWhippetPermission
    {
        /// <summary>
        /// Gets or sets the <typeparamref name="TPermission"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <typeparamref name="TPermission"/> to get or set.</param>
        /// <returns><typeparamref name="TPermission"/> with the specified ID or <see langword="null"/> if the permission could not be found.</returns>
        TPermission this[Guid id]
        { get; set; }

        /// <summary>
        /// Gets the zero-based index of the <typeparamref name="TPermission"/> object with the specified ID or -1 if the <typeparamref name="TPermission"/> could not be found.
        /// </summary>
        /// <param name="id">Unique ID of the <typeparamref name="TPermission"/> object to search for.</param>
        /// <returns><typeparamref name="TPermission"/> object with the specified ID or -1 if the object could not be found.</returns>
        int IndexOf(Guid id);

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="IWhippetPermissionCollection{TPermission}"/> list for each permission object that does not already exist in the collection.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="IWhippetPermissionCollection{TPermission}"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        void AddRange(IEnumerable<TPermission> collection);

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="IWhippetPermissionCollection{TPermission}"/> at the specified index for each object that is not already contained in the list.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the <see cref="IWhippetPermissionCollection{TPermission}"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        void InsertRange(int index, IEnumerable<TPermission> collection);
    }
}

