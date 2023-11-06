using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.Customer
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
