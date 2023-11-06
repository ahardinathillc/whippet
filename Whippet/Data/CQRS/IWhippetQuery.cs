using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a query that is executed against a query handler to return one or more entity objects that match a predefined criterion.
    /// </summary>
    public interface IWhippetQuery
    { }

    /// <summary>
    /// Represents a query that is executed against a query handler to return one or more entity objects that match a predefined criterion.
    /// </summary>
    public interface IWhippetQuery<TEntity> : IWhippetQuery where TEntity : IWhippetEntity
    { }
}
