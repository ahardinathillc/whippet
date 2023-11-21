using System;
using System.IO;
using System.Reflection;
using RuntimeEnvironment = System.Environment;
using NHibernate;
using FluentNHibernate.Cfg;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Data.NHibernate.MappingIndex
{
    /// <summary>
    /// Maps all Whippet entities to Fluent NHibernate. This class cannot be inherited.
    /// </summary>
    public static class WhippetNHibernateMappingIndex
    {
        private const char FLUENT_FILE_COMMENT = '#';
        private const string FLUENT_FILE = "Fluent_ExternalMappings.map";

        /// <summary>
        /// Configures the Fluent mappings the default database platform (Microsoft SQL Server). Note that the mappings are compatible across most database platforms.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="externalMappings">External mappings to add to the mapping index.</param>
        public static void ConfigureMappings(ref NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null)
        {
            ConfigureMicrosoftSqlServerMappings(ref options, externalMappings);
        }

        /// <summary>
        /// Configures the Fluent mappings for Microsoft SQL Server (default) databases.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="externalMappings">External mappings to add to the mapping index.</param>
        public static void ConfigureMicrosoftSqlServerMappings(ref NHibernateConfigurationOptions options, Action<MappingConfiguration> externalMappings = null)
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

                // Oswald
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.FluentEntityMapper>();

                // Third Party Integrations
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Salesforce.FluentEntityMapper>();
                m.FluentMappings.AddFromAssemblyOf<Athi.Whippet.Adobe.Magento.FluentEntityMapper>();

                // manual mappings
                Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.FluentEntityMapper adobeMagentoTaxesMapper = new Oswald.Integrations.Adobe.Magento.Taxes.FluentEntityMapper(m);

                // External fluent mappings that are stored in 3rd-party or external assemblies

                //m.FluentMappings.AddFromAssembly()

                externalAssemblies = LoadExternalTypes();

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
        /// Loads all external assemblies defined in <see cref="FLUENT_FILE"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Assembly"/> objects.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="FileLoadException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="BadImageFormatException" />
        private static IEnumerable<Assembly> LoadExternalTypes()
        {
            List<Assembly> externalTypes = new List<Assembly>();

            Type[] assemblyTypes = null;

            string rawText = null;
            string[] lines = null;

            Assembly asm = null;

            if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FLUENT_FILE)))
            {
                rawText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FLUENT_FILE));

                if (!String.IsNullOrWhiteSpace(rawText))
                {
                    if (RuntimeEnvironment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        lines = rawText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    }
                    else
                    {
                        lines = rawText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    }

                    if (lines != null && lines.Length > 0)
                    {
                        foreach (string line in lines)
                        {
                            if (!String.IsNullOrWhiteSpace(line) && !line.StartsWith(FLUENT_FILE_COMMENT))
                            {
                                try
                                {
                                    if (File.Exists(line))
                                    {
                                        asm = Assembly.LoadFile(line);

                                        if (asm != null)
                                        {
                                            assemblyTypes = asm.GetTypes();

                                            if (assemblyTypes != null && assemblyTypes.Length > 0)
                                            {
                                                // see if it has a Fluent mapper

                                                foreach (Type t in assemblyTypes)
                                                {
                                                    if (typeof(FluentEntityMapperBase).IsAssignableFrom(t))
                                                    {
                                                        externalTypes.Add(asm);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    // we don't have a logger, so we'll have to write it to the standard 
                                    // error stream
                                    
                                    Console.Error.WriteLine(e.ToString());
                                }
                            }
                        }
                    }
                }
            }

            return externalTypes.AsReadOnly();
        }
    }
}
