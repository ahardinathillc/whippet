using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all child <see cref="JobCategory"/> objects for a specific <see cref="JobCategory"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetJobCategoryChildrenQuery : WhippetQuery<JobCategory>, IWhippetQuery<JobCategory>
    {
        /// <summary>
        /// Gets or sets the parent <see cref="JobCategory"/> object to get children for.
        /// </summary>
        public JobCategory Parent
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobCategoryChildrenQuery"/> class with no arguments.
        /// </summary>
        public GetJobCategoryChildrenQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobCategoryChildrenQuery"/> class with the specified parent <see cref="JobCategory"/>.
        /// </summary>
        /// <param name="parent"></param>
        public GetJobCategoryChildrenQuery(JobCategory parent)
            : this()
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Parent), Parent) });
        }
    }
}
