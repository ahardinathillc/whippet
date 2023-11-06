using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a collection of <typeparamref name="TEntity"/> objects indexed by their <see cref="Guid"/> identiers. This class is read-only.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="WhippetAggregateEntity"/> object type stored in the collection.</typeparam>
    public sealed class WhippetAggregateEntityCollection<TEntity> : Dictionary<Guid, TEntity> where TEntity : WhippetAggregateEntity
    {
        /// <summary>
        /// Gets or sets the internal <see cref="WhippetAggregateRoot"/> object.
        /// </summary>
        private WhippetAggregateRoot AggregateRoot
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCollection{TEntity}"/> class with no arguments.
        /// </summary>
        private WhippetAggregateEntityCollection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCollection{TEntity}"/> class with the specified <see cref="WhippetAggregateRoot"/>.
        /// </summary>
        /// <param name="aggregateRoot"><see cref="WhippetAggregateRoot"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetAggregateEntityCollection(WhippetAggregateRoot aggregateRoot)
            : this(aggregateRoot, new Dictionary<Guid, TEntity>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCollection{TEntity}"/> class with the specified <see cref="WhippetAggregateRoot"/>.
        /// </summary>
        /// <param name="aggregateRoot"><see cref="WhippetAggregateRoot"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetAggregateEntityCollection(WhippetAggregateRoot aggregateRoot, IEnumerable<KeyValuePair<Guid, TEntity>> collection)
            : base(collection)
        {
            if (aggregateRoot == null)
            {
                throw new ArgumentNullException(nameof(aggregateRoot));
            }
            else
            {
                AggregateRoot = aggregateRoot;
            }
        }
    }
}
