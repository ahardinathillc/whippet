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
    /// Represents a query that retrieves <see cref="MultichannelOrderManagerOrder"/> objects within a specified date range. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerQuotesByDateRangeQuery : GetMultichannelOrderManagerOrdersByDateRangeQuery, IWhippetQuery<MultichannelOrderManagerOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerQuotesByDateRangeQuery"/> class with the specified date range.
        /// </summary>
        /// <param name="startDate">Start date range inclusive for filtering the <see cref="MultichannelOrderManagerOrder"/> objects.</param>
        /// <param name="endDate">End date range inclusive for filtering the <see cref="MultichannelOrderManagerOrder"/> objects.</param>
        public GetMultichannelOrderManagerQuotesByDateRangeQuery(Instant startDate, Instant endDate)
            : base(startDate, endDate)
        { }
    }
}
