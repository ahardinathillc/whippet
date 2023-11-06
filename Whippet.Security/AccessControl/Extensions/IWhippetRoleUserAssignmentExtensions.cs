using System;

namespace Athi.Whippet.Security.AccessControl.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetRoleUserAssignment"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetRoleUserAssignmentExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetRoleUserAssignment"/> object to a <see cref="WhippetRoleUserAssignment"/> object.
        /// </summary>
        /// <param name="roleAssign"><see cref="IWhippetRoleUserAssignment"/> object to convert.</param>
        /// <returns><see cref="WhippetRoleUserAssignment"/> object.</returns>
        public static WhippetRoleUserAssignment ToWhippetRoleUserAssignment(this IWhippetRoleUserAssignment roleAssign)
        {
            WhippetRoleUserAssignment ga = null;

            if (roleAssign != null)
            {
                ga = (roleAssign is WhippetRoleUserAssignment) ? ((WhippetRoleUserAssignment)(roleAssign)) : new WhippetRoleUserAssignment(
                    roleAssign.ID,
                    roleAssign.User,
                    roleAssign.Role,
                    roleAssign.CreatedDateTime,
                    roleAssign.CreatedBy,
                    roleAssign.LastModifiedDateTime,
                    roleAssign.LastModifiedBy,
                    roleAssign.Active,
                    roleAssign.Deleted
                    );
            }

            return ga;
        }
    }
}

