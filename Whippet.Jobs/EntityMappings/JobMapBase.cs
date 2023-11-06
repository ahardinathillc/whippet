using System;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Mapping;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.UserTypes.Jobs;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;

namespace Athi.Whippet.Jobs.EntityMappings
{
    /// <summary>
    /// Base class for all <see cref="JobBase{TJob}"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="TJob"><see cref="IJob"/> type.</typeparam>
    public abstract class JobMapBase<TJob> : WhippetFluentMap<TJob>
        where TJob : JobBase, IJob, new()
    {
        private const string TABLE_NAME = "Job_{0}";

        /// <summary>
        /// Initializes a new instance of the <see cref="JobMapBase{TJob}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected JobMapBase(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobMapBase{TJob}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="WhippetFluentMap{TParameter}.DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected JobMapBase(string table, string schema, bool useDefaultPrimaryKeyBinding = true)
            : base(table, schema, useDefaultPrimaryKeyBinding)
        {
            Map(j => j.JobName).Not.Nullable().Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength());
            Map(j => j.JobDescription).Not.Nullable().Length(ObjectExtensionMethods.GetMaximumStringLength());
            Map(j => j.Schedule).Not.Nullable().CustomType<CronTabScheduleUserType>();

            this.MapActiveEntity();

            References<JobCategory>(j => j.Category).Not.Nullable().LazyLoad(Laziness.False);
            References<WhippetTenant>(j => j.Tenant).Not.Nullable().LazyLoad(Laziness.False);
        }

        /// <summary>
        /// Creates a table name for the current <see cref="IJob"/>.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns>Table name for the current <see cref="IJob"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        protected static string CreateTableName(string tableName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(tableName);
            return String.Format(TABLE_NAME, tableName);
        }
    }
}
