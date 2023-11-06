using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Delegate that is passed to the <see cref="NHibernateWhippetBootstrapper"/> to load all entity mappings before a session is created.
    /// </summary>
    /// <param name="options"><see cref="NHibernateConfigurationOptions"/> to load configuration for.</param>
    /// <param name="externalMappings">External mappings to assign to the <see cref="NHibernateConfigurationOptions"/>.</param>
    public delegate void NHibernateBootstrapperMappingDelegate(ref NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null);
}

