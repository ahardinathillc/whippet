using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Commands;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Jobs.Repositories;
using Athi.Whippet.Jobs.Extensions;

namespace Athi.Whippet.Jobs.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IJobCategory"/> domain objects.
    /// </summary>
    public class JobCategoryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IJobCategoryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IJobCategoryRepository CategoryRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryServiceManager"/> class with the specified <see cref="IJobCategoryRepository"/> object.
        /// </summary>
        /// <param name="categoryRepository"><see cref="IJobCategoryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobCategoryServiceManager(IJobCategoryRepository categoryRepository)
            : base()
        {
            if (categoryRepository == null)
            {
                throw new ArgumentNullException(nameof(categoryRepository));
            }
            else
            {
                CategoryRepository = categoryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryServiceManager"/> class with the specified <see cref="IJobCategoryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="categoryRepository"><see cref="IJobCategoryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobCategoryServiceManager(IWhippetServiceContext serviceLocator, IJobCategoryRepository categoryRepository)
            : base(serviceLocator)
        {
            if (categoryRepository == null)
            {
                throw new ArgumentNullException(nameof(categoryRepository));
            }
            else
            {
                CategoryRepository = categoryRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IJobCategory"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobCategory"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IJobCategory>> GetCategory(Guid id)
        {
            IJobCategoryQueryHandler<GetJobCategoryByIdQuery> handler = new GetJobCategoryByIdQueryHandler(CategoryRepository);
            WhippetResultContainer<IEnumerable<JobCategory>> result = await handler.HandleAsync(new GetJobCategoryByIdQuery(id));
            return new WhippetResultContainer<IJobCategory>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IJobCategory"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IJobCategory>>> GetCategories()
        {
            IJobCategoryQueryHandler<GetAllJobCategoriesQuery> handler = new GetAllJobCategoriesQueryHandler(CategoryRepository);
            WhippetResultContainer<IEnumerable<JobCategory>> result = await handler.HandleAsync(new GetAllJobCategoriesQuery());
            return new WhippetResultContainer<IEnumerable<IJobCategory>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJobCategory"/> that are children of the specified parent <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="parent">Parent <see cref="IJobCategory"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IJobCategory>>> GetCategories(IJobCategory parent)
        {
            IJobCategoryQueryHandler<GetJobCategoryChildrenQuery> handler = new GetJobCategoryChildrenQueryHandler(CategoryRepository);
            WhippetResultContainer<IEnumerable<JobCategory>> result = await handler.HandleAsync(new GetJobCategoryChildrenQuery(parent.ToJobCategory()));
            return new WhippetResultContainer<IEnumerable<IJobCategory>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Whippet category.
        /// </summary>
        /// <param name="category">Category to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created category.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IJobCategory> CreateJobCategory(IJobCategory category)
        {
            return Task<WhippetResultContainer<IJobCategory>>.Run(() => CreateJobCategoryAsync(category)).Result;
        }

        /// <summary>
        /// Creates a new Whippet category.
        /// </summary>
        /// <param name="category">Category to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created category.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IJobCategory>> CreateJobCategoryAsync(IJobCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateJobCategoryCommand> handler = new CreateJobCategoryCommandHandler(CategoryRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateJobCategoryCommand(category.ToJobCategory()));

                    if (createResult.IsSuccess)
                    {
                        await CategoryRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IJobCategory>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IJobCategory>(createResult, category);
            }
        }

        /// <summary>
        /// Updates an existing Whippet category.
        /// </summary>
        /// <param name="category">Category to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated category.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IJobCategory> UpdateJobCategory(IJobCategory category)
        {
            return Task<WhippetResultContainer<IJobCategory>>.Run(() => UpdateJobCategoryAsync(category)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet category.
        /// </summary>
        /// <param name="category">Category to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated category.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IJobCategory>> UpdateJobCategoryAsync(IJobCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateJobCategoryCommand> handler = new UpdateJobCategoryCommandHandler(CategoryRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateJobCategoryCommand(category.ToJobCategory()));

                    if (updateResult.IsSuccess)
                    {
                        await CategoryRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IJobCategory>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IJobCategory>(updateResult, category);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet category.
        /// </summary>
        /// <param name="category">Category to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted category.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IJobCategory> DeleteJobCategory(IJobCategory category)
        {
            return Task<WhippetResultContainer<IJobCategory>>.Run(() => DeleteJobCategoryAsync(category)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet category.
        /// </summary>
        /// <param name="category">Category to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted category.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IJobCategory>> DeleteJobCategoryAsync(IJobCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteJobCategoryCommand> handler = new DeleteJobCategoryCommandHandler(CategoryRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteJobCategoryCommand(category.ToJobCategory()));

                    if (updateResult.IsSuccess)
                    {
                        await CategoryRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IJobCategory>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IJobCategory>(updateResult, category);
            }
        }
        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CategoryRepository != null)
            {
                CategoryRepository.Dispose();
                CategoryRepository = null;
            }

            base.Dispose();
        }
    }
}
