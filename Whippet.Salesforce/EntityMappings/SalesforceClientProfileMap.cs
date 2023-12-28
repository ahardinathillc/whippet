using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Salesforce.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="SalesforceClientProfile"/> objects.
    /// </summary>
    public class SalesforceClientProfileMap : WhippetAuditableFluentMap<SalesforceClientProfile>
    {
        private const string TABLE_NAME = "[Salesforce.Servers]";

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileMap"/> class with no arguments.
        /// </summary>
        public SalesforceClientProfileMap()
            : base(TABLE_NAME)
        {
            Map(sf => sf.ApiToken).Not.Nullable().Length(this.GetMaximumStringLength());
            Map(sf => sf.ConsumerKey).Not.Nullable().Length(this.GetMaximumStringLength());
            Map(sf => sf.ConsumerSecret).Not.Nullable().Length(this.GetMaximumStringLength());
            Map(sf => sf.Name).Not.Nullable().Length(this.GetMaximumStringLength());
            Map(sf => sf.Password).Nullable().Length(this.GetMaximumStringLength());
            Map(sf => sf.Url).Not.Nullable().Length(AdjustNvarCharSizeForSqlServer(this.GetMaximumGoogleUrlLength()));
            Map(sf => sf.Username).Nullable().Length(this.GetMaximumStringLength());
            Map(sf => sf.UseWebServerAuthenticationFlow).Not.Nullable();

            References<WhippetTenant>(sf => sf.Tenant).Not.Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
    }
}
