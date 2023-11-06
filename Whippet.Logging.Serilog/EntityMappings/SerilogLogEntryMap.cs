using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes;

namespace Athi.Whippet.Logging.Serilog.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="SerilogLogEntry"/>.
    /// </summary>
    public class SerilogLogEntryMap : WhippetFluentMap<SerilogLogEntry>
    {
        private const string TABLE_NAME = "Serilog_Log";

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogEntryMap"/> class with no arguments.
        /// </summary>
        public SerilogLogEntryMap()
            : base(TABLE_NAME)
        {
            Id(l => l.ID).GeneratedBy.Identity().Not.Nullable();
            Map(l => l.Message).Length(Int32.MaxValue).Nullable();
            Map(l => l.MessageTemplate).Length(Int32.MaxValue).Nullable();
            Map(l => l.Level).CustomType<SerilogLevelUserType>().Length(Int32.MaxValue).Nullable();
            Map(l => l.TimeStamp).Nullable();
            Map(l => l.Exception).Length(Int32.MaxValue).Nullable();
            Map(l => l.Properties).Length(Int32.MaxValue).Nullable();
        }
    }
}
