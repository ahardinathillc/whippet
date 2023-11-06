using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FluentNHibernate.Mapping;
using MailKit.Security;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.UserTypes;

namespace Athi.Whippet.Networking.Smtp.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mappings for <see cref="WhippetSmtpServerProfile"/>.
    /// </summary>
    public class WhippetSmtpServerProfileMap : WhippetAuditableFluentMap<WhippetSmtpServerProfile>
    {
        private const string TABLE_NAME = "Configuration__Smtp_Servers";

        private const string COL_SMTP_NAME = "SMTP__ServerName";
        private const string COL_SMTP_ADDR = "SMTP__ServerAddress";
        private const string COL_SMTP_PORT = "SMTP__PortAddress";
        private const string COL_SMTP_SSL = "SMTP__SecureSocketOption";
        private const string COL_SMTP_DEFAULT = "SMTP__IsDefault";
        private const string COL_SMTP_UNAME = "SMTP__Username";
        private const string COL_SMTP_PSWD = "SMTP__Password";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileMap"/> class with no arguments.
        /// </summary>
        public WhippetSmtpServerProfileMap()
            : base(TABLE_NAME)
        {
            Map(ss => ss.ServerName).Column(COL_SMTP_NAME).Length(this.GetDefaultStringLength()).Not.Nullable();
            Map(ss => ss.ServerAddress).Column(COL_SMTP_ADDR).Length(this.GetDefaultStringLength()).Not.Nullable();
            Map(ss => ss.PortNumber).Column(COL_SMTP_PORT).Not.Nullable();
            Map(ss => ss.SecureSocketOption).Column(COL_SMTP_SSL).CustomType<EnumUserType<SecureSocketOptions>>().Not.Nullable();
            Map(ss => ss.IsDefault).Column(COL_SMTP_DEFAULT).Not.Nullable();
            Map(ss => ss.Username).Column(COL_SMTP_UNAME).Length(this.GetDefaultStringLength()).Nullable();
            Map(ss => ss.Password).Column(COL_SMTP_PSWD).Length(this.GetDefaultStringLength()).Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();

            References<WhippetTenant>(ss => ss.Tenant).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
