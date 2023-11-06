using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.AccessControl;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.EntityMappings.AccessControl
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetGroup"/> objects.
    /// </summary>
    public class WhippetGroupMap : WhippetAuditableFluentMap<WhippetGroup>
    {
        private const string TABLE_NAME = "Groups";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupMap"/> class with no arguments.
        /// </summary>
        public WhippetGroupMap()
            : base(TABLE_NAME)
        {
            Map(r => r.Name).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();
            Map(r => r.Description).Length(ObjectExtensionMethods.GetMaximumStringLength()).Nullable();
            Map(r => r.IsSystem).Not.Nullable();

            References<WhippetTenant>(t => t.Tenant).Not.Nullable().LazyLoad(Laziness.False);

            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
    }
}
