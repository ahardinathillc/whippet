using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves <see cref="MultichannelOrderManagerOrder"/> objects within a specified order ID range.
    /// </summary>
    public class GetMultichannelOrderManagerOrdersQuery : WhippetQuery<MultichannelOrderManagerOrder>, IWhippetQuery<MultichannelOrderManagerOrder>
    {
        /// <summary>
        /// Lower bound inclusive <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.
        /// </summary>
        public long StartOrderNumber
        { get; set; }

        /// <summary>
        /// Upper bound inclusive <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.
        /// </summary>
        public long EndOrderNumber
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerOrdersQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerOrdersQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerOrdersQuery"/> class with the specified order number range.
        /// </summary>
        /// <param name="startOrderNumber">Lower bound inclusive <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.</param>
        /// <param name="endOrderNumber">Upper bound bound inclusive <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.</param>
        public GetMultichannelOrderManagerOrdersQuery(long startOrderNumber, long endOrderNumber)
            : this()
        {
            StartOrderNumber = startOrderNumber;
            EndOrderNumber = endOrderNumber;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(StartOrderNumber), StartOrderNumber),
                new KeyValuePair<string, object>(nameof(EndOrderNumber), EndOrderNumber)
            });
        }
    }
}
