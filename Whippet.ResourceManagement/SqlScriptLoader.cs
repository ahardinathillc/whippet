using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.ResourceManagement
{
    /// <summary>
    /// SQL script resource loader used for loading SQL files.
    /// </summary>
    public class SqlScriptLoader : ResourceLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlScriptLoader"/> on the stack.
        /// </summary>
        static SqlScriptLoader()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringResourceLoader"/> class with no arguments.
        /// </summary>
        protected SqlScriptLoader()
            : base()
        { }

        /// <summary>
        /// Retrieves the specified SQL script file.
        /// </summary>
        /// <param name="fileName">SQL script file to load. Must have a .SQL extension.</param>
        /// <returns>SQL script file contents.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetSqlScript(string fileName)
        {
            // since it's a string, it's handled in the StringResourceLoader.
            return StringResourceLoader.GetSqlScript(fileName);
        }
    }
}
