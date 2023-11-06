using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Logging.Serilog
{
    /// <summary>
    /// Provides mapping support for Fluent NHibernate entities by being invoked by <see cref="FluentNHibernate.Cfg.FluentMappingsContainer.AddFromAssembly(System.Reflection.Assembly)"/>. This class must be inherited.
    /// </summary>
    public sealed class FluentEntityMapper : FluentEntityMapperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentEntityMapper"/> class with no arguments.
        /// </summary>
        private FluentEntityMapper()
            : base()
        { }
    }
}
