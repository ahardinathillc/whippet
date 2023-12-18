using System;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.SuperDuper.Data
{
    /// <summary>
    /// Base class for all <see cref="ISuperDuperEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="ISuperDuperEntity"/> object that is to be mapped.</typeparam>
    public abstract class SuperDuperFluentMap<T> : WhippetFluentMap<T>, IMappingProvider where T : ISuperDuperEntity, new()
    {
        private const string TABLE_PREFIX = "SuperDuper..";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="WhippetFluentMap{T}.DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected SuperDuperFluentMap(string table, string schema = DEFAULT_SCHEMA, bool useDefaultPrimaryKeyBinding = true)
            : base(PrefixTableName(TABLE_PREFIX, table), schema, useDefaultPrimaryKeyBinding)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected SuperDuperFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }
    }
}
