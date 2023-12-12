using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Data.NHibernate.UserTypes;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.SuperDuper.EntityMappings
{
    /// <summary>
    /// Base class for Fluent mappings for <see cref="SuperDuperServer"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SuperDuperServerMap<TServer> : WhippetAuditableFluentMap<TServer> 
        where TServer : SuperDuperServer, ISuperDuperServer, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperServerMap{TServer}"/> class with the specified table name.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected SuperDuperServerMap(string tableName)
            : base(tableName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(tableName);

            Map(sdt => sdt.ServerType).CustomType<EnumUserType<ExternalDataSourceType>>().Not.Nullable();
            Map(sdt => sdt.Name).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Nullable();
            Map(sdt => sdt.Password).Length(ObjectExtensionMethods.GetMaximumStringLength()).Nullable();
            Map(sdt => sdt.Username).Length(ObjectExtensionMethods.GetDefaultStringLength()).Nullable();

            References<WhippetTenant>(sdt => sdt.Tenant).Not.Nullable();
            
            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
        
    }
}
