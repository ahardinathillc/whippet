using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Applications.Setup.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetSetting"/> objects.
    /// </summary>
    public class WhippetSettingMap : WhippetFluentMap<WhippetSetting>
    {
        private const string TABLE_NAME = "[System.Configuration]";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingMap"/> class with no arguments.
        /// </summary>
        public WhippetSettingMap()
            : base(TABLE_NAME)
        {
            Map(s => s.SettingID).Not.Nullable();
            Map(s => s.Name).Length(255).Not.Nullable();
            Map(s => s.Description).Length(1024).Nullable();
            Map(s => s.BoolValue).Nullable();
            Map(s => s.ByteValue).CustomSqlType(SqlServerVarBinaryMaxCustomType).Length(Int32.MaxValue).Nullable();
            Map(s => s.DecimalValue).Nullable();
            Map(s => s.DoubleValue).Nullable();
            Map(s => s.GuidValue).Nullable();
            Map(s => s.InstantValue).CustomType<NullableInstantUserType>().Nullable();
            Map(s => s.IntegerValue).Nullable();
            Map(s => s.StringValue).Length(SqlServerNVarCharMaxLength).Nullable();

            References<WhippetSettingGroup>(s => s.Group).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
