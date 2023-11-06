using System;
using System.Reflection;
using System.Collections.ObjectModel;
using NHibernate;
using Dynamitey;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Reflection;
using Athi.Whippet.Reflection.Extensions;
using System.Collections.Generic;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Wrapper class for data repositories that map <see cref="JobBase"/> entity objects.
    /// </summary>
    public sealed class JobRepository : JobRepositoryBase<Job>, IJobRepository
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IJobRepository{TJob}"/> object.
        /// </summary>
        private dynamic InternalRepository
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="repositoryType">Type of repository to instantiate internally.</param>
        /// <exception cref="ArgumentNullException" />
        public JobRepository(ISession context, Type repositoryType)
            : base(context)
        {
            if (repositoryType == null)
            {
                throw new ArgumentNullException(nameof(repositoryType));
            }
            else if (repositoryType.IsInterface || repositoryType.IsAbstract || repositoryType.IsNotPublic)
            {
                throw new ConcreteClassTypeRequiredException(null, nameof(repositoryType));
            }
            else
            {
                InternalRepository = Dynamic.InvokeConstructor(repositoryType, Context); 
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="repositoryType">Assembly qualified type name (including path) of the <see cref="IJobRepository{TJob}"/> to instantiate internally.</param>
        /// <exception cref="ArgumentNullException" />
        public JobRepository(ISession context, string repositoryType)
            : this(context, Type.GetType(repositoryType, true))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public JobRepository(ISession context, IStatelessSession statelessContext, Type repositoryType)
            : base(context, statelessContext)
        {
            if (repositoryType == null)
            {
                throw new ArgumentNullException(nameof(repositoryType));
            }
            else if (repositoryType.IsInterface || repositoryType.IsAbstract || repositoryType.IsNotPublic)
            {
                if (!repositoryType.IsSubclassOf(typeof(JobRepositoryBase<>)))
                {
                    throw new ArgumentException();
                }
                else
                {
                    throw new ConcreteClassTypeRequiredException(null, nameof(repositoryType));
                }
            }
            else
            {
                InternalRepository = Dynamic.InvokeConstructor(repositoryType, Context, StatelessContext);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<IEnumerable<Job>> Get(IWhippetTenant tenant)
        {
            WhippetResultContainer<IEnumerable<Job>> result = null;
            WhippetResultContainer<IEnumerable<IJob>> dynamnicResult = (WhippetResultContainer<IEnumerable<IJob>>)(Dynamic.InvokeMember(InternalRepository, nameof(Get), tenant));

            if (!dynamnicResult.IsSuccess)
            {
                result = new WhippetResultContainer<IEnumerable<Job>>(dynamnicResult.Exception);
            }
            else
            {
                result = new WhippetResultContainer<IEnumerable<Job>>(dynamnicResult.Result, dynamnicResult.HasItem ? dynamnicResult.Item.Select(dr => new Job(dr)) : Enumerable.Empty<Job>());
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<Job>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<Job>> result = null;

            MethodInfo getAsyncMethod = InternalRepository.GetType().GetMethod(nameof(InternalRepository.GetAsync));
            MethodInfo genericGetAsyncMethod = getAsyncMethod.MakeGenericMethod(InternalRepository.GetType().GetGenericArguments()[0]);

            dynamic awaitable = genericGetAsyncMethod.Invoke(InternalRepository, new object[] { tenant, cancellationToken });
            dynamic awaitableResult;

            await awaitable;
            awaitableResult = awaitable.GetAwaiter().GetResult();

            if (awaitableResult.IsSuccess)
            {
                System.Diagnostics.Debug.WriteLine("Success!");
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="Job"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public WhippetResultContainer<IEnumerable<Job>> Get(IJobCategory category, IWhippetTenant tenant = null)
        {
            return null;
        }

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<Job>>> GetAsync(IJobCategory category, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            return null;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> of the internal repository the current wrapper encapsulates.
        /// </summary>
        /// <returns><see cref="Type"/> of the internal repository the current wrapper encapsulates.</returns>
        public new Type GetType()
        {
            return InternalRepository.GetType();
        }

        /// <summary>
        /// Retrieves the internal repository that the current <see cref="IJobRepository"/> is wrapping.
        /// </summary>
        /// <returns><see langword="dynamic"/> object that represents the repository being wrapped.</returns>
        public dynamic GetInternalRepository()
        {
            return InternalRepository;
        }
    }
}

