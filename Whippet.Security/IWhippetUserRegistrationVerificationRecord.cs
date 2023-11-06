using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIpAddress = System.Net.IPAddress;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Provides a staging process for newly registered users. Users are sent a verification e-mail or SMS message to authenticate their request to create a new account.
    /// </summary>
    public interface IWhippetUserRegistrationVerificationRecord : IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity
    {
        /// <summary>
        /// Gets or sets the name (e-mail address) of the <see cref="WhippetUser"/> that is requesting to register an account.
        /// </summary>
        string UserName
        { get; set; }

        /// <summary>
        /// Gets or sets the authentication key used to authorize the request and create the account or allow access.
        /// </summary>
        string AuthenticationKey
        { get; set; }

        /// <summary>
        /// URL that the user can go directly to in order to authenticate their request.
        /// </summary>
        string AuthenticationUrl
        { get; set; }

        /// <summary>
        /// The expiration date indicates when the request is considered stale. Once this state is reached, the user will need to resubmit a new request to register an account.
        /// </summary>
        Instant RequestExpirationDate
        { get; set; }

        /// <summary>
        /// The date the request was authenticated. If <see langword="null"/>, the request has not been authenticated.
        /// </summary>
        Instant? DateAuthenticated
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address that the request originated from.
        /// </summary>
        /// <exception cref="FormatException" />
        string IPAddress
        { get; set; }

        /// <summary>
        /// Associates the record with the appropriate <see cref="IWhippetTenant"/>.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="IWhippetUser"/> account that the verification record is associated with. If <see langword="null"/>, the record has not been authenticated yet and no user record has been associated.
        /// </summary>
        Guid? UserId
        { get; set; }
    }
}
