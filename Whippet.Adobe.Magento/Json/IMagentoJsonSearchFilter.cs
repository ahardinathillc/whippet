using System;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Represents a Magento API search filter.
    /// </summary>
    public interface IMagentoJsonSearchFilter : IEqualityComparer<IMagentoJsonSearchFilter>
    {
        /// <summary>
        /// Gets or sets the field name that is being queried.
        /// </summary>
        string Field
        { get; set; }

        /// <summary>
        /// Gets or sets the search value that is being queried in <see cref="Field"/>.
        /// </summary>
        string Value
        { get; set; }

        /// <summary>
        /// Gets or sets the condition type (if any).
        /// </summary>
        string ConditionType
        { get; }
    }
}

