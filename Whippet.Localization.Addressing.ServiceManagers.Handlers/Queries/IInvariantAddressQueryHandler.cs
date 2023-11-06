using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Provides support for <see cref="IWhippetQuery{TEntity}"/> handlers.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public interface IInvariantAddressQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, InvariantAddress>
        where TQuery : IWhippetQuery<InvariantAddress>
    { }
}

