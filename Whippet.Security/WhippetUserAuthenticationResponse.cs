using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Provides a response to an authentication request in Whippet. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetUserAuthenticationResponse
    {
        private IPAddress _ip;

        /// <summary>
        /// Gets the <see cref="Guid"/> of the user account who made the request. This property is read-only.
        /// </summary>
        public Guid UserID
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="Instant"/> of the request. This property is read-only.
        /// </summary>
        public Instant RequestTimestamp
        { get; private set; }

        /// <summary>
        /// Indicates the status of the response; i.e., indicates whether the request was successful and, if not, why. This property is read-only.
        /// </summary>
        public WhippetUserAuthenticationResponseStatus ResponseStatus
        { get; private set; }

        /// <summary>
        /// Represents the IP address of the requestor, if any was captured. This property is read-only.
        /// </summary>
        public IPAddress IPAddress
        {
            get
            {
                if (_ip == null)
                {
                    _ip = IPAddress.Parse("127.0.0.1");     // default to loopback
                }

                return _ip;
            }
            private set
            {
                _ip = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAuthenticationResponse"/> class with no arguments.
        /// </summary>
        private WhippetUserAuthenticationResponse()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAuthenticationResponse"/> class.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> object.</param>
        /// <param name="requestTimestamp">Date/time of the request or <see langword="null"/> to use the current date and time.</param>
        /// <param name="responseFlag"><see cref="WhippetUserAuthenticationResponseStatus"/> value that indicates the response.</param>
        /// <param name="ipAddress">IP address of the requestor (if any was captured).</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserAuthenticationResponse(IWhippetUser user, Instant? requestTimestamp, WhippetUserAuthenticationResponseStatus responseFlag, IPAddress ipAddress = null)
            : this((user == null) ? Guid.Empty : user.ID, requestTimestamp, responseFlag, ipAddress)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAuthenticationResponse"/> class.
        /// </summary>
        /// <param name="userId">ID of the user account who made the request.</param>
        /// <param name="requestTimestamp">Date/time of the request or <see langword="null"/> to use the current date and time.</param>
        /// <param name="responseFlag"><see cref="WhippetUserAuthenticationResponseStatus"/> value that indicates the response.</param>
        /// <param name="ipAddress">IP address of the requestor (if any was captured).</param>
        public WhippetUserAuthenticationResponse(Guid userId, Instant? requestTimestamp, WhippetUserAuthenticationResponseStatus responseFlag, IPAddress ipAddress = null)
        {
            UserID = userId;
            RequestTimestamp = (requestTimestamp.HasValue) ? requestTimestamp.Value : Instant.FromDateTimeUtc(DateTime.UtcNow);
            ResponseStatus = responseFlag;
            IPAddress = ipAddress;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return ResponseStatus.ToString();
        }
    }
}
