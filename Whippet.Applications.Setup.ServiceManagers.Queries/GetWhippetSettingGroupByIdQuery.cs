using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="WhippetSettingGroup"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetSettingGroupByIdQuery : WhippetQuery<WhippetSettingGroup>, IWhippetQuery<WhippetSettingGroup>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingGroupByIdQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetSettingGroupByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingGroupByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetSettingGroup"/> object to retrieve.</param>
        public GetWhippetSettingGroupByIdQuery(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
