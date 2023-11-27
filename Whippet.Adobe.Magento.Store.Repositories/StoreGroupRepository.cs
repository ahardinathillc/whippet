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
using Athi.Whippet.Adobe.Magento.Categories;

namespace Athi.Whippet.Adobe.Magento.Store.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="StoreGroup"/> objects.
    /// </summary>
    public class StoreGroupRepository : MagentoEntityRestRepository<StoreGroup>, IStoreGroupRepository
    {
        private const string BASE_URL = "store/storeGroups";
        
        /// <summary>
        /// Loads a <see cref="Category"/> object based on a specified <see cref="Category"/> ID.
        /// </summary>
        protected readonly Func<uint, Task<WhippetResultContainer<Category>>> _LoadCategoryAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <param name="categoryLoaderDelegate"><see cref="Func{TParam, TResult}"/> that loads a <see cref="Category"/> object based on a given <see cref="Category"/> ID.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreGroupRepository(IWhippetRestClient restClient, string bearerToken, Func<uint, Task<WhippetResultContainer<Category>>> categoryLoaderDelegate)
            : base(restClient, bearerToken, BASE_URL)
        {
            ArgumentNullException.ThrowIfNull(categoryLoaderDelegate);

            _LoadCategoryAsync = categoryLoaderDelegate;
        }

        /// <summary>
        /// Gets the <see cref="StoreGroup"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<StoreGroup>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<StoreGroup> result = null;
            WhippetResultContainer<Category> categoryResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreGroupInterface> groupInterfaces = null;

            StoreGroup storeGroup = null;
            
            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    groupInterfaces = JsonConvert.DeserializeObject<List<StoreGroupInterface>>(response.Content);

                    if (groupInterfaces != null && groupInterfaces.Count > 0)
                    {
                        foreach (StoreGroupInterface groupInterface in groupInterfaces)
                        {
                            if (groupInterface.ID == Convert.ToInt32(key))
                            {
                                storeGroup = new StoreGroup(groupInterface);

                                if ((storeGroup.RootCategory != null) && (storeGroup.RootCategory.ID > 0))
                                {
                                    categoryResult = await _LoadCategoryAsync(Convert.ToUInt32(storeGroup.RootCategory.ID));
                                    categoryResult.ThrowIfFailed();

                                    if (categoryResult.HasItem)
                                    {
                                        storeGroup.RootCategory = categoryResult.Item;
                                    }
                                }
                                
                                result = new WhippetResultContainer<StoreGroup>(WhippetResult.Success, storeGroup);
                                break;
                            }
                        }

                        if (result == null)
                        {
                            result = new WhippetResultContainer<StoreGroup>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        result = new WhippetResultContainer<StoreGroup>(WhippetResult.Success, null);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<StoreGroup>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="StoreGroup"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<StoreGroup>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<StoreGroup>> result = null;
            WhippetResultContainer<Category> categoryResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreGroupInterface> groupInterfaces = null;
            List<StoreGroup> groups = null;
            
            StoreGroup storeGroup = null;
            
            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    groupInterfaces = JsonConvert.DeserializeObject<List<StoreGroupInterface>>(response.Content);

                    if (groupInterfaces != null && groupInterfaces.Count > 0)
                    {
                        groups = new List<StoreGroup>();
                        
                        foreach (StoreGroupInterface groupInterface in groupInterfaces)
                        {
                            storeGroup = new StoreGroup(groupInterface);

                            if ((storeGroup.RootCategory != null) && (storeGroup.RootCategory.ID > 0))
                            {
                                categoryResult = await _LoadCategoryAsync(Convert.ToUInt32(storeGroup.RootCategory.ID));
                                categoryResult.ThrowIfFailed();

                                if (categoryResult.HasItem)
                                {
                                    storeGroup.RootCategory = categoryResult.Item;
                                }
                            }
                            
                            groups.Add(storeGroup);
                        }

                        result = new WhippetResultContainer<IEnumerable<StoreGroup>>(WhippetResult.Success, groups);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<StoreGroup>>(WhippetResult.Success, null);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<StoreGroup>>(e);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the <see cref="StoreGroup"/> object with the specified <see cref="StoreGroup"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="StoreGroup"/> to retrieve the group information for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<StoreGroup> Get(string code)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            return Task.Run(() => GetAsync(code)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="StoreGroup"/> object with the specified <see cref="StoreGroup"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="StoreGroup"/> to retrieve the group information for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<StoreGroup>> GetAsync(string code, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                WhippetResultContainer<StoreGroup> result = null;
                WhippetResultContainer<Category> categoryResult = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<StoreGroupInterface> groupInterfaces = null;

                StoreGroup storeGroup = null;
                
                try
                {
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        groupInterfaces = JsonConvert.DeserializeObject<List<StoreGroupInterface>>(response.Content);

                        if (groupInterfaces != null && groupInterfaces.Count > 0)
                        {
                            foreach (StoreGroupInterface groupInterface in groupInterfaces)
                            {
                                if (String.Equals(groupInterface.Code?.Trim(), code.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    storeGroup = new StoreGroup(groupInterface);

                                    if ((storeGroup.RootCategory != null) && (storeGroup.RootCategory.ID > 0))
                                    {
                                        categoryResult = await _LoadCategoryAsync(Convert.ToUInt32(storeGroup.RootCategory.ID));
                                        categoryResult.ThrowIfFailed();

                                        if (categoryResult.HasItem)
                                        {
                                            storeGroup.RootCategory = categoryResult.Item;
                                        }
                                    }
                                    
                                    result = new WhippetResultContainer<StoreGroup>(WhippetResult.Success, storeGroup);
                                    break;
                                }
                            }

                            if (result == null)
                            {
                                result = new WhippetResultContainer<StoreGroup>(WhippetResult.Success, null);
                            }
                        }
                        else
                        {
                            result = new WhippetResultContainer<StoreGroup>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<StoreGroup>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Creates a new <see cref="StoreGroup"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreGroup"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> CreateAsync(StoreGroup item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Updates the specified <see cref="StoreGroup"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreGroup"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> UpdateAsync(StoreGroup item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Deletes the specified <see cref="StoreGroup"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreGroup"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> DeleteAsync(StoreGroup item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="StoreGroup"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<StoreGroup>> IWhippetRepository<StoreGroup, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="StoreGroup"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<StoreGroup> IWhippetRepository<StoreGroup, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }        
    }
}
