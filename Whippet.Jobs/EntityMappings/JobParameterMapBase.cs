using System;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.UserTypes;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Jobs.EntityMappings
{
    /// <summary>
    /// Base class for all <see cref="JobParameterBase{TJob}"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="TJob"><see cref="IJob"/> type that the parameter applies to.</typeparam>
    /// <typeparam name="TParameter"><see cref="IJobParameter"/> type.</typeparam>
    public abstract class JobParameterMapBase<TJob, TParameter> : WhippetFluentMap<TParameter>
        where TJob : JobBase, IJob, new()
        where TParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        private const string TABLE_NAME = "Job_{0}_Parameters_{1}";

        protected const string DEFAULT_PARAM_SUFFIX = "Params";

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterMapBase{TJob, TParameter}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected JobParameterMapBase(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterMapBase{TJob, TParameter}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="WhippetFluentMap{TParameter}.DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected JobParameterMapBase(string table, string schema, bool useDefaultPrimaryKeyBinding = true)
            : base(table, schema, useDefaultPrimaryKeyBinding)
        {
            Map(j => j.Name).Not.Nullable().Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength());
            Map(j => j.ParameterType).Nullable().CustomType<TypeUserType>().Length(ObjectExtensionMethods.GetMaximumStringLength());
            Map(j => j.ParameterID).Not.Nullable().ReadOnly();

            References<TJob>(j => j.Job).Not.Nullable().LazyLoad(Laziness.False);
        }

        /// <summary>
        /// Creates a table name for the current <see cref="IJobParameter"/>.
        /// </summary>
        /// <param name="tableName">Job table name.</param>
        /// <param name="parameterTableName">Parameter suffix to apply to the table name.</param>
        /// <returns>Table name for the current <see cref="IJobParameter"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        protected static string CreateTableName(string tableName, string parameterTableName)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }
            else if (String.IsNullOrWhiteSpace(parameterTableName))
            {
                throw new ArgumentNullException(nameof(parameterTableName));
            }
            else
            {
                return String.Format(TABLE_NAME, tableName, parameterTableName);
            }
        }
    }
}
