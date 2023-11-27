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
using Athi.Whippet.Adobe.Magento.Json;

namespace Athi.Whippet.Adobe.Magento.Categories.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="Category"/> objects.
    /// </summary>
    public class CategoryRepository: MagentoEntityRestRepository<Category>, ICategoryRepository
    {
        private const string BASE_URL_SINGLE = "categories/";
        private const string BASE_URL = BASE_URL_SINGLE + "list";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public CategoryRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken, BASE_URL)
        { }

        /// <summary>
        /// Gets the <see cref="Category"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<Category>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<Category> result = null;
            WhippetResultContainer<Category> parentResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            CategoryInterface categoryInterface = null;
            
            Category category = null;
            
            try
            {
                request = CreateRequest(CreateEndpointUrl(new [] { BASE_URL_SINGLE, Convert.ToString(key) }), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    categoryInterface = JsonConvert.DeserializeObject<CategoryInterface>(response.Content);

                    if (categoryInterface != null)
                    {
                        category = new Category(categoryInterface);

                        if ((category.Parent != null) && (category.Parent.ID != category.ID) && (category.Parent.ID > 0))
                        {
                            parentResult = await GetAsync(Convert.ToUInt32(category.Parent.ID));
                            parentResult.ThrowIfFailed();

                            if (parentResult.HasItem)
                            {
                                category.Parent = parentResult.Item;
                            }
                        }

                        result = new WhippetResultContainer<Category>(WhippetResult.Success, category);
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Category>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="Category"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<Category>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<Category>> result = null;
            WhippetResultContainer<Category> parentResult = null;
            
            RestRequest request = null;
            RestResponse response = null;

            List<Category> categories = null;

            MagentoInterfaceJsonSearchResultItemContainer<CategoryInterface> searchContainer = null;
            
            Category category = null;
            
            try
            {
                request = CreateRequest(CreateEndpointUrl(), Method.Get);
                
                response = await Client.ExecuteAsync(request);
                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    categories = new List<Category>();
                    searchContainer = new MagentoInterfaceJsonSearchResultItemContainer<CategoryInterface>(response.Content);

                    if (searchContainer.Count > 0)
                    {
                        foreach (CategoryInterface categoryInterface in searchContainer)
                        {
                            category = new Category(categoryInterface);

                            if ((category.Parent != null) && (category.Parent.ID != category.ID) && (category.Parent.ID > 0))
                            {
                                parentResult = await GetAsync(Convert.ToUInt32(category.Parent.ID));
                                parentResult.ThrowIfFailed();

                                if (parentResult.HasItem)
                                {
                                    category.Parent = parentResult.Item;
                                }
                            }
                        }
                    }
                    
                    result = new WhippetResultContainer<IEnumerable<Category>>(WhippetResult.Success, categories);
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<Category>>(e);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the <see cref="Category"/> object with the specified <see cref="Category"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Category"/> to retrieve the configuration for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<Category> GetByCode(string code)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            return Task.Run(() => GetByCodeAsync(code)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="Category"/> object with the specified <see cref="Category"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Category"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<Category>> GetByCodeAsync(string code, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                WhippetResultContainer<Category> result = null;
                WhippetResultContainer<IEnumerable<CategoryGroup>> groupResult = null;
                WhippetResultContainer<IEnumerable<CategoryWebsite>> websiteResult = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<CategoryInterface> categoryInterfaces = null;

                Category category = null;
                
                try
                {
                    groupResult = await _LoadAllCategoryGroupsAsync();
                    groupResult.ThrowIfFailed();

                    websiteResult = await _LoadAllCategoryWebsitesAsync();
                    websiteResult.ThrowIfFailed();
                    
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        categoryInterfaces = JsonConvert.DeserializeObject<List<CategoryInterface>>(response.Content);

                        if (categoryInterfaces != null && categoryInterfaces.Count > 0)
                        {
                            foreach (CategoryInterface categoryInterface in categoryInterfaces)
                            {
                                if (String.Equals(categoryInterface.Code?.Trim(), code.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    category = new Category(categoryInterface);

                                    if (groupResult.HasItem && groupResult.Item.Any())
                                    {
                                        category.Group = (from g in groupResult.Item where g.ID == category.Group.ID select g).FirstOrDefault();
                                    }

                                    if (websiteResult.HasItem && websiteResult.Item.Any())
                                    {
                                        category.Website = (from w in websiteResult.Item where w.ID == category.Website.ID select w).FirstOrDefault();
                                    }
                                    
                                    result = new WhippetResultContainer<Category>(WhippetResult.Success, new Category(categoryInterface));
                                }
                            }

                            if (result == null)
                            {
                                result = new WhippetResultContainer<Category>(WhippetResult.Success, null);
                            }
                        }
                        else
                        {
                            result = new WhippetResultContainer<Category>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<Category>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="Category"/> object with the specified <see cref="Category"/> name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Category"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<Category> Get(string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            return Task.Run(() => GetAsync(name)).Result;
        }

        /// <summary>
        /// Retrieves the <see cref="Category"/> object with the specified <see cref="Category"/> name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Category"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<Category>> GetAsync(string name, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                WhippetResultContainer<Category> result = null;
                WhippetResultContainer<IEnumerable<CategoryGroup>> groupResult = null;
                WhippetResultContainer<IEnumerable<CategoryWebsite>> websiteResult = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<CategoryInterface> categoryInterfaces = null;

                Category category = null;
                
                try
                {
                    groupResult = await _LoadAllCategoryGroupsAsync();
                    groupResult.ThrowIfFailed();

                    websiteResult = await _LoadAllCategoryWebsitesAsync();
                    websiteResult.ThrowIfFailed();
                    
                    request = CreateRequest(CreateEndpointUrl(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        categoryInterfaces = JsonConvert.DeserializeObject<List<CategoryInterface>>(response.Content);

                        if (categoryInterfaces != null && categoryInterfaces.Count > 0)
                        {
                            foreach (CategoryInterface categoryInterface in categoryInterfaces)
                            {
                                if (String.Equals(categoryInterface.Name?.Trim(), name.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    category = new Category(categoryInterface);

                                    if (groupResult.HasItem && groupResult.Item.Any())
                                    {
                                        category.Group = (from g in groupResult.Item where g.ID == category.Group.ID select g).FirstOrDefault();
                                    }

                                    if (websiteResult.HasItem && websiteResult.Item.Any())
                                    {
                                        category.Website = (from w in websiteResult.Item where w.ID == category.Website.ID select w).FirstOrDefault();
                                    }
                                    
                                    result = new WhippetResultContainer<Category>(WhippetResult.Success, new Category(categoryInterface));
                                }
                            }

                            if (result == null)
                            {
                                result = new WhippetResultContainer<Category>(WhippetResult.Success, null);
                            }
                        }
                        else
                        {
                            result = new WhippetResultContainer<Category>(WhippetResult.Success, null);
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<Category>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Creates a new <see cref="Category"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Category"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> CreateAsync(Category item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Updates the specified <see cref="Category"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Category"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> UpdateAsync(Category item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// Deletes the specified <see cref="Category"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Category"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> DeleteAsync(Category item, CancellationToken? cancellationToken = null)
        {
            throw new MagentoOperationApplicationException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Category"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<Category>> IWhippetRepository<Category, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Category"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<Category> IWhippetRepository<Category, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }        
        
    }
}
