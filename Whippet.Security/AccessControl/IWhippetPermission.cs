using System;
using System.Collections.Generic;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a permission in Whippet. <see cref="IWhippetPermission"/> instances correlate to a <see cref="WhippetPermissionType"/> that determines what security functionalities are available for a particular object.
    /// </summary>
    public interface IWhippetPermission : IEqualityComparer<IWhippetPermission>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets the unique ID of the permission. This property is read-only.
        /// </summary>
        Guid ID
        { get; }

        /// <summary>
        /// Gets the type of permission represented by the current instance. This property is read-only.
        /// </summary>
        WhippetPermissionType Type
        { get; }

        /// <summary>
        /// Gets the name of the permission represented by the current instance. This property is read-only.
        /// </summary>
        string Name
        { get; }
    }
}
