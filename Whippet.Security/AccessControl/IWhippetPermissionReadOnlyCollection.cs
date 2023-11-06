using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a list of <see cref="IWhippetPermission"/> objects that can be accessed by index.
    /// </summary>
    /// <typeparam name="TPermission"><see cref="IWhippetPermission"/> type that is stored in the collection.</typeparam>
    public interface IWhippetPermissionReadOnlyCollection<TPermission> : IReadOnlyCollection<TPermission>, IReadOnlyList<TPermission>, IEnumerable<TPermission>, IEnumerable
        where TPermission : IWhippetPermission
    {
        /// <summary>
        /// Gets the <typeparamref name="TPermission"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <typeparamref name="TPermission"/> to get.</param>
        /// <returns><typeparamref name="TPermission"/> with the specified ID or <see langword="null"/> if the permission could not be found.</returns>
        TPermission this[Guid id]
        { get; }

        /// <summary>
        /// Gets the zero-based index of the <typeparamref name="TPermission"/> object with the specified ID or -1 if the <typeparamref name="TPermission"/> could not be found.
        /// </summary>
        /// <param name="id">Unique ID of the <typeparamref name="TPermission"/> object to search for.</param>
        /// <returns><typeparamref name="TPermission"/> object with the specified ID or -1 if the object could not be found.</returns>
        int IndexOf(Guid id);
    }
}

