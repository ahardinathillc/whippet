using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Repositories;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using Newtonsoft.Json.Linq;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxRate"/> entity objects.
    /// </summary>
    public class TaxRateRepository : MagentoEntityRestRepository<TaxRate>, ITaxRateRepository, IMagentoBulkSupport<TaxRate>
    {
        private const string TAXRATE_BASE_URL = "taxRates";
        private const string TAXRATE_SEARCH_URL = TAXRATE_BASE_URL + "/search";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public TaxRateRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken)
        { }

        /// <summary>
        /// Gets the <see cref="TaxRate"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<TaxRate> Get(int key)
        {
            return Get(Convert.ToUInt32(key));
        }

        /// <summary>
        /// Gets the <see cref="TaxRate"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<TaxRate>> GetAsync(int key, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(Convert.ToUInt32(key), cancellationToken);
        }

        /// <summary>
        /// Gets the <see cref="TaxRate"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<TaxRate>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<TaxRate> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(TAXRATE_BASE_URL + '/' + key), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxRate>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxRate>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxRate>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronusly retrieves all <see cref="TaxRate"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<TaxRate>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            return await GetAllAsync(CreateEndpointUrl(TAXRATE_SEARCH_URL), CreatePagingSearchCriteria(DefaultPageSize), cancellationToken);
        }

        /// <summary>
        /// Creates a new <see cref="TaxRate"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxRate"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        public override async Task<WhippetResult> CreateAsync(TaxRate item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<TaxRate> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(TAXRATE_BASE_URL), Method.Post);
                //request = request.AddJsonBody(item.ToMagentoJsonString(), false);
                request = request.AddStringBody(item.ToMagentoJsonString(), DataFormat.Json);

                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxRate>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxRate>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxRate>(e);
            }

            return result;
        }

        /// <summary>
        /// Updates the specified <see cref="TaxRate"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxRate"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> UpdateAsync(TaxRate item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<TaxRate> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(new[] { TAXRATE_BASE_URL }), Method.Post);
                request.AddJsonBody(item.ToMagentoJsonString(), false);
                
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxRate>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxRate>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxRate>(e);
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified <see cref="TaxRate"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxRate"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> DeleteAsync(TaxRate item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<bool> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(new[] { TAXRATE_BASE_URL, "/", item.ID.ToString() }), Method.Delete);
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
        /// Adds the specified collection of <see cref="TaxRate"/> objects to the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkAdd(IEnumerable<TaxRate> objects)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }
            else
            {
                return Task.Run(() => BulkAddAsync(objects)).Result;
            }
        }

        /// <summary>
        /// Adds the specified collection of <see cref="TaxRate"/> objects to the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkAddAsync(IEnumerable<TaxRate> objects, CancellationToken? cancellationToken = null)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }
            else
            {
                WhippetResultContainer<MagentoBulkOperationResponseViewModel> result = null;

                RestRequest request = null;
                RestResponse response = null;

                try
                {
                    request = CreateRequest(CreateBulkEndpointUrl(new[] { TAXRATE_BASE_URL }), Method.Post);
                    request.AddStringBody(JsonConvert.SerializeObject(objects.Select(rate => JObject.Parse(rate.ToMagentoJsonString()))), DataFormat.None);

                    response = await Client.ExecuteAsync(request);

                    response.ThrowIfError();

                    result = new WhippetResultContainer<MagentoBulkOperationResponseViewModel>(WhippetResult.Success, JsonConvert.DeserializeObject<MagentoBulkOperationResponseViewModel>(response.Content));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<MagentoBulkOperationResponseViewModel>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Deletes the specified collection of <see cref="TaxRate"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkDelete(IEnumerable<TaxRate> objects)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }
            else
            {
                return Task.Run(() => BulkDeleteAsync(objects)).Result;
            }
        }

        /// <summary>
        /// Deletes the specified collection of <see cref="TaxRate"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkDeleteAsync(IEnumerable<TaxRate> objects, CancellationToken? cancellationToken = null)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }
            else
            {
                WhippetResultContainer<MagentoBulkOperationResponseViewModel> result = null;

                RestRequest request = null;
                RestResponse response = null;

                try
                {
                    request = CreateRequest(CreateBulkEndpointUrl(new[] { TAXRATE_BASE_URL }), Method.Delete);
                    request.AddStringBody(JsonConvert.SerializeObject(objects.Select(rate => JObject.Parse(rate.ToMagentoJsonString()))), DataFormat.Json);

                    response = await Client.ExecuteAsync(request);

                    response.ThrowIfError();

                    result = new WhippetResultContainer<MagentoBulkOperationResponseViewModel>(WhippetResult.Success, JsonConvert.DeserializeObject<MagentoBulkOperationResponseViewModel>(response.Content));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<MagentoBulkOperationResponseViewModel>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Updates the specified collection of <see cref="TaxRate"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkUpdate(IEnumerable<TaxRate> objects)
        {
            return BulkAdd(objects);
        }

        /// <summary>
        /// Updates the specified collection of <see cref="TaxRate"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkUpdateAsync(IEnumerable<TaxRate> objects, CancellationToken? cancellationToken = null)
        {
            return await BulkAddAsync(objects, cancellationToken);
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="TaxRate"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<TaxRate>> IWhippetRepository<TaxRate, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="TaxRate"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<TaxRate> IWhippetRepository<TaxRate, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
