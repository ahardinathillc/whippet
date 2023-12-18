using System;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for all <see cref="IMultichannelOrderManagerEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IMultichannelOrderManagerEntity"/> object that is to be mapped.</typeparam>
    /// <remarks>See https://github.com/nhibernate/fluent-nhibernate/wiki/Fluent-mapping for more information.</remarks>
    public abstract class MultichannelOrderManagerFluentMap<T> : WhippetFluentMap<T>, IMappingProvider where T : IMultichannelOrderManagerEntity, new() 
    {
        protected new const string DEFAULT_SCHEMA = "dbo";
    
        /// <summary>
        /// Gets the default primary key column name for the entity for mapping. Override this property to change the primary key column name that will be mapped in the data source. This property is read-only.
        /// </summary>
        protected override string DefaultPrimaryKeyColumnName
        {
            get
            {
                return String.Empty;        // MOM does not have a default key column; it depends on table
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        protected MultichannelOrderManagerFluentMap(string table, string schema = DEFAULT_SCHEMA)
            : base(table, schema, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected MultichannelOrderManagerFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }
    }
}
