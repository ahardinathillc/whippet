using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIpAddress = System.Net.IPAddress;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Represents a very basic user in the Whippet domain independent of any tenant or application.
    /// </summary>
    public interface IWhippetUser : IWhippetEntity, IEqualityComparer<IWhippetUser>, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetPrincipalObject
    {
        /// <summary>
        /// Gets or sets the username of the <see cref="WhippetUser"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string UserName
        { get; set; }

        /// <summary>
        /// Gets or sets the password of the <see cref="WhippetUser"/>. The value can be encrypted or decrypted depending on implementation of the service.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the time zone identifier which determines the user account's relative time zone. 
        /// </summary>
        string TimeZoneIdentifier
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address associated with the account.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the last login from the user account.
        /// </summary>
        /// <exception cref="FormatException" />
        string IPAddress
        { get; set; }
    }
}
