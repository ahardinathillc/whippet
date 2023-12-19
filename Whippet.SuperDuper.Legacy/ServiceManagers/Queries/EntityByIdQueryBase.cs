using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Base class for all queries in the Super Duper legacy framework that query based on the entity's ID. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="SuperDuperLegacyEntity"/> type to query.</typeparam>
    public abstract class EntityByIdQueryBase<TEntity> : WhippetQuery<TEntity>, IWhippetQuery<TEntity> where TEntity : SuperDuperLegacyEntity, new()
    {
        /// <summary>
        /// Gets the ID of the entity to retrieve. This property is read-only.
        /// </summary>
        public virtual int ID
        {
            get;
            protected set;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityByIdQueryBase{T}"/> class with no arguments.
        /// </summary>
        protected EntityByIdQueryBase()
            : this(default(int))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityByIdQueryBase{T}"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Entity ID to query by.</param>
        public EntityByIdQueryBase(int id)
            : base()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(ID), ID);

            return parameters;
        }
        
    }
}
