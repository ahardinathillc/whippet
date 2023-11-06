using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="WhippetApplication"/> object by its <see cref="WhippetApplication.ApplicationID"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetApplicationByApplicationIdQuery : WhippetQuery<WhippetApplication>, IWhippetQuery<WhippetApplication>
    {
        /// <summary>
        /// Gets or sets the <see cref="WhippetApplication.ApplicationID"/> to query by.
        /// </summary>
        public Guid ApplicationID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> object to filter by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationByApplicationIdQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetApplicationByApplicationIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationByApplicationIdQuery"/> class with the specified <see cref="WhippetApplication.ApplicationID"/>.
        /// </summary>
        /// <param name="id"><see cref="WhippetApplication.ApplicationID"/> value to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        public GetWhippetApplicationByApplicationIdQuery(Guid id, IWhippetTenant tenant)
            : this()
        {
            ApplicationID = id;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(ApplicationID), ApplicationID),
                new KeyValuePair<string, object>(nameof(Tenant), Tenant)
            });
        }
    }
}
