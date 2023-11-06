using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <typeparamref name="TJobParameter"/> objects for a specific <see cref="IJob"/> of type <typeparamref name="TJob"/>.
    /// </summary>
    public class GetJobParametersByJobQuery<TJobParameter, TJob> : WhippetQuery<TJobParameter>, IWhippetQuery<TJobParameter>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Gets the <typeparamref name="TJob"/> to filter by. This property is read-only.
        /// </summary>
        public TJob Job
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobParametersByJobQuery{TJobParameter, TJob}"/> class with no arguments.
        /// </summary>
        private GetJobParametersByJobQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobParametersByJobQuery{TJobParameter, TJob}"/> class with the specified <typeparamref name="TJob"/> object.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to filter by.</param>
        public GetJobParametersByJobQuery(TJob job)
            : this()
        {
            Job = job;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Job), Job) });
        }
    }
}
