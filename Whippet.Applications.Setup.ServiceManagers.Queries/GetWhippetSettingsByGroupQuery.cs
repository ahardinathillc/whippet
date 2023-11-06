using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="WhippetSetting"/> objects for a particular <see cref="IWhippetSettingGroup"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetSettingsByGroupQuery : WhippetQuery<WhippetSetting>, IWhippetQuery<WhippetSetting>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetSettingGroup"/> to query by.
        /// </summary>
        public IWhippetSettingGroup Group
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingsByGroupQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetSettingsByGroupQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingsByGroupQuery"/> class with the specified <see cref="IWhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> to filter by.</param>
        public GetWhippetSettingsByGroupQuery(IWhippetSettingGroup group)
            : this()
        {
            Group = group;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Group), Group) });
        }
    }
}
