using System;
namespace Athi.Whippet.Security
{
    /// <summary>
    /// Provides common <see cref="IWhippetPrincipalObject"/> types. This class cannot be inherited.
    /// </summary>
    public static class WhippetPrincipalObjectCommonTypes
    {
        /// <summary>
        /// Indicates the <see cref="IWhippetPrincipalObject"/> is a group.
        /// </summary>
        public const string GROUP = "Group";

        /// <summary>
        /// Indicates the <see cref="IWhippetPrincipalObject"/> is a role.
        /// </summary>
        public const string ROLE = "Role";

        /// <summary>
        /// Indicates the <see cref="IWhippetPrincipalObject"/> is a user.
        /// </summary>
        public const string USER = "User";
    }
}

