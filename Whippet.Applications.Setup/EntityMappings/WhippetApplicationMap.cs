using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetApplication"/> objects.
    /// </summary>
    public class WhippetApplicationMap : WhippetFluentMap<WhippetApplication>
    {
        private const string TABLE_NAME = "Applications";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationMap"/> class with no arguments.
        /// </summary>
        public WhippetApplicationMap()
            : base(TABLE_NAME)
        {
            Map(a => a.Name).Length(255).Not.Nullable();
            Map(a => a.ApplicationID).Not.Nullable();

            References<WhippetTenant>(a => a.Tenant).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
