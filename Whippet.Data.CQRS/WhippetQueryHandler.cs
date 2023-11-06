using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery"/> handlers. Each derived class must implement <see cref="IWhippetQueryHandler{TQuery, TEntity}"/> to mark which queries it is capable of handling. This class must be inherited.
    /// </summary>
    public abstract class WhippetQueryHandler<TEntity> where TEntity : class, IWhippetEntity
    {
        /// <summary>
        /// Gets the <see cref="IWhippetQueryRepository{TEntity}"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetQueryRepository<TEntity> Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetQueryHandler{TEntity}"/> class with no arguments.
        /// </summary>
        private WhippetQueryHandler()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetQueryHandler{TEntity}"/> class with the specified repository.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetQueryHandler(IWhippetQueryRepository<TEntity> repository)
            : this()
        {
            if(repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                Repository = repository;
            }
        }
    }
}
