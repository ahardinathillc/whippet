using System;
using Athi.Whippet.Security.Tenants;
using System.Security.Policy;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an individual client connection to Salesforce Cloud.
    /// </summary>
    public interface ISalesforceClientProfile : IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<ISalesforceClientProfile>
    {
        /// <summary>
        /// Gets or sets the unique name of the Salesforce profile.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the URL to the Salesforce instance.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Url
        { get; set; }

        /// <summary>
        /// Gets or sets the consumer key which uniquely identifies the application to Salesforce for authentication.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string ConsumerKey
        { get; set; }

        /// <summary>
        /// Specifies the <see cref="WhippetTenant"/> that the Salesforce instance is registered with.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret value.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string ConsumerSecret
        { get; set; }

        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        string ApiToken
        { get; set; }

        /// <summary>
        /// Gets or sets the user name used to authenticate the request.
        /// </summary>
        string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the password used to authenticate the request.
        /// </summary>
        string Password
        { get; set; }

        /// <summary>
        /// Specifies whether the web-server authentication flow should be used.
        /// </summary>
        bool UseWebServerAuthenticationFlow
        { get; set; }
    }
}

