using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using NHibernate;
using RestSharp;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Net.Rest.Extensions;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="MagentoEntity"/> objects accessible by a RESTful interface. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="MagentoEntity"/> object to store in the repository.</typeparam>
    public abstract class MagentoEntityRestRepository<TEntity> : WhippetRestRepository<TEntity, uint>, IWhippetEntityRepository<TEntity, uint>, IWhippetRepository<TEntity, uint>, IWhippetRestRepository<TEntity, uint>, IDisposable, IMagentoEntityRepository<TEntity>
        where TEntity : MagentoEntity, IMagentoEntity, new()
    {
        // Tokens
        private const string TOKEN__SEARCH_CRITERIA = "searchCriteria";
        private const string TOKEN__SEARCH_CRITERIA_SUB = TOKEN__SEARCH_CRITERIA + "[{0}]";
        private const string TOKEN__PAGE_SIZE = "page_size";
        private const string TOKEN__CURRENT_PAGE = "current_page";

        /// <summary>
        /// Represents the querystring token for Magento's search functionality. 
        /// </summary>
        protected const string SEARCH_ENDPOINT = "/search";
        
        private const int DEFAULT_CHUNK_SIZE = 200;

        private int _pageSize;

        /// <summary>
        /// Specifies the default page size when paging large datasets. Set the value less than or equal to zero (0) to reset to the default size.
        /// </summary>
        public virtual int DefaultPageSize
        {
            get
            {
                if (_pageSize <= 0)
                {
                    _pageSize = DEFAULT_CHUNK_SIZE;
                }

                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
        
        /// <summary>
        /// Gets the base URL for the request (e.g., &quot;orders/&quot;). This property is read-only.
        /// </summary>
        protected virtual string BaseUrl
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <exception cref="ArgumentNullException" />
        private MagentoEntityRestRepository(IWhippetRestClient restClient)
            : base(restClient)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoEntityRestRepository(IWhippetRestClient restClient, string bearerToken)
            : this(restClient, bearerToken, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <param name="baseUrl">Base URL of the request (e.g., &quot;orders/&quot;).</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoEntityRestRepository(IWhippetRestClient restClient, string bearerToken, string baseUrl)
            : base(restClient, bearerToken)
        {
            if (String.IsNullOrWhiteSpace(bearerToken))
            {
                throw new ArgumentNullException(nameof(bearerToken));
            }

            BaseUrl = baseUrl;
        }
        
        /// <summary>
        /// Clamps the specified unsigned integer value if it exceeds <see cref="UInt16.MaxValue"/>.
        /// </summary>
        /// <param name="value"><see cref="UInt32"/> value to clamp.</param>
        /// <returns><see cref="UInt16"/> value.</returns>
        protected UInt16 ClampUnsignedInteger(uint value)
        {
            return (value > UInt16.MaxValue) ? UInt16.MaxValue : Convert.ToUInt16(value);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<TEntity> Get(uint id)
        {
            return Task.Run(() => GetAsync(id)).Result;
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        public override WhippetResultContainer<IEnumerable<TEntity>> GetAll()
        {
            return Task.Run(() => GetAllAsync()).Result;
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Create(TEntity item)
        {
            return Task.Run(() => CreateAsync(item)).Result;
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Update(TEntity item)
        {
            return Task.Run(() => UpdateAsync(item)).Result;
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Delete(TEntity item)
        {
            return Task.Run(() => DeleteAsync(item)).Result;
        }

        /// <summary>
        /// Creates a Magento endpoint URL (i.e., &quot;/rest/V1/&quot;) using the value stored in <see cref="BaseUrl"/>.
        /// </summary>
        /// <returns>Magento endpoint URL.</returns>
        /// <exception cref="ArgumentNullException" />
        protected string CreateEndpointUrl()
        {
            return CreateEndpointUrl(BaseUrl);
        }
        
        /// <summary>
        /// Creates a Magento endpoint URL (i.e., &quot;/rest/V1/&quot;).
        /// </summary>
        /// <param name="endpoint">Endpoint to append to the URL.</param>
        /// <param name="isQuery">If <see langword="true"/>, the endpoint URL will be formatted as a querystring.</param>
        /// <returns>Magento endpoint URL.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual string CreateEndpointUrl(string endpoint, bool isQuery = false)
        {
            if (String.IsNullOrWhiteSpace(endpoint) && String.IsNullOrWhiteSpace(BaseUrl))
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                StringBuilder builder = new StringBuilder("/rest/V1/");

                if (!String.IsNullOrWhiteSpace(BaseUrl) && !String.IsNullOrWhiteSpace(endpoint))
                {
                    if (BaseUrl.EndsWith('/') || BaseUrl.EndsWith('?'))
                    {
                        if (endpoint.Length > 1 && (endpoint.StartsWith('/') || endpoint.StartsWith('?')))
                        {
                            endpoint = endpoint.Substring(1);
                        }
                        else
                        {
                            endpoint = String.Empty;
                        }
                    }
                }

                if (!String.IsNullOrWhiteSpace(BaseUrl))
                {
                    builder.Append(BaseUrl);
                    
                    if (isQuery && !builder.ToString().EndsWith('?'))
                    {
                        builder.Append('?');
                    }
                    else if (!isQuery && !builder.ToString().EndsWith('/'))
                    {
                        builder.Append('/');
                    }
                }
                
                builder.Append(endpoint);

                return builder.ToString().Trim();
            }
        }
        
        /// <summary>
        /// Creates a Magento endpoint URL (i.e., &quot;/rest/async/bulk/V1/&quot;) for bulk operations.
        /// </summary>
        /// <param name="endpoint">Endpoint to append to the URL.</param>
        /// <returns>Magento bulk endpoint URL.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual string CreateBulkEndpointUrl(string endpoint)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(endpoint);
            return "/rest/async/bulk/V1/" + endpoint;
        }

        /// <summary>
        /// Creates a Magento endpoint URL (i.e., &quot;/rest/<paramref name="storeCode"/>/V1/bulk/&quot;) for checking the status of one or more bulk operations.
        /// </summary>
        /// <param name="storeCode">Store code.</param>
        /// <returns>Magento bulk status URL.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual string CreateBulkStatusUrl(string storeCode)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(storeCode);
            return "/rest/" + storeCode + "/V1/bulk/";
        }

        /// <summary>
        /// Creates a Magento endpoint URL for checking the status of bulk operations.
        /// </summary>
        /// <param name="storeCode">Store code. This can be found under the store settings.</param>
        /// <param name="endpoint">Endpoint parameters, such as search criteria.</param>
        /// <returns>Magento bulk status endpoint URL.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string CreateBulkStatusEndpointUrl(string storeCode, string endpoint = "?")
        {
            if (String.IsNullOrWhiteSpace(storeCode))
            {
                throw new ArgumentNullException(nameof(storeCode));
            }
            else
            {
                //return "/rest/" + storeCode.Trim() + "/V1/bulk/" + endpoint;
                return "/rest/V1/bulk/" + endpoint;
            }
        }

        /// <summary>
        /// Creates a Magento endpoint URL (i.e., &quot;/rest/V1/&quot;) with the specified <see cref="String"/> collection.
        /// </summary>
        /// <param name="pieces"><see cref="String"/> collection.</param>
        /// <returns>Magento endpoint URL.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string CreateEndpointUrl(IEnumerable<string> pieces)
        {
            if (pieces == null)
            {
                throw new ArgumentNullException(nameof(pieces));
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                bool first = true;

                foreach (string piece in pieces)
                {
                    if (first)
                    {
                        builder.Append(CreateEndpointUrl(piece));
                        first = false;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(piece))
                        {
                            if (!piece.StartsWith('/'))
                            {
                                builder.Append('/');
                            }

                            builder.Append(piece);
                        }
                    }
                }

                builder.Replace("//", "/");

                return builder.ToString();
            }
        }
        
        /// <summary>
        /// Creates a Magento endpoint URL (i.e., &quot;/rest/V1/&quot;) for bulk operations with the specified <see cref="String"/> collection.
        /// </summary>
        /// <param name="pieces"><see cref="String"/> collection.</param>
        /// <returns>Magento endpoint URL.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string CreateBulkEndpointUrl(IEnumerable<string> pieces)
        {
            if (pieces == null)
            {
                throw new ArgumentNullException(nameof(pieces));
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                bool first = true;

                foreach (string piece in pieces)
                {
                    if (first)
                    {
                        builder.Append(CreateBulkEndpointUrl(piece));
                        first = false;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(piece))
                        {
                            if (!piece.StartsWith('/'))
                            {
                                builder.Append('/');
                            }

                            builder.Append(piece);
                        }
                    }
                }

                builder.Replace("//", "/");

                return builder.ToString();
            }
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ITransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> of the transaction.</param>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ITransaction BeginStatelessTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> of the transaction.</param>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ITransaction BeginStatelessTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a search criteria query string parameter for querying the Magento REST API.
        /// </summary>
        /// <param name="parameterNameAndValue">Parameter name and value.</param>
        /// <param name="filterGroupPosition">Filter group position (where applicable).</param>
        /// <param name="filterPosition">Filter position (where applicable).</param>
        /// <param name="concatenate">If <see langword="true"/>, will append the output string with an ampersand.</param>
        /// <returns>Search criteria query string.</returns>
        [Obsolete("This method is obsolete and will be removed in a future version. Use MagentoSearchCriteria instead.")]
        protected virtual string CreateSearchCriteria(KeyValuePair<string, string> parameterNameAndValue, int? filterGroupPosition = null, int? filterPosition = null, bool concatenate = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("searchCriteria[filter_groups]");

            if (filterGroupPosition.HasValue)
            {
                builder.Append("[" + filterGroupPosition.Value + "]");
            }

            builder.Append("[filters]");

            if (filterPosition.HasValue)
            {
                builder.Append("[" + filterPosition.Value + "]");
            }

            if (!parameterNameAndValue.Key.StartsWith('['))
            {
                builder.Append('[');
            }

            builder.Append(parameterNameAndValue.Key);

            if (!parameterNameAndValue.Key.EndsWith(']'))
            {
                builder.Append(']');
            }

            builder.Append('=');
            builder.Append(parameterNameAndValue.Value);

            if (concatenate)
            {
                builder.Append('&');
            }

            return builder.ToString();
        }

        /// <summary>
        /// Creates a [searchCriteria] parameter as a <see cref="KeyValuePair{TKey, TValue}"/> with a page size that can be assigned directly to the request URL or to a parameter object.
        /// </summary>
        /// <param name="pageSize">Page size of the results returned.</param>
        /// <returns><see cref="KeyValuePair{TKey, TValue}"/> instance containing the [searchCriteria] parameter.</returns>
        [Obsolete("This method is obsolete and will be removed in a future version. Use MagentoSearchCriteria instead.")]
        protected virtual KeyValuePair<string, string> CreatePagingSearchCriteria(int pageSize)
        {
            return new KeyValuePair<string, string>(String.Format(TOKEN__SEARCH_CRITERIA_SUB, TOKEN__PAGE_SIZE), Convert.ToString(pageSize));
        }

        /// <summary>
        /// Creates a [searchCriteria] parameter as a <see cref="KeyValuePair{TKey, TValue}"/> with the current page that can be assigned directly to the request URL or to a parameter object.
        /// </summary>
        /// <param name="currentPage">Current page of the results to return.</param>
        /// <returns><see cref="KeyValuePair{TKey, TValue}"/> instance containing the [searchCriteria] parameter.</returns>
        [Obsolete("This method is obsolete and will be removed in a future version. Use MagentoSearchCriteria instead.")]
        protected virtual KeyValuePair<string, string> CreateCurrentPageSearchCriteria(int currentPage)
        {
            return new KeyValuePair<string, string>(String.Format(TOKEN__SEARCH_CRITERIA_SUB, TOKEN__CURRENT_PAGE), Convert.ToString(currentPage));
        }

        /// <summary>
        /// Asynchronously retrieves all <typeparamref name="TEntity"/> objects in Magento using paging.
        /// </summary>
        /// <param name="url">URL to submit the request to.</param>
        /// <param name="searchPageSize">Paging query parameter and value.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual async Task<WhippetResultContainer<IEnumerable<TEntity>>> GetAllAsync(string url, KeyValuePair<string, string> searchPageSize, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            else
            {
                WhippetResultContainer<IEnumerable<TEntity>> result = null;

                RestRequest request = null;
                RestResponse response = null;

                //KeyValuePair<string, string> emptySearch = CreateNullSearchCriteria();

                KeyValuePair<string, string> searchCurrentPage = default(KeyValuePair<string, string>);

                int currentPage = 1;

                List<TEntity> responseContent = null;

                MagentoJsonSearchResultItemContainer<TEntity> container = null;

                try
                {
                    do
                    {
                        searchCurrentPage = CreateCurrentPageSearchCriteria(currentPage);

                        request = CreateRequest(url, Method.Get);
                        request.AddOrUpdateParameter(searchPageSize.Key, searchPageSize.Value);
                        request.AddOrUpdateParameter(searchCurrentPage.Key, searchCurrentPage.Value);

                        response = await Client.ExecuteAsync(request);

                        response.ThrowIfError();

                        if (response.IsOkStatus())
                        {
                            container = new MagentoJsonSearchResultItemContainer<TEntity>(response.Content);

                            if (container.Count > 0)
                            {
                                if (responseContent == null)
                                {
                                    responseContent = new List<TEntity>(container.TotalCount);
                                }

                                responseContent.AddRange(container);

                                if (responseContent.Count < DefaultPageSize)
                                {
                                    currentPage = -1;
                                }
                                else
                                {
                                    currentPage++;
                                }
                            }
                            else
                            {
                                currentPage = 0;
                            }
                        }
                        else
                        {
                            throw new Exception(response.StatusDescription);
                        }
                    } while (currentPage >= 1);

                    result = new WhippetResultContainer<IEnumerable<TEntity>>(WhippetResult.Success, responseContent);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<TEntity>>(e);
                }

                return result;
            }
        }

        // TODO: Remove the bulk op status and move them into their own class
        
        /// <summary>
        /// Gets the bulk operation status based on the unique ID of the operation.
        /// </summary>
        /// <param name="responseViewModel"><see cref="MagentoBulkOperationResponseViewModel"/> object that contains the ID of the bulk operation.</param>
        /// <param name="storeCode">Store code.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<MagentoBulkOperationStatusViewModel> GetBulkOperationStatus(MagentoBulkOperationResponseViewModel responseViewModel, string storeCode)
        {
            if (responseViewModel == null)
            {
                throw new ArgumentNullException(nameof(responseViewModel));
            }
            else if (String.IsNullOrEmpty(storeCode))
            {
                throw new ArgumentNullException(nameof(storeCode));
            }
            else
            {
                return Task.Run(() => GetBulkOperationStatusAsync(responseViewModel, storeCode)).Result;
            }
        }

        /// <summary>
        /// Gets the bulk operation status based on the unique ID of the operation.
        /// </summary>
        /// <param name="responseViewModel"><see cref="MagentoBulkOperationResponseViewModel"/> object that contains the ID of the bulk operation.</param>
        /// <param name="storeCode">Store code.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<MagentoBulkOperationStatusViewModel>> GetBulkOperationStatusAsync(MagentoBulkOperationResponseViewModel responseViewModel, string storeCode)
        {
            if (responseViewModel == null)
            {
                throw new ArgumentNullException(nameof(responseViewModel));
            }
            else if (String.IsNullOrEmpty(storeCode))
            {
                throw new ArgumentNullException(nameof(storeCode));
            }
            else
            {
                WhippetResultContainer<MagentoBulkOperationStatusViewModel> result = null;

                RestRequest request = null;
                RestResponse response = null;

                MagentoSearchCriteria criteria = null;

                try
                {
                    criteria = new MagentoSearchCriteria();
                    criteria.AddCriterion(MagentoSearchCriteriaConditionType.Field.Create("bulk_uuid"), MagentoSearchCriteriaConditionType.SearchValue.Create(responseViewModel.BulkID.ToString()), MagentoSearchCriteriaConditionType.EqualsCondition.Create());

                    request = CreateRequest(CreateBulkStatusEndpointUrl(storeCode) + criteria.ToString(true), Method.Get);
                    response = await Client.ExecuteAsync(request);

                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        result = new WhippetResultContainer<MagentoBulkOperationStatusViewModel>(WhippetResult.Success, JsonConvert.DeserializeObject<MagentoBulkOperationStatusViewModel>(response.Content));
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<MagentoBulkOperationStatusViewModel>(e);
                }

                return result;
            }
        }
    }
}
