using System;
using System.Collections.Generic;
using NodaTime;

namespace Athi.Whippet.Security.IdentityModel.Tokens
{
    /// <summary>
    /// Represents a serialized token that is granted to a user upon successful authentication.
    /// </summary>
    public interface IWhippetToken : IEqualityComparer<IWhippetToken>
    {
        /// <summary>
        /// Gets the token name. This property is read-only.
        /// </summary>
        string TokenName
        { get; }

        /// <summary>
        /// Gets the <see cref="IWhippetUser"/> object that resides in the token. This property is read-only.
        /// </summary>
        IWhippetUser Account
        { get; }

        /// <summary>
        /// Gets the token that was generated for the user once successfully authenticated. This property is read-only.
        /// </summary>
        string Token
        { get; }

        /// <summary>
        /// Gets the date and time in UTC format that the token expires. This property is read-only.
        /// </summary>
        Instant Expires
        { get; }
    }
}

