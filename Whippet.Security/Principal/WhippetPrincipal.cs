using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Security.Claims;
using Athi.Whippet.Security.IdentityModel.Tokens;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.Principal
{
    /// <summary>
    /// Represents a principal in Whippet.
    /// </summary>
    public class WhippetPrincipal : GenericPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPrincipal"/> class from a user identity and an array of <see cref="IWhippetRole"/> names to which the user represented by that identity belongs.
        /// </summary>
        /// <param name="identity">A basic implementation of <see cref="IIdentity"/> that represents any user.</param>
        /// <param name="roles">An <see cref="IEnumerable{T}"/> collection of <see cref="IWhippetRole"/> objects to which the user represented by the <paramref name="identity"/> parameter belongs.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetPrincipal(IIdentity identity, IEnumerable<IWhippetRole> roles)
            : base(identity, RoleEnumerableToString(roles))
        { }

        /// <summary>
        /// Converts the specified <see cref="IEnumerable{T}"/> collection of <see cref="IWhippetRole"/> objects to an array of <see cref="string"/> values based on the <see cref="IWhippetRole.Name"/> value.
        /// </summary>
        /// <param name="roles"><see cref="IEnumerable{T}"/> collection of <see cref="IWhippetRole"/> objects.</param>
        /// <returns><see cref="string"/> array of <see cref="IWhippetRole.Name"/> values.</returns>
        private static string[] RoleEnumerableToString(IEnumerable<IWhippetRole> roles)
        {
            return (roles == null || !roles.Any()) ? Array.Empty<string>() : roles.Where(r => r != null).Select(r => r.Name).ToArray();
        }
    }
}

