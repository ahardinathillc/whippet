using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides support to repositories that are used in CQRS query handlers.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> type that the repository manages.</typeparam>
    public interface IWhippetQueryRepository<TEntity> : IWhippetRepository<TEntity, Guid>
        where TEntity: class, IWhippetEntity
    { }
}
