using System;
namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents an individual categorization of a permission in Whippet.
    /// </summary>
    [Flags]
    public enum WhippetPermissionType
    {
        /// <summary>
        /// Indicates that the principal can read (and only read) the data presented by the target object.
        /// </summary>
        Read = 0b_0000_0000,
        /// <summary>
        /// Indicates that the principal can modify existing data on the target object (including deleting).
        /// </summary>
        Modify = 0b_0000_0001,
        /// <summary>
        /// Indicates that the principal can create new objects.
        /// </summary>
        Create = 0b_0000_0010,
        /// <summary>
        /// Indicates that the principal has full control over all operations on the object, including executing custom actions. This value overrides all other permissions except <see cref="AdministratorOnly"/>.
        /// </summary>
        FullControl = 0b_000_0100,
        /// <summary>
        /// Indicates that the permission type represented is a special permission. Refer to the object's description for details.
        /// </summary>
        Special = 0b_000_1000,
        /// <summary>
        /// Indicates that only principals that are members of an administrator role or group can access the target object. Thie value overrides all other permissions, including <see cref="FullControl"/>.
        /// </summary>
        AdministratorOnly = 0b_001_0000
    }
}

