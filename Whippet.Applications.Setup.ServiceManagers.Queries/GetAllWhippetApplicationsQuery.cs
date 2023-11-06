using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="WhippetApplication"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllWhippetApplicationsQuery : WhippetQuery<WhippetApplication>, IWhippetQuery<WhippetApplication>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWhippetApplicationsQuery"/> class with no arguments.
        /// </summary>
        public GetAllWhippetApplicationsQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return NoParameters;
        }
    }
}
