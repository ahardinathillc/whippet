using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using Athi.Whippet.ParadoxLabs.Magento.Data;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Subscription"/> entity objects.
    /// </summary>
    public class SubscriptionRepository : ParadoxLabsMagentoEntityRestRepository<Subscription>, ISubscriptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public SubscriptionRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken)
        { }

        /// <summary>
        /// Gets the <see cref="Subscription"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<Subscription> Get(int key)
        {
            return Get(Convert.ToUInt32(key));
        }

        /// <summary>
        /// Gets the <see cref="Subscription"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<Subscription>> GetAsync(int key, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(Convert.ToUInt32(key), cancellationToken);
        }

        /// <summary>
        /// Gets the <see cref="Subscription"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<Subscription>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<Subscription> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(Convert.ToString(key)), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<Subscription>(WhippetResult.Success, JsonConvert.DeserializeObject<Subscription>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Subscription>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="Subscription"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<Subscription>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            return await GetAllAsync(CreateEndpointUrl(SEARCH_ENDPOINT), CreatePagingSearchCriteria(DefaultPageSize), cancellationToken);
        }

        /// <summary>
        /// Creates a new <see cref="Subscription"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Subscription"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        public override async Task<WhippetResult> CreateAsync(Subscription item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<Subscription> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Post);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<Subscription>(WhippetResult.Success, JsonConvert.DeserializeObject<Subscription>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Subscription>(e);
            }

            return result;
        }

        /// <summary>
        /// Updates the specified <see cref="Subscription"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Subscription"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> UpdateAsync(Subscription item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<Subscription> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Put);
                request.AddJsonBody<Subscription>(item);

                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<Subscription>(WhippetResult.Success, JsonConvert.DeserializeObject<Subscription>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Subscription>(e);
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified <see cref="Subscription"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Subscription"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> DeleteAsync(Subscription item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<bool> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(item.ID.ToString()), Method.Delete);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<bool>(WhippetResult.Success, JsonConvert.DeserializeObject<bool>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<bool>(e);
            }

            return result;
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Subscription"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<Subscription>> IWhippetRepository<Subscription, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Subscription"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<Subscription> IWhippetRepository<Subscription, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
