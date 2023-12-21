using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Tools.Installer.ResourceFiles
{
    /// <summary>
    /// Provides an index of all resource messages available in the <see cref="Athi.Whippet.Tools.Installer"/> assembly. This class cannot be inherited.
    /// </summary>
    [Obsolete("This component is deprecated and will be removed in a future version.")]
    internal static class ResourceIndex
    {
        public const string InstallAction_Database_Name = nameof(InstallAction_Database_Name);
        public const string InstallAction_Database_Description = nameof(InstallAction_Database_Description);

        public const string InstallAction_Database = nameof(InstallAction_Database);
        public const string InstallAction_Database_Server = nameof(InstallAction_Database_Server);

        public const string InstallAction_Database_Server__AccountSetup1 = nameof(InstallAction_Database_Server__AccountSetup1);
        public const string InstallAction_Database_Server__DatabaseSetup1 = nameof(InstallAction_Database_Server__DatabaseSetup1);
        public const string InstallAction_Database_Server__DatabaseSetup2 = nameof(InstallAction_Database_Server__DatabaseSetup2);

        public const string InstallAction_Schema = nameof(InstallAction_Schema);
        public const string InstallAction_Schema_Description = nameof(InstallAction_Schema_Description);

        public const string InstallAction_Schema__SchemaSetup1 = nameof(InstallAction_Schema__SchemaSetup1);
        public const string InstallAction_Schema__SchemaSetup2 = nameof(InstallAction_Schema__SchemaSetup2);

        public const string InstallAction_Entity_Name = nameof(InstallAction_Entity_Name);
        public const string InstallAction_Entity_Description = nameof(InstallAction_Entity_Description);

        /// <summary>
        /// Provides an index of all SQL scripts available in the <see cref="Athi.Whippet.Tools.WhippetManager"/> assembly. This class cannot be inherited.
        /// </summary>
        internal static class SqlScripts
        {
            private const string SQL_EXT = ".sql";

            public const string WhippetAccount = nameof(WhippetAccount) + ".b5d6920e-51fa-4ec0-9f11-4724b6965860" + SQL_EXT;
            public const string WhippetDatabase = nameof(WhippetDatabase) + ".88829bc4-2efa-4845-b0cb-b954704b7da4" + SQL_EXT;
        }
    }
}
