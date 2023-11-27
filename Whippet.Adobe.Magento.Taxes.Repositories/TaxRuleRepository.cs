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
    /// Represents a data repository for mapping <see cref="TaxRule"/> entity objects.
    /// </summary>
    public class TaxRuleRepository : MagentoEntityRestRepository<TaxRule>, ITaxRuleRepository
    {
        private const string TAXRULE_BASE_URL = "taxRules";
        private const string TAXRULE_SEARCH_URL = TAXRULE_BASE_URL + "/search";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public TaxRuleRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken)
        { }

        /// <summary>
        /// Gets the <see cref="TaxRule"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<TaxRule>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<TaxRule> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(TAXRULE_BASE_URL + '/' + key), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxRule>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxRule>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxRule>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="TaxRule"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<TaxRule>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            return await GetAllAsync(CreateEndpointUrl(TAXRULE_SEARCH_URL), CreatePagingSearchCriteria(DefaultPageSize), cancellationToken);

        }

        /// <summary>
        /// Creates a new <see cref="TaxRule"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxRule"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        public override async Task<WhippetResult> CreateAsync(TaxRule item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<TaxRule> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(TAXRULE_BASE_URL), Method.Post);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxRule>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxRule>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxRule>(e);
            }

            return result;
        }

        /// <summary>
        /// Updates the specified <see cref="TaxRule"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxRule"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> UpdateAsync(TaxRule item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<TaxRule> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(new[] { TAXRULE_BASE_URL }), Method.Put);
                request.AddJsonBody<TaxRule>(item);

                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<TaxRule>(WhippetResult.Success, JsonConvert.DeserializeObject<TaxRule>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TaxRule>(e);
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified <see cref="TaxRule"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="TaxRule"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> DeleteAsync(TaxRule item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<bool> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(new[] { TAXRULE_BASE_URL, "/", item.ID.ToString() }), Method.Delete);
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
        /// <param name="key">Unique ID of the <see cref="TaxRule"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<TaxRule>> IWhippetRepository<TaxRule, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="TaxRule"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<TaxRule> IWhippetRepository<TaxRule, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
