using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="WhippetSettingGroup"/> objects for a specific <see cref="IWhippetApplication"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetSettingGroupsByApplicationQuery : WhippetQuery<WhippetSettingGroup>, IWhippetQuery<WhippetSettingGroup>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetApplication"/> to filter by.
        /// </summary>
        public IWhippetApplication Application
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingGroupsByApplicationQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetSettingGroupsByApplicationQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingGroupsByApplicationQuery"/> class with the specified <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> to filter by.</param>
        public GetWhippetSettingGroupsByApplicationQuery(IWhippetApplication application)
            : this()
        {
            Application = application;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Application), Application)
            });
        }
    }
}
