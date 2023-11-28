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

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxClass"/> entity objects.
    /// </summary>
    public class TaxClassRepository : MagentoEntityRestRepository<TaxClass>, ITaxClassRepository
    {
        private const string TAXCLASS_BASE_URL = "taxClasses";
        private const string TAXCLASS_SEARCH_URL = TAXCLASS_BASE_URL + "/search";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public TaxClassRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken, TAXCLASS_BASE_URL)
        { }

        /// <summary>
        /// Gets the <see cref="TaxClass"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<TaxClass> Get(int key)
        {
            return Get(Convert.ToUInt32(key));
        }

        /// <summary>
        /// Gets the <see cref="TaxClass"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<TaxClass>> GetAsync(int key, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(Convert.ToUInt32(key), cancellationToken);
        }

        /// <summary>
        /// Gets the <see cref="TaxClass"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<TaxClass>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<TaxClass> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(TAXCLASS_BASE_URL + '/' + key), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxClass>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxClass>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxClass>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="TaxClass"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<TaxClass>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            return await GetAllAsync(CreateEndpointUrl(TAXCLASS_SEARCH_URL), CreatePagingSearchCriteria(DefaultPageSize), cancellationToken);
        }

        /// <summary>
        /// Creates a new <see cref="TaxClass"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxClass"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        public override async Task<WhippetResult> CreateAsync(TaxClass item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<TaxClass> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(TAXCLASS_BASE_URL), Method.Post);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxClass>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxClass>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxClass>(e);
            }

            return result;
        }

        /// <summary>
        /// Updates the specified <see cref="TaxClass"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxClass"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> UpdateAsync(TaxClass item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<TaxClass> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(new[] { TAXCLASS_BASE_URL }), Method.Put);
                request.AddJsonBody<TaxClass>(item);

                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxClass>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxClass>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxClass>(e);
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified <see cref="TaxClass"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxClass"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> DeleteAsync(TaxClass item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<bool> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(new[] { TAXCLASS_BASE_URL, "/", item.ID.ToString() }), Method.Delete);
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
        /// <param name="key">Unique ID of the <see cref="TaxClass"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<TaxClass>> IWhippetRepository<TaxClass, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="TaxClass"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<TaxClass> IWhippetRepository<TaxClass, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
