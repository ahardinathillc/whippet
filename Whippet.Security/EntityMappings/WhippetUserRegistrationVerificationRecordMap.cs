using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Security.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetUserRegistrationVerificationRecord"/> objects.
    /// </summary>
    public class WhippetUserRegistrationVerificationRecordMap : WhippetAuditableFluentMap<WhippetUserRegistrationVerificationRecord>
    {
        private const string TABLE_NAME = "[Security.Users.Verification]";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecordMap"/> class with no arguments.
        /// </summary>
        public WhippetUserRegistrationVerificationRecordMap()
            : base(TABLE_NAME)
        {
            Map(u => u.UserName).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();
            Map(u => u.AuthenticationKey).Length(ObjectExtensionMethods.GetMaximumStringLength()).Not.Nullable();
            Map(u => u.AuthenticationUrl).Length(ObjectExtensionMethods.GetMaximumGoogleUrlLength()).Not.Nullable();
            Map(u => u.IPAddress).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Nullable();
            Map(u => u.RequestExpirationDate).CustomType<InstantUserType>().Not.Nullable();
            Map(u => u.DateAuthenticated).CustomType<NullableInstantUserType>().Nullable();
            Map(u => u.UserId).Nullable();

            this.MapDeletedEntity();
        }
    }
}
