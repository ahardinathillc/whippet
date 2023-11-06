using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetSettingGroup"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetSettingGroupQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetSettingGroup> where TQuery : IWhippetQuery<WhippetSettingGroup>
    { }
}
