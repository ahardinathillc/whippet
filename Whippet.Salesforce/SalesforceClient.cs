using System;
using Salesforce.Common;
using Salesforce.Force;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a client that executes and receives RESTful calls to Salesforce. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceClient : ForceClient, IForceClient, IDisposable, ISalesforceClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClient"/> class with the specified <see cref="IAuthenticationClient"/> object.
        /// </summary>
        /// <param name="authenticationClient"><see cref="IAuthenticationClient"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceClient(IAuthenticationClient authenticationClient)
            : base(authenticationClient?.InstanceUrl, authenticationClient?.AccessToken, authenticationClient?.ApiVersion)
        {
            if (authenticationClient == null)
            {
                throw new ArgumentNullException(nameof(authenticationClient));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClient"/> class.
        /// </summary>
        /// <param name="instanceUrl">Instance URL of the Salesforce system to connect to.</param>
        /// <param name="accessToken">Application access token.</param>
        /// <param name="apiVersion">API version.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceClient(string instanceUrl, string accessToken, string apiVersion)
            : base(instanceUrl, accessToken, apiVersion)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClient"/> class.
        /// </summary>
        /// <param name="instanceUrl">Instance URL of the Salesforce system to connect to.</param>
        /// <param name="accessToken">Application access token.</param>
        /// <param name="apiVersion">API version.</param>
        /// <param name="httpClientForJson">HTTP client used for JSON calls.</param>
        /// <param name="httpClientForXml">HTTP client used for XML calls.</param>
        /// <param name="callerWillDisposeHttpClients">Indicates whether or not the caller will dispose <paramref name="httpClientForJson"/> and <paramref name="httpClientForXml"/>.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceClient(string instanceUrl, string accessToken, string apiVersion, HttpClient httpClientForJson, HttpClient httpClientForXml, bool callerWillDisposeHttpClients = false)
            : base(instanceUrl, accessToken, apiVersion, httpClientForJson, httpClientForXml, callerWillDisposeHttpClients)
        { }
    }
}

