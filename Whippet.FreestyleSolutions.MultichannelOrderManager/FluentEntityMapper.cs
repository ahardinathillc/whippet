using System;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Provides mapping support for Fluent NHibernate entities by being invoked by <see cref="FluentNHibernate.Cfg.FluentMappingsContainer.AddFromAssembly(System.Reflection.Assembly)"/>. This class cannot be inherited.
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
