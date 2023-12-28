using System;
using System.IO;
using System.Reflection;
using RuntimeEnvironment = System.Environment;
using FluentNHibernate.Cfg;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Data.NHibernate.MappingIndex
{
    /// <summary>
    /// Maps all Whippet entities to Fluent NHibernate. This class cannot be inherited.
    /// </summary>
    public static class WhippetNHibernateMappingIndex
    {
        /// <summary>
        /// Configures the Fluent mappings for Whippet.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="externalMappings">External mappings to add to the mapping index.</param>
        public static void ConfigureMappings(NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null)
        {
            IEnumerable<Assembly> externalAssemblies = null;

            options.MappingConfiguration = new Action<MappingConfiguration>(m =>
            {
                // core requirements
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Localization.Addressing.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Security.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Web.Mvc.Security.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Networking.Smtp.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Applications.Setup.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Logging.Serilog.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Jobs.FluentEntityMapper>();

                // Third Party Integrations
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Salesforce.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Adobe.Magento.FluentEntityMapper>();

                // External fluent mappings that are stored in 3rd-party or external assemblies

                //m.FluentMappings.AddFromAssembly()

                //externalAssemblies = LoadExternalTypes();

                if (externalAssemblies != null && externalAssemblies.Any())
                {
                    foreach (Assembly asm in externalAssemblies)
                    {
                        m.FluentMappings.AddFromAssembly(asm);
                    }
                }

                if (externalMappings != null)
                {
                    externalMappings(m);
                }
            });
        }

        /// <summary>
        /// Configures the Fluent mappings for Microsoft SQL Server (default) databases.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="externalMappings">External mappings to add to the mapping index.</param>
        [Obsolete("This method is obsolete and will be removed in a future version. Use " + nameof(ConfigureMappings) + " instead.", false)]
        public static void ConfigureMicrosoftSqlServerMappings(NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null)
        {
            ConfigureMappings(options, externalMappings);
        }
    }
}
