using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="CustomerType_2"/> objects.
    /// </summary>
    public class CustomerType_2_Map : MultichannelOrderManagerFluentMap<CustomerType_2>
    {
        private const string TABLE_NAME = "CTYPE2";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType_2_Map"/> class with no arguments.
        /// </summary>
        public CustomerType_2_Map()
            : base(TABLE_NAME)
        {
            Map(t => t.Code).Column("CTYPE2").Length(2).Not.Nullable();
            Map(t => t.Description).Column("DESC2").Length(30).Not.Nullable();
        }
        
        /// <summary>
        /// Configures the default bindings and map setup. This is method is called from the constructor.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="MultichannelOrderManagerFluentMap{T}.DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected override void ConfigureDefaultBindings(string table, string schema, bool useDefaultPrimaryKeyBinding)
        {
            base.ConfigureDefaultBindings(table, schema, false);
            Id(t => t.ID).Column("CTYPE2_ID").Not.Nullable().GeneratedBy.Identity();
        }
    }
}
