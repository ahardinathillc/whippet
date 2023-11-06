using System;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Provides support to objects that are identified as security objects in Whippet that can have attributes assigned to them.
    /// </summary>
    public interface IWhippetPrincipalObject : IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Gets a unique identifier for the object. This property is read-only.
        /// </summary>
        object PrincipalID
        { get; }

        /// <summary>
        /// Gets a non-localized categorization of the object type (e.g., "Group", "User", etc.). This property is read-only.
        /// </summary>
        string PrincipalType
        { get; }

        /// <summary>
        /// Gets the representative name of the object. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Creates a new instance of the current <see cref="IWhippetPrincipalObject"/>.
        /// </summary>
        /// <param name="principalId">Unique identifier for the object.</param>
        /// <param name="name">Representative name of the object (if any).</param>
        /// <param name="principalType">Non-localized categorization of the object type (e.g., "Group", "User", etc.) or <see cref="String.Empty"/> or <see langword="null"/> to use the object's default.</param>
        /// <returns><see cref="IWhippetPrincipalObject"/> object.</returns>
        IWhippetPrincipalObject CreateInstance(object principalId, string name, string principalType = null);
    }
}

