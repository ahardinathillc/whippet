using System;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using RestSharp.Serializers;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides a way to connect to a Magento instance via a RESTful interface. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoRestClient : IDisposable, IWhippetRestClient, IRestClient
    {
        private const string DEFAULT_ADMIN_TOKEN_ENDPOINT = "/rest/V1/integration/admin/token";

        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetRestClient"/> used to make connections to the Magento server.
        /// </summary>
        private IWhippetRestClient InternalClient
        { get; set; }

        /// <summary>
        /// Client options that aren't used for configuring the HTTP client. This property is read-only.
        /// </summary>
        public ReadOnlyRestClientOptions Options
        {
            get
            {
                return InternalClient.Options;
            }
        }

        /// <summary>
        /// Client-level serializers. This property is read-only.
        /// </summary>
        public RestSerializers Serializers
        {
            get
            {
                return InternalClient.Serializers;
            }
        }

        /// <summary>
        /// Default parameters to use on every request made with this client instance. This property is read-only.
        /// </summary>
        public DefaultParameters DefaultParameters
        {
            get
            {
                return InternalClient.DefaultParameters;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestClient"/> class with no arguments.
        /// </summary>
        private MagentoRestClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestClient"/> class with the specified URL to the Magento REST API.
        /// </summary>
        /// <param name="magentoUrl">URL to the Magento REST API.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoRestClient(string magentoUrl)
            : this()
        {
            if (String.IsNullOrWhiteSpace(magentoUrl))
            {
                throw new ArgumentNullException(nameof(magentoUrl));
            }
            else
            {
                InternalClient = new WhippetRestClient(magentoUrl);
            }
        }

        /// <summary>
        /// Retrieves the admin bearer token for the specified username and password.
        /// </summary>
        /// <param name="userName">Username of the account.</param>
        /// <param name="password">Password of the account.</param>
        /// <returns>Bearer token value.</returns>
        /// <exception cref="Exception" />
        /// <exception cref="ArgumentNullException"></exception>
        public string GetAdminToken(string userName, string password)
        {
            return GetAdminToken(userName, password, null);
        }

        /// <summary>
        /// Retrieves the admin bearer token for the specified username and password.
        /// </summary>
        /// <param name="userName">Username of the account.</param>
        /// <param name="password">Password of the account.</param>
        /// <param name="adminTokenEndpoint">REST endpoint that retrieves the bearer token.</param>
        /// <returns>Bearer token value.</returns>
        /// <exception cref="Exception" />
        /// <exception cref="ArgumentNullException"></exception>
        public string GetAdminToken(string userName, string password, string adminTokenEndpoint)
        {
            return Task.Run(() => GetAdminTokenAsync(userName, password, adminTokenEndpoint)).Result;
        }

        /// <summary>
        /// Retrieves the admin bearer token for the specified username and password.
        /// </summary>
        /// <param name="userName">Username of the account.</param>
        /// <param name="password">Password of the account.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Bearer token value.</returns>
        /// <exception cref="Exception" />
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> GetAdminTokenAsync(string userName, string password, CancellationToken cancellationToken = default)
        {
            return await GetAdminTokenAsync(userName, password, null);
        }

        /// <summary>
        /// Retrieves the admin bearer token for the specified username and password.
        /// </summary>
        /// <param name="userName">Username of the account.</param>
        /// <param name="passWord">Password of the account.</param>
        /// <param name="adminTokenEndpoint">REST endpoint that retrieves the bearer token.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Bearer token value.</returns>
        /// <exception cref="Exception" />
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> GetAdminTokenAsync(string userName, string passWord, string adminTokenEndpoint, CancellationToken cancellationToken = default)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            else if (String.IsNullOrWhiteSpace(passWord))
            {
                throw new ArgumentNullException(nameof(passWord));
            }
            else
            {
                RestResponse response = null;
                RestRequest request = new RestRequest(String.IsNullOrWhiteSpace(adminTokenEndpoint) ? DEFAULT_ADMIN_TOKEN_ENDPOINT : adminTokenEndpoint, Method.Post);

                var credentials = new
                {
                    username = userName,
                    password = passWord
                };

                string jsonCredentials = JsonConvert.SerializeObject(credentials);

                request.RequestFormat = DataFormat.Json;

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                request.AddParameter("application/json", jsonCredentials, ParameterType.RequestBody);

                response = await InternalClient.ExecuteAsync(request, cancellationToken);
                response.ThrowIfError();

                return response.Content;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public void Dispose()
        {
            if (InternalClient != null)
            {
                InternalClient.Dispose();
                InternalClient = null;
            }
        }

        /// <summary>
        /// Executes the request asynchronously.
        /// </summary>
        /// <param name="request">Request to execute.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="RestResponse"/> object.</returns>
        public async Task<RestResponse> ExecuteAsync(RestRequest request, CancellationToken cancellationToken = default)
        {
            return await InternalClient.ExecuteAsync(request, cancellationToken);
        }

        /// <summary>
        /// Asynchronously downloads file(s) as streams.
        /// </summary>
        /// <param name="request">Request to execute.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Stream"/> object.</returns>
        public async Task<Stream?> DownloadStreamAsync(RestRequest request, CancellationToken cancellationToken = default)
        {
            return await InternalClient.DownloadStreamAsync(request, cancellationToken);
        }
    }
}