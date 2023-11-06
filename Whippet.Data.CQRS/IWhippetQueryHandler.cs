using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides support for handling <see cref="IWhippetQuery{T}"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> object that the handler accepts.</typeparam>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> object that the query returns.</typeparam>
    public interface IWhippetQueryHandler<TQuery, TEntity> 
        where TQuery : IWhippetQuery<TEntity>
        where TEntity : IWhippetEntity
    {
        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<TEntity>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<TEntity>> Handle(TQuery query);
    }
}
