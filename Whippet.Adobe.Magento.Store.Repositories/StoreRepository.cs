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
    /// Represents a data repository for <see cref="Store"/> objects.
    /// </summary>
    public class StoreRepository : MagentoEntityRestRepository<Store>, IStoreRepository
    {
        private const string BASE_URL = "store/storeViews";
        
        /// <summary>
        /// Loads all <see cref="StoreGroup"/> objects in the system.
        /// </summary>
        protected readonly Func<Task<WhippetResultContainer<IEnumerable<StoreGroup>>>> _LoadAllStoreGroupsAsync;

        /// <summary>
        /// Loads all <see cref="StoreWebsite"/> objects in the system.
        /// </summary>
        protected readonly Func<Task<WhippetResultContainer<IEnumerable<StoreWebsite>>>> _LoadAllStoreWebsitesAsync;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <param name="allStoreGroupsLoaderDelegate"><see cref="Func{TResult}"/> that loads all <see cref="StoreGroup"/> objects in the system.</param>
        /// <param name="allStoreWebsitesLoaderDelegate"><see cref="Func{TResult}"/> that loads all <see cref="StoreWebsite"/> objects in the system.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreRepository(IWhippetRestClient restClient, string bearerToken, Func<Task<WhippetResultContainer<IEnumerable<StoreGroup>>>> allStoreGroupsLoaderDelegate, Func<Task<WhippetResultContainer<IEnumerable<StoreWebsite>>>> allStoreWebsitesLoaderDelegate)
            : base(restClient, bearerToken, BASE_URL)
        {
            ArgumentNullException.ThrowIfNull(allStoreGroupsLoaderDelegate);
            ArgumentNullException.ThrowIfNull(allStoreWebsitesLoaderDelegate);
            
            _LoadAllStoreGroupsAsync = allStoreGroupsLoaderDelegate;
            _LoadAllStoreWebsitesAsync = allStoreWebsitesLoaderDelegate;
        }

        /// <summary>
        /// Gets the <see cref="Store"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<Store>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<Store> result = null;
            WhippetResultContainer<IEnumerable<StoreGroup>> groupResult = null;
            WhippetResultContainer<IEnumerable<StoreWebsite>> websiteResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreInterface> storeInterfaces = null;

            Store store = null;
            
            try
            {
                groupResult = await _LoadAllStoreGroupsAsync();
                groupResult.ThrowIfFailed();

                websiteResult = await _LoadAllStoreWebsitesAsync();
                websiteResult.ThrowIfFailed();
                
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    storeInterfaces = JsonConvert.DeserializeObject<List<StoreInterface>>(response.Content);

                    if (storeInterfaces != null && storeInterfaces.Count > 0)
                    {
                        foreach (StoreInterface storeInterface in storeInterfaces)
                        {
                            if (storeInterface.ID == Convert.ToInt32(key))
                            {
                                store = new Store(storeInterface);

                                if (groupResult.HasItem && groupResult.Item.Any())
                                {
                                    store.Group = (from g in groupResult.Item where g.ID == store.Group.ID select g).FirstOrDefault();
                                }

                                if (websiteResult.HasItem && websiteResult.Item.Any())
                                {
                                    store.Website = (from w in websiteResult.Item where w.ID == store.Website.ID select w).FirstOrDefault();
                                }
                                
                                result = new WhippetResultContainer<Store>(WhippetResult.Success, new Store(storeInterface));
                            }
                        }

                        if (result == null)
                        {
                            result = new WhippetResultContainer<Store>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        result = new WhippetResultContainer<Store>(WhippetResult.Success, null);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Store>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="Store"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<Store>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<Store>> result = null;
            WhippetResultContainer<IEnumerable<StoreGroup>> groupResult = null;
            WhippetResultContainer<IEnumerable<StoreWebsite>> websiteResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreInterface> storeInterfaces = null;
            List<Store> stores = null;
            
            Store store = null;
            
            try
            {
                groupResult = await _LoadAllStoreGroupsAsync();
                groupResult.ThrowIfFailed();

                websiteResult = await _LoadAllStoreWebsitesAsync();
                websiteResult.ThrowIfFailed();
                
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    stores = new List<Store>();
                    storeInterfaces = JsonConvert.DeserializeObject<List<StoreInterface>>(response.Content);

                    if (storeInterfaces != null && storeInterfaces.Count > 0)
                    {
                        foreach (StoreInterface storeInterface in storeInterfaces)
                        {
                            store = new Store(storeInterface);

                            if (groupResult.HasItem && groupResult.Item.Any())
                            {
                                store.Group = (from g in groupResult.Item where g.ID == store.Group.ID select g).FirstOrDefault();
                            }

                            if (websiteResult.HasItem && websiteResult.Item.Any())
                            {
                                store.Website = (from w in websiteResult.Item where w.ID == store.Website.ID select w).FirstOrDefault();
                            }

                            stores.Add(store);
                        }
                    }
                    
                    result = new WhippetResultContainer<IEnumerable<Store>>(WhippetResult.Success, stores);
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<Store>>(e);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified <see cref="Store"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve the configuration for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<Store> GetByCode(string code)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            return Task.Run(() => GetByCodeAsync(code)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified <see cref="Store"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<Store>> GetByCodeAsync(string code, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                WhippetResultContainer<Store> result = null;
                WhippetResultContainer<IEnumerable<StoreGroup>> groupResult = null;
                WhippetResultContainer<IEnumerable<StoreWebsite>> websiteResult = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<StoreInterface> storeInterfaces = null;

                Store store = null;
                
                try
                {
                    groupResult = await _LoadAllStoreGroupsAsync();
                    groupResult.ThrowIfFailed();

                    websiteResult = await _LoadAllStoreWebsitesAsync();
                    websiteResult.ThrowIfFailed();
                    
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        storeInterfaces = JsonConvert.DeserializeObject<List<StoreInterface>>(response.Content);

                        if (storeInterfaces != null && storeInterfaces.Count > 0)
                        {
                            foreach (StoreInterface storeInterface in storeInterfaces)
                            {
                                if (String.Equals(storeInterface.Code?.Trim(), code.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    store = new Store(storeInterface);

                                    if (groupResult.HasItem && groupResult.Item.Any())
                                    {
                                        store.Group = (from g in groupResult.Item where g.ID == store.Group.ID select g).FirstOrDefault();
                                    }

                                    if (websiteResult.HasItem && websiteResult.Item.Any())
                                    {
                                        store.Website = (from w in websiteResult.Item where w.ID == store.Website.ID select w).FirstOrDefault();
                                    }
                                    
                                    result = new WhippetResultContainer<Store>(WhippetResult.Success, new Store(storeInterface));
                                }
                            }

                            if (result == null)
                            {
                                result = new WhippetResultContainer<Store>(WhippetResult.Success, null);
                            }
                        }
                        else
                        {
                            result = new WhippetResultContainer<Store>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<Store>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified <see cref="Store"/> name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Store"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<Store> Get(string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            return Task.Run(() => GetAsync(name)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified <see cref="Store"/> name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Store"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<Store>> GetAsync(string name, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                WhippetResultContainer<Store> result = null;
                WhippetResultContainer<IEnumerable<StoreGroup>> groupResult = null;
                WhippetResultContainer<IEnumerable<StoreWebsite>> websiteResult = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<StoreInterface> storeInterfaces = null;

                Store store = null;
                
                try
                {
                    groupResult = await _LoadAllStoreGroupsAsync();
                    groupResult.ThrowIfFailed();

                    websiteResult = await _LoadAllStoreWebsitesAsync();
                    websiteResult.ThrowIfFailed();
                    
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        storeInterfaces = JsonConvert.DeserializeObject<List<StoreInterface>>(response.Content);

                        if (storeInterfaces != null && storeInterfaces.Count > 0)
                        {
                            foreach (StoreInterface storeInterface in storeInterfaces)
                            {
                                if (String.Equals(storeInterface.Name?.Trim(), name.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    store = new Store(storeInterface);

                                    if (groupResult.HasItem && groupResult.Item.Any())
                                    {
                                        store.Group = (from g in groupResult.Item where g.ID == store.Group.ID select g).FirstOrDefault();
                                    }

                                    if (websiteResult.HasItem && websiteResult.Item.Any())
                                    {
                                        store.Website = (from w in websiteResult.Item where w.ID == store.Website.ID select w).FirstOrDefault();
                                    }
                                    
                                    result = new WhippetResultContainer<Store>(WhippetResult.Success, new Store(storeInterface));
                                }
                            }

                            if (result == null)
                            {
                                result = new WhippetResultContainer<Store>(WhippetResult.Success, null);
                            }
                        }
                        else
                        {
                            result = new WhippetResultContainer<Store>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<Store>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Creates a new <see cref="Store"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Store"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> CreateAsync(Store item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Updates the specified <see cref="Store"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Store"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> UpdateAsync(Store item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Deletes the specified <see cref="Store"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Store"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> DeleteAsync(Store item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Store"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<Store>> IWhippetRepository<Store, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Store"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<Store> IWhippetRepository<Store, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }        
    }
}
