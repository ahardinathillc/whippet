using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MultichannelOrderManagerOrder"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMultichannelOrderManagerOrderQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MultichannelOrderManagerOrder> where TQuery : IWhippetQuery<MultichannelOrderManagerOrder>
    {
    }
}
