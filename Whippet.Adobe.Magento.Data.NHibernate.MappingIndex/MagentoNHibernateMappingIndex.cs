using System;
using FluentNHibernate.Cfg;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Adobe.Magento.Data.NHibernate.MappingIndex
{
    /// <summary>
    /// Maps all Magento entities to Fluent NHibernate for consumption by Whippet. This class cannot be inherited.
    /// </summary>
    public static class MagentoNHibernateMappingIndex
    {
        /// <summary>
        /// Configures the Fluent mappings the default database platform (Microsoft SQL Server). Note that the mappings are compatible across most database platforms.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="externalMappings">External mappings to add to the mapping index.</param>
        public static void ConfigureMappings(ref NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null)
        {
            ConfigureMagentoMappings(ref options, externalMappings);
        }

        /// <summary>
        /// Configures the Fluent mappings for Microsoft SQL Server (default) databases.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="externalMappings">External mappings to add to the mapping index.</param>
        public static void ConfigureMagentoMappings(ref NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null)
        {
            options.MappingConfiguration = new Action<MappingConfiguration>(m =>
            {
                // Sales Rule
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Adobe.Magento.SalesRule.FluentEntityMapper>();

                if (externalMappings != null)
                {
                    externalMappings(m);
                }
            });
        }
    }
}

