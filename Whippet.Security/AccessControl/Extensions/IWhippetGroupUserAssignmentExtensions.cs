using System;

namespace Athi.Whippet.Security.AccessControl.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetGroupUserAssignment"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetGroupUserAssignmentExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetGroupUserAssignment"/> object to a <see cref="WhippetGroupUserAssignment"/> object.
        /// </summary>
        /// <param name="groupAssign"><see cref="IWhippetGroupUserAssignment"/> object to convert.</param>
        /// <returns><see cref="WhippetGroupUserAssignment"/> object.</returns>
        public static WhippetGroupUserAssignment ToWhippetGroupUserAssignment(this IWhippetGroupUserAssignment groupAssign)
        {
            WhippetGroupUserAssignment ga = null;

            if (groupAssign != null)
            {
                ga = (groupAssign is WhippetGroupUserAssignment) ? ((WhippetGroupUserAssignment)(groupAssign)) : new WhippetGroupUserAssignment(
                    groupAssign.ID,
                    groupAssign.User,
                    groupAssign.Group,
                    groupAssign.CreatedDateTime,
                    groupAssign.CreatedBy,
                    groupAssign.LastModifiedDateTime,
                    groupAssign.LastModifiedBy,
                    groupAssign.Active,
                    groupAssign.Deleted
                    );
            }

            return ga;
        }
    }
}

