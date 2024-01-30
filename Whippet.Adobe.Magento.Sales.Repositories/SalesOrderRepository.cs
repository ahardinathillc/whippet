using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using Athi.Whippet.Data;

namespace Athi.Whippet.Adobe.Magento.Sales.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesOrder"/> entity objects.
    /// </summary>
    public class SalesOrderRepository : MagentoEntityRestRepository<SalesOrder>, ISalesOrderRepository
    {
        private const string BASE_URL = "orders/";

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesOrderRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken, BASE_URL)
        { }

        /// <summary>
        /// Gets the <see cref="SalesOrder"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<SalesOrder> Get(int key)
        {
            return Get(Convert.ToUInt32(key));
        }

        /// <summary>
        /// Gets the <see cref="SalesOrder"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<SalesOrder>> GetAsync(int key, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(Convert.ToUInt32(key), cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="salesOrderId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<SalesOrder>> GetAsync(uint salesOrderId, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesOrder> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(Convert.ToString(salesOrderId)), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<SalesOrder>(WhippetResult.Success, JsonConvert.DeserializeObject<SalesOrder>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesOrder>(e);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date (and time) interval.</param>
        /// <param name="toDate">Ending date (and time) interval.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<IEnumerable<SalesOrder>> Get(Instant fromDate, Instant toDate)
        {
            return Task.Run(() => GetAsync(fromDate, toDate)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date (and time) interval.</param>
        /// <param name="toDate">Ending date (and time) interval.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<SalesOrder>>> GetAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesOrder>> result = null;

            RestRequest request = null;
            RestResponse response = null;

            StringBuilder builder = null;

            MagentoJsonSearchResultItemContainer<SalesOrder> orders = null;

            try
            {
                builder = new StringBuilder();

                builder.Append(CreateSearchCriteria(new KeyValuePair<string, string>("field", "created_at"), 0, 0, true));
                builder.Append(CreateSearchCriteria(new KeyValuePair<string, string>("condition_type", MagentoRestSearchConditionType.GreaterThanEqual), 0, 0, true));
                builder.Append(CreateSearchCriteria(new KeyValuePair<string, string>("value", fromDate.ToString("uuu-MM-dd HH:mm:ss", null)), 0, 0, true));
                builder.Append(CreateSearchCriteria(new KeyValuePair<string, string>("field", "created_at"), 1, 0, true));
                builder.Append(CreateSearchCriteria(new KeyValuePair<string, string>("condition_type", MagentoRestSearchConditionType.LessThanEqual), 1, 0, true));
                builder.Append(CreateSearchCriteria(new KeyValuePair<string, string>("value", toDate.ToString("uuu-MM-dd HH:mm:ss", null)), 1, 0, false));

                request = CreateRequest(CreateEndpointUrl(builder.ToString(), true), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    orders = new MagentoJsonSearchResultItemContainer<SalesOrder>(response.Content);
                    result = new WhippetResultContainer<IEnumerable<SalesOrder>>(WhippetResult.Success, orders);
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesOrder>>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronusly retrieves all <see cref="SalesOrder"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<SalesOrder>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesOrder>> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                MagentoSearchCriteria searchCriteria = new MagentoSearchCriteria();

                request = CreateRequest(CreateEndpointUrl(MagentoSearchCriteria.All.ToString()), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<IEnumerable<SalesOrder>>(WhippetResult.Success, JsonConvert.DeserializeObject<List<SalesOrder>>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesOrder>>(e);
            }

            return result;
        }

        /// <summary>
        /// Creates a new <see cref="SalesOrder"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="SalesOrder"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> CreateAsync(SalesOrder item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<SalesOrder> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl("create"), Method.Put);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<SalesOrder>(WhippetResult.Success, JsonConvert.DeserializeObject<SalesOrder>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesOrder>(e);
            }

            return result;
        }

        /// <summary>
        /// Updates an existing <see cref="SalesOrder"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="SalesOrder"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> UpdateAsync(SalesOrder item, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(item);

            WhippetResultContainer<SalesOrder> result = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Post);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    result = new WhippetResultContainer<SalesOrder>(WhippetResult.Success, JsonConvert.DeserializeObject<SalesOrder>(response.Content));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesOrder>(e);
            }

            return result;
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="item"><see cref="SalesOrder"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<WhippetResult> DeleteAsync(SalesOrder item, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="SalesOrder"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<SalesOrder>> IWhippetRepository<SalesOrder, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="SalesOrder"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<SalesOrder> IWhippetRepository<SalesOrder, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
