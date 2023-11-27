using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="StoreConfiguration"/> objects.
    /// </summary>
    public class StoreConfigurationRepository : MagentoEntityRestRepository<StoreConfiguration>, IStoreConfigurationRepository
    {
        private const string BASE_URL = "store/storeConfigs";
        private const string PARAM_STORE_CODES = "storeCodes";
        
        /// <summary>
        /// Loads a <see cref="Store"/> object based on a given ID.
        /// </summary>
        protected readonly Func<uint, Task<WhippetResultContainer<Store>>> _LoadStoreAsync;

        /// <summary>
        /// Loads all <see cref="Store"/> objects in the system.
        /// </summary>
        protected readonly Func<Task<WhippetResultContainer<IEnumerable<Store>>>> _LoadAllStoresAsync;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreConfigurationRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <param name="storeLoaderDelegate"><see cref="Func{T1, TResult}"/> that loads a <see cref="Store"/> object based on a given ID.</param>
        /// <param name="allStoreLoaderDelegate"><see cref="Func{TResult}"/> that loads all <see cref="Store"/> objects in the system.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreConfigurationRepository(IWhippetRestClient restClient, string bearerToken, Func<uint, Task<WhippetResultContainer<Store>>> storeLoaderDelegate, Func<Task<WhippetResultContainer<IEnumerable<Store>>>> allStoreLoaderDelegate)
            : base(restClient, bearerToken, BASE_URL)
        {
            ArgumentNullException.ThrowIfNull(storeLoaderDelegate);
            ArgumentNullException.ThrowIfNull(allStoreLoaderDelegate);
            
            _LoadStoreAsync = storeLoaderDelegate;
            _LoadAllStoresAsync = allStoreLoaderDelegate;
        }

        /// <summary>
        /// Gets the <see cref="StoreConfiguration"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<StoreConfiguration>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<StoreConfiguration> result = null;
            WhippetResultContainer<Store> storeResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreConfigurationInterface> configInterfaces = null;
            
            try
            {
                storeResult = await _LoadStoreAsync(key);
                storeResult.ThrowIfFailed();
                storeResult.ThrowIfObjectNotFound(key);

                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                request.Parameters.AddParameter(new QueryParameter(PARAM_STORE_CODES, CreateParameterArray(storeResult.Item.Code)));
                
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    configInterfaces = JsonConvert.DeserializeObject<List<StoreConfigurationInterface>>(response.Content);

                    if (configInterfaces != null && configInterfaces.Count > 0)
                    {
                        result = new WhippetResultContainer<StoreConfiguration>(WhippetResult.Success, new StoreConfiguration(configInterfaces.First()));
                    }
                    else
                    {
                        result = new WhippetResultContainer<StoreConfiguration>(WhippetResult.Success, null);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<StoreConfiguration>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="StoreConfiguration"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<StoreConfiguration>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<StoreConfiguration>> result = null;
            WhippetResultContainer<IEnumerable<Store>> storeResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreConfigurationInterface> configInterfaces = null;
            
            try
            {
                storeResult = await _LoadAllStoresAsync();
                storeResult.ThrowIfFailed();

                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                request.Parameters.AddParameter(new QueryParameter(PARAM_STORE_CODES, CreateParameterArray(storeResult.Item.Select(s => s.Code))));
                
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    configInterfaces = JsonConvert.DeserializeObject<List<StoreConfigurationInterface>>(response.Content);
                    
                    if (configInterfaces != null && configInterfaces.Count > 0)
                    {
                        result = new WhippetResultContainer<IEnumerable<StoreConfiguration>>(WhippetResult.Success, configInterfaces.Select(ci => new StoreConfiguration(ci)));
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<StoreConfiguration>>(WhippetResult.Success, Enumerable.Empty<StoreConfiguration>());
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<StoreConfiguration>>(e);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the <see cref="StoreConfiguration"/> object with the specified <see cref="Store"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve the configuration for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<StoreConfiguration> Get(string code)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            return Task.Run(() => GetAsync(code)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<StoreConfiguration>> GetAsync(string code, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                WhippetResultContainer<StoreConfiguration> result = null;

                RestRequest request = null;
                RestResponse response = null;

                List<StoreConfigurationInterface> configInterfaces = null;

                try
                {
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    request.Parameters.AddParameter(new QueryParameter(PARAM_STORE_CODES, CreateParameterArray(code)));

                    response = await Client.ExecuteAsync(request);

                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        configInterfaces = JsonConvert.DeserializeObject<List<StoreConfigurationInterface>>(response.Content);

                        if (configInterfaces != null && configInterfaces.Count > 0)
                        {
                            result = new WhippetResultContainer<StoreConfiguration>(WhippetResult.Success, new StoreConfiguration(configInterfaces.First()));
                        }
                        else
                        {
                            result = new WhippetResultContainer<StoreConfiguration>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<StoreConfiguration>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="StoreConfiguration"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreConfiguration"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> CreateAsync(StoreConfiguration item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Updates the specified <see cref="StoreConfiguration"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreConfiguration"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> UpdateAsync(StoreConfiguration item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Deletes the specified <see cref="StoreConfiguration"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreConfiguration"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> DeleteAsync(StoreConfiguration item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="StoreConfiguration"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<StoreConfiguration>> IWhippetRepository<StoreConfiguration, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="StoreConfiguration"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<StoreConfiguration> IWhippetRepository<StoreConfiguration, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }        
    }
}
