using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <typeparamref name="TJob"/> by its ID.
    /// </summary>
    public class GetJobByIdQuery<TJob> : WhippetQuery<TJob>, IWhippetQuery<TJob>
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Gets the ID of the <typeparamref name="TJob"/> to retrieve. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobByIdQuery{TJob}"/> class with no arguments.
        /// </summary>
        private GetJobByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobByIdQuery{TJob}"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <typeparamref name="TJob"/> to retrieve.</param>
        public GetJobByIdQuery(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
