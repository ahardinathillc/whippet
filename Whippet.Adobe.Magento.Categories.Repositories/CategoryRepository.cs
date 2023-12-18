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
                            
                            categories.Add(category);
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
        /// Retrieves the <see cref="Category"/> object with the specified <see cref="Category"/> name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Category"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<Category> Get(string name)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name);
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
                WhippetResultContainer<Category> parentResult = null;
                
                RestRequest request = null;
                RestResponse response = null;

                List<Category> categories = null;

                MagentoInterfaceJsonSearchResultItemContainer<CategoryInterface> searchContainer = null;
                
                Category category = null;

                MagentoSearchCriteria nameCriteria = null;

                try
                {
                    nameCriteria = new MagentoSearchCriteria();
                    nameCriteria.AddCriterion(MagentoSearchCriteriaConditionType.Field.Create("name"), MagentoSearchCriteriaConditionType.SearchValue.Create(name), MagentoSearchCriteriaConditionType.EqualsCondition.Create());
                    
                    request = CreateRequest(CreateEndpointUrl() + nameCriteria.ToString(), Method.Get);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        categories = new List<Category>();
                        searchContainer = new MagentoInterfaceJsonSearchResultItemContainer<CategoryInterface>(response.Content);

                        if (searchContainer.Count > 0)
                        {
                            category = new Category(searchContainer.First());

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
                        
                        result = new WhippetResultContainer<Category>(WhippetResult.Success, category);
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
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResultContainer<Category> result = null;
                
                RestRequest request = null;
                RestResponse response = null;

                CategoryInterface categoryInterface = null;
                
                try
                {
                    request = CreateRequest(BASE_URL_SINGLE, Method.Post);
                    request.AddJsonBody(item.ToInterface(), ContentType.Json);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        categoryInterface = JsonConvert.DeserializeObject<CategoryInterface>(response.Content);

                        if (categoryInterface != null)
                        {
                            result = new WhippetResultContainer<Category>(WhippetResult.Success, new Category(categoryInterface));
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
        /// Updates the specified <see cref="Category"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Category"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> UpdateAsync(Category item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResultContainer<Category> result = null;
                
                RestRequest request = null;
                RestResponse response = null;

                CategoryInterface categoryInterface = null;
                
                try
                {
                    request = CreateRequest(CreateEndpointUrl(new[] { BASE_URL_SINGLE, Convert.ToString(item.ID) }), Method.Put);
                    request.AddJsonBody(item.ToInterface(), ContentType.Json);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        categoryInterface = JsonConvert.DeserializeObject<CategoryInterface>(response.Content);

                        if (categoryInterface != null)
                        {
                            result = new WhippetResultContainer<Category>(WhippetResult.Success, new Category(categoryInterface));
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
        /// Deletes the specified <see cref="Category"/> object in Magento.
        /// </summary>
        /// <param name="item"><see cref="Category"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="MagentoOperationApplicationException"></exception>
        public override async Task<WhippetResult> DeleteAsync(Category item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = null;
                
                RestRequest request = null;
                RestResponse response = null;

                try
                {
                    request = CreateRequest(CreateEndpointUrl(new[] { BASE_URL_SINGLE, Convert.ToString(item.ID) }), Method.Delete);
                    
                    response = await Client.ExecuteAsync(request);
                    response.ThrowIfError();

                    if (response.IsOkStatus())
                    {
                        if (!Convert.ToBoolean(response.Content))
                        {
                            throw new MagentoOperationApplicationException();
                        }
                        else
                        {
                            result = WhippetResult.Success;
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;                
            }            
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
