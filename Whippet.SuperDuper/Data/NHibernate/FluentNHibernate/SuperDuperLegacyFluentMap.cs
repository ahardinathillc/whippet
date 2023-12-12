using System;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.SuperDuper.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for all <see cref="ISuperDuperLegacyEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="ISuperDuperLegacyEntity"/> object that is to be mapped.</typeparam>
    /// <remarks>See https://github.com/nhibernate/fluent-nhibernate/wiki/Fluent-mapping for more information.</remarks>
    public abstract class SuperDuperLegacyFluentMap<T> : WhippetFluentMap<T>, IMappingProvider where T : ISuperDuperLegacyEntity, new()
    {
        private const string ID_COL = "id";
        
        private new const string DEFAULT_SCHEMA = "dbo";

        /// <summary>
        /// Gets the default primary key column name for the entity for mapping. Override this property to change the primary key column name that will be mapped in the data source. This property is read-only.
        /// </summary>
        protected override string DefaultPrimaryKeyColumnName
        {
            get
            {
                return ID_COL;
            }
        }
        
        /// <summary>
        /// Gets the mapping's schema. This property is read-only.
        /// </summary>
        public new string TableSchema
        { get; private set; }

        /// <summary>
        /// Gets the mapping's table. This property is read-only.
        /// </summary>
        public new string TableName
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperLegacyFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected SuperDuperLegacyFluentMap(string table, string schema = DEFAULT_SCHEMA, bool useDefaultPrimaryKeyBinding = true)
            : base(table, schema, useDefaultPrimaryKeyBinding)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected SuperDuperLegacyFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }
        
        /// <summary>
        /// Configures the default bindings and map setup. This is method is called from the constructor.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected override void ConfigureDefaultBindings(string table, string schema, bool useDefaultPrimaryKeyBinding)
        {
            if (useDefaultPrimaryKeyBinding)
            {
                Id(x => x.ID)
                    .Column(DefaultPrimaryKeyColumnName)
                    .Not.Nullable()
                    .GeneratedBy.Increment();
            }

            if (!String.IsNullOrWhiteSpace(schema))
            {
                Schema(schema);
            }

            if (!String.IsNullOrWhiteSpace(table))
            {
                Table(table);
            }

            TableSchema = schema;
            TableName = table;
        }
    }
}
