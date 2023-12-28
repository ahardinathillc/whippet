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

namespace Athi.Whippet.Security.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetUser"/> objects.
    /// </summary>
    public class WhippetUserMap : WhippetAuditableFluentMap<WhippetUser>
    {
        private const string TABLE_NAME = "[Security.Users]";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserMap"/> class with no arguments.
        /// </summary>
        public WhippetUserMap()
            : base(TABLE_NAME)
        {
            Map(u => u.UserName).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();
            Map(u => u.Password).Length(ObjectExtensionMethods.GetMaximumStringLength()).Not.Nullable();
            Map(u => u.TimeZoneIdentifier).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();
            Map(u => u.Email).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();
            Map(u => u.IPAddress).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
    }
}
