using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Provides constants that are used with NHibernate configuration and use. This class cannot be inherited.
    /// </summary>
    public static class NHibernateConstantsIndex
    {
        private const string CS_PRIMARY = "whippet";
        private const string SCHEMA_DEFAULT = "whippet";

        /// <summary>
        /// Name of the primary database connection string stored in the configuration file. This property is read-only.
        /// </summary>
        public static string PrimaryConnectionStringName
        {
            get
            {
                return CS_PRIMARY;
            }
        }

        /// <summary>
        /// Name of the default schema used by the application. This property is read-only.
        /// </summary>
        public static string DefaultSchemaName
        {
            get
            {
                return SCHEMA_DEFAULT;
            }
        }
    }
}
