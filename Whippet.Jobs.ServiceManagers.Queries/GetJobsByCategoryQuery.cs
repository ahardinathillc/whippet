using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <typeparamref name="TJob"/> objects by their associated <see cref="IJobCategory"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetJobsByCategoryQuery<TJob> : WhippetQuery<TJob>, IWhippetQuery<TJob>
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Gets or sets the <see cref="IJobCategory"/> to filter by.
        /// </summary>
        public IJobCategory Category
        { get; set; }

        /// <summary>
        /// Gets or sets the optional <see cref="IWhippetTenant"/> to further filter by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobsByCategoryQuery{TJob}"/> class with no arguments.
        /// </summary>
        private GetJobsByCategoryQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobsByCategoryQuery{TJob}"/> with the specified <see cref="IJobCategory"/> object.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to initialize with.</param>
        public GetJobsByCategoryQuery(IJobCategory category)
            : this(category, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobsByCategoryQuery{TJob}"/> with the specified <see cref="IJobCategory"/> object and <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to initialize with.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by with further.</param>
        public GetJobsByCategoryQuery(IJobCategory category, IWhippetTenant tenant)
            : this()
        {
            Category = category;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Category), Category),
                new KeyValuePair<string, object>(nameof(Tenant), Tenant)
            });
        }
    }
}
