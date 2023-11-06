using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Configures NHibernate Fluent mappings for data entities. This class must be inherited.
    /// </summary>
    public abstract class FluentMappingIndex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentMappingIndex"/> class with no arguments.
        /// </summary>
        protected FluentMappingIndex()
        { }

        /// <summary>
        /// Configures Fluent mappings and applies them to the specified <see cref="NHibernateConfigurationOptions"/>. This method must be overridden.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> to apply the mappings to.</param>
        public abstract void ConfigureMappings(ref NHibernateConfigurationOptions options);
    }
}
