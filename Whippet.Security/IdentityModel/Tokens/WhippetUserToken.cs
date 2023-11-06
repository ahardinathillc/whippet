using System;
using System.Collections.Generic;
using NodaTime;
using Athi.Whippet.Security;

namespace Athi.Whippet.Security.IdentityModel.Tokens
{
    /// <summary>
    /// Represents a serialized token that is passed from one view to the next inside an application. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetUserToken : IWhippetToken
    {
        /// <summary>
        /// Gets the token name. This property is read-only.
        /// </summary>
        public static string TokenName => "Whippet_Account_Token";

        /// <summary>
        /// Gets the token name. This property is read-only.
        /// </summary>
        string IWhippetToken.TokenName
        {
            get
            {
                return TokenName;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetUser"/> object that resides in the token. This property is read-only.
        /// </summary>
        public IWhippetUser Account
        { get; private set; }

        /// <summary>
        /// Gets the token that was generated for the user once successfully authenticated. This property is read-only.
        /// </summary>
        public string Token
        { get; private set; }

        /// <summary>
        /// Gets the date and time in UTC format that the token expires. This property is read-only.
        /// </summary>
        public Instant Expires
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IWhippetUser"/> class with no arguments.
        /// </summary>
        private WhippetUserToken()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserToken"/> class with the specified <see cref="IWhippetUser"/> object.
        /// </summary>
        /// <param name="account"><see cref="IWhippetUser"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserToken(IWhippetUser account)
            : this(account, null, Instant.MaxValue)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserToken"/> class with the specified <see cref="IWhippetUser"/> object.
        /// </summary>
        /// <param name="account"><see cref="IWhippetUser"/> object.</param>
        /// <param name="token">Authentication token that was granted to the user.</param>
        /// <param name="expires">Date and time (in UTC format) the token expires.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserToken(IWhippetUser account, string token, DateTime expires)
            : this(account, token, Instant.FromDateTimeUtc(expires.Kind == DateTimeKind.Utc ? expires : expires.ToUniversalTime()))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserToken"/> class with the specified <see cref="IWhippetUser"/> object.
        /// </summary>
        /// <param name="account"><see cref="IWhippetUser"/> object.</param>
        /// <param name="token">Authentication token that was granted to the user.</param>
        /// <param name="expires">Date and time (in UTC format) the token expires.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserToken(IWhippetUser account, string token, Instant expires)
            : this()
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                Account = account;
            }
        }

        /// <summary>
        /// Compares the current object to the specified instance for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is WhippetUserToken)) ? false : Equals(obj as WhippetUserToken);
        }

        /// <summary>
        /// Compares the current object to the specified instance for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IWhippetToken obj)
        {
            return (obj == null || !(obj is WhippetUserToken)) ? false : Equals(this, obj as WhippetUserToken);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IWhippetToken x, IWhippetToken y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = ((x.Account == null && y.Account == null) || ((x.Account != null && y.Account != null) && x.Account.Equals(y.Account)))
                    && String.Equals(x.TokenName, y.TokenName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Token, y.Token, StringComparison.InvariantCultureIgnoreCase)
                    && x.Expires.Equals(y.Expires);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IWhippetToken obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        public static implicit operator KeyValuePair<string, object>(WhippetUserToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            else
            {
                return new KeyValuePair<string, object>(TokenName, token);
            }
        }
    }
}

