using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Configures NHibernate for use with a Microsoft SQL Server database. This class cannot be inherited.
    /// </summary>
    internal sealed class WhippetSqlServerNHibernateDatabaseConfiguration
    {
        /// <summary>
        /// Configures the NHibernate for use with a SQL Server database engine.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="sqlConnectionString">SQL Server connection string.</param>
        public static void ConfigureForSqlServer(ref NHibernateConfigurationOptions options, string sqlConnectionString)
        {
            options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => MsSqlConfiguration.MsSql2012.ConnectionString(sqlConnectionString));
        }
    }
}
