using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for all <see cref="IWhippetAuditableEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IWhippetAuditableEntity"/> object that is to be mapped.</typeparam>
    /// <remarks>See https://github.com/nhibernate/fluent-nhibernate/wiki/Fluent-mapping for more information.</remarks>
    public abstract class WhippetAuditableFluentMap<T> : WhippetFluentMap<T>, IMappingProvider where T : IWhippetAuditableEntity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAuditableFluentMap{T}"/> class with no arguments. Will default the primary key to <see cref="DefaultPrimaryKeyColumnName"/>.
        /// </summary>
        private WhippetAuditableFluentMap()
            : this(String.Empty, String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAuditableFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected WhippetAuditableFluentMap(string table, string schema = DEFAULT_SCHEMA, bool useDefaultPrimaryKeyBinding = true)
            : base(table, schema, useDefaultPrimaryKeyBinding)
        {
            Map(x => x.CreatedBy).Nullable();
            Map(x => x.CreatedDateTime).CustomType<InstantUserType>().Not.Nullable();
            Map(x => x.LastModifiedBy).Nullable();
            Map(x => x.LastModifiedDateTime).CustomType<InstantUserType>().Nullable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAuditableFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected WhippetAuditableFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }
    }
}
