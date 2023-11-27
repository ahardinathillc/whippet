using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="StoreWebsite"/> objects.
    /// </summary>
    public class StoreWebsiteRepository : MagentoEntityRestRepository<StoreWebsite>, IStoreWebsiteRepository
    {
        private const string BASE_URL = "store/websites";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreWebsiteRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken, BASE_URL)
        { }

        /// <summary>
        /// Gets the <see cref="StoreWebsite"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<StoreWebsite>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<StoreWebsite> result = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreWebsiteInterface> websiteInterfaces = null;

            StoreWebsite storeWebsite = null;
            
            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    websiteInterfaces = JsonConvert.DeserializeObject<List<StoreWebsiteInterface>>(response.Content);

                    if (websiteInterfaces != null && websiteInterfaces.Count > 0)
                    {
                        foreach (StoreWebsiteInterface websiteInterface in websiteInterfaces)
                        {
                            if (websiteInterface.ID == Convert.ToInt32(key))
                            {
                                storeWebsite = new StoreWebsite(websiteInterface);
                                result = new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, storeWebsite);
                                break;
                            }
                        }

                        if (result == null)
                        {
                            result = new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        result = new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, null);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<StoreWebsite>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="StoreWebsite"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<StoreWebsite>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<StoreWebsite>> result = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<StoreWebsiteInterface> websiteInterfaces = null;
            List<StoreWebsite> websites = null;
            
            StoreWebsite storeWebsite = null;
            
            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    websiteInterfaces = JsonConvert.DeserializeObject<List<StoreWebsiteInterface>>(response.Content);

                    if (websiteInterfaces != null && websiteInterfaces.Count > 0)
                    {
                        websites = new List<StoreWebsite>();
                        
                        foreach (StoreWebsiteInterface websiteInterface in websiteInterfaces)
                        {
                            storeWebsite = new StoreWebsite(websiteInterface);
                            websites.Add(storeWebsite);
                        }

                        result = new WhippetResultContainer<IEnumerable<StoreWebsite>>(WhippetResult.Success, websites);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<StoreWebsite>>(WhippetResult.Success, null);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<StoreWebsite>>(e);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the <see cref="StoreWebsite"/> object with the specified <see cref="StoreWebsite"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="StoreWebsite"/> to retrieve the website information for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<StoreWebsite> Get(string code)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            return Task.Run(() => GetAsync(code)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="StoreWebsite"/> object with the specified <see cref="StoreWebsite"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="StoreWebsite"/> to retrieve the website information for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<StoreWebsite>> GetAsync(string code, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                WhippetResultContainer<StoreWebsite> result = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<StoreWebsiteInterface> websiteInterfaces = null;

                StoreWebsite storeWebsite = null;
                
                try
                {
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        websiteInterfaces = JsonConvert.DeserializeObject<List<StoreWebsiteInterface>>(response.Content);

                        if (websiteInterfaces != null && websiteInterfaces.Count > 0)
                        {
                            foreach (StoreWebsiteInterface websiteInterface in websiteInterfaces)
                            {
                                if (String.Equals(websiteInterface.Code?.Trim(), code.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    storeWebsite = new StoreWebsite(websiteInterface);
                                    result = new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, storeWebsite);
                                    break;
                                }
                            }

                            if (result == null)
                            {
                                result = new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, null);
                            }
                        }
                        else
                        {
                            result = new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<StoreWebsite>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Creates a new <see cref="StoreWebsite"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreWebsite"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> CreateAsync(StoreWebsite item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Updates the specified <see cref="StoreWebsite"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreWebsite"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> UpdateAsync(StoreWebsite item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Deletes the specified <see cref="StoreWebsite"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="StoreWebsite"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> DeleteAsync(StoreWebsite item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="StoreWebsite"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<StoreWebsite>> IWhippetRepository<StoreWebsite, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="StoreWebsite"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<StoreWebsite> IWhippetRepository<StoreWebsite, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }        
    }
}
