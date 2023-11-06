using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Provides mapping support for Fluent NHibernate entities by being invoked by <see cref="FluentMappingsContainer.AddFromAssembly(System.Reflection.Assembly)"/>. This class must be inherited.
    /// </summary>
    public abstract class FluentEntityMapperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentEntityMapperBase"/> class with no arguments.
        /// </summary>
        protected FluentEntityMapperBase()
        { }
    }
}
