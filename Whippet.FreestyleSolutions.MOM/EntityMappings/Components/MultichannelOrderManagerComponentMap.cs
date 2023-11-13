using System;
using FluentNHibernate.Mapping;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components
{
    /// <summary>
    /// Base class for all <see cref="MultichannelOrderManagerEntity"/> objects that are a <see cref="ComponentMap{T}"/>. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="MultichannelOrderManagerEntity"/>.</typeparam>
    public abstract class MultichannelOrderManagerComponentMap<TEntity> : ComponentMap<TEntity>
        where TEntity : MultichannelOrderManagerEntity
    {
        /// <summary>
        /// Generates a column name by prepending <paramref name="propertyName"/> with the type name of <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Column name to assign to the property.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string GenerateColumnName(string propertyName)
        {
            if (String.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            else
            {
                return typeof(TEntity).Name + "_" + propertyName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerComponentMap{TEntity}"/> class with no arguments.
        /// </summary>
        protected MultichannelOrderManagerComponentMap()
            : base()
        { }
    }
}
