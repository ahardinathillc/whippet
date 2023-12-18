using System;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for all <see cref="IMultichannelOrderManagerAuditableEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IMultichannelOrderManagerAuditableEntity"/> object that is to be mapped.</typeparam>
    public abstract class MultichannelOrderManagerAuditableFluentMap<T> : MultichannelOrderManagerFluentMap<T> where T : IMultichannelOrderManagerAuditableEntity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerAuditableFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        protected MultichannelOrderManagerAuditableFluentMap(string table, string schema = DEFAULT_SCHEMA)
            : this(table, schema, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerAuditableFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="includeModfiedBy">If <see langword="true"/>, will include the last modified and last modified timestamp columns.</param>
        protected MultichannelOrderManagerAuditableFluentMap(string table, string schema, bool includeModfiedBy)
            : base(table, schema)
        {
            Map(entity => entity.LastAccessed).Column("LU_ON").Not.Nullable().CustomType<NullableInstantUserType>();
            Map(entity => entity.LastAccessedBy).Column("LU_BY").Not.Nullable().Length(3).Default(String.Empty);

            if (includeModfiedBy)
            {
                Map(entity => entity.LastModified).Not.Nullable().CustomType<NullableInstantUserType>();
                Map(entity => entity.LastModifiedBy).Not.Nullable().Length(3).Default(String.Empty);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected MultichannelOrderManagerAuditableFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }
        
    }
}
