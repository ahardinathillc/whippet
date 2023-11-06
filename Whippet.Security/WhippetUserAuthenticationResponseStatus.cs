using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Status response for authenticating <see cref="IWhippetUser"/> objects.
    /// </summary>
    [Flags]
    public enum WhippetUserAuthenticationResponseStatus
    {
        /// <summary>
        /// Authentication was successful. User is allowed to continue to authorization process.
        /// </summary>
        Success = 1,
        /// <summary>
        /// Authentication failed. The password supplied does not match what is recorded in the system.
        /// </summary>
        Fail_InvalidPassword = 2,
        /// <summary>
        /// Authentication failed. No user by the supplied username exists.
        /// </summary>
        Fail_InvalidUsername = 4,
        /// <summary>
        /// Authentication failed. The account is locked or marked inactive.
        /// </summary>
        Fail_AccountLockedOrInactive = 8,
        /// <summary>
        /// Authentication failed. The account is deleted.
        /// </summary>
        Fail_AccountDeleted = 16,
        /// <summary>
        /// Authentication failed. The supplied IP address from which the request came is blacklisted.
        /// </summary>
        Fail_IPBlacklisted = 32
    }
}
