using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using NHibernate;
using RestSharp;
using Athi.Whippet.Net.Rest;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="WhippetEntity"/> objects that are stored on a remote server accessed via a RESTful interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of object to store in the repository.</typeparam>
    /// <typeparam name="TKey">Non-nullable type of key that <typeparamref name="TEntity"/> uses.</typeparam>
    public abstract class WhippetRestRepository<TEntity, TKey> : WhippetRepository<TEntity, TKey>, IWhippetRestRepository<TEntity, TKey>, IWhippetEntityRepository<TEntity, TKey>, IDisposable
        where TEntity : class
        where TKey : struct
    {
        private string _bearer;

        /// <summary>
        /// Gets the authorization bearer token for making requests. This property is read-only.
        /// </summary>
        public string BearerToken
        {
            get
            {
                return _bearer;
            }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    if (value.Contains('"'))
                    {
                        value = value.Replace('"', ' ');
                        value = value.Trim();
                    }
                }

                _bearer = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetRestClient"/> instance that provides access to the current application's RESTful context. This property is read-only.
        /// </summary>
        protected IWhippetRestClient Client
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRestRepository{TKey, TEntity}"/> class with no arguments.
        /// </summary>
        private WhippetRestRepository()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRestRepository{TKey, TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetRestRepository(IWhippetRestClient restClient)
            : this(restClient, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRestRepository{TKey, TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetRestRepository(IWhippetRestClient restClient, string bearerToken = null)
            : this()
        {
            ArgumentNullException.ThrowIfNull(restClient);
            Client = restClient;
            BearerToken = bearerToken;
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public virtual void Dispose()
        {
            if (Client != null)
            {
                Client.Dispose();
                Client = null;
            }
        }

        /// <summary>
        /// Creates a new <see cref="RestRequest"/> for the specified endpoint.
        /// </summary>
        /// <param name="endpoint">REST endpoint to submit the request to.</param>
        /// <param name="method">HTTP method.</param>
        /// <returns><see cref="RestRequest"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual RestRequest CreateRequest(string endpoint, Method method)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(endpoint);
            return CreateRequest(endpoint, method, BearerToken);
        }

        /// <summary>
        /// Creates a new <see cref="RestRequest"/> for the specified endpoint.
        /// </summary>
        /// <param name="endpoint">REST endpoint to submit the request to.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="bearerToken">Authorization bearer token to apply to the request.</param>
        /// <returns><see cref="RestRequest"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual RestRequest CreateRequest(string endpoint, Method method, string bearerToken)
        {
            if (String.IsNullOrWhiteSpace(endpoint))
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                RestRequest request = new RestRequest(endpoint, method);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                request.RequestFormat = DataFormat.Json;

                if (!String.IsNullOrWhiteSpace(bearerToken))
                {
                    request.AddHeader("Authorization", "Bearer " + bearerToken);
                }


                return request;
            }
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, TKey>.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> of the transaction.</param>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, TKey>.BeginTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, TKey>.BeginStatelessTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> of the transaction.</param>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, TKey>.BeginStatelessTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance. This method must be overridden.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        public override void RefreshEntityContext(TEntity entity)
        { }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance. This method must be overridden.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
#pragma warning disable CS1998
        public override async Task RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken = null)
        { }
#pragma warning restore CS1998
    }
}
