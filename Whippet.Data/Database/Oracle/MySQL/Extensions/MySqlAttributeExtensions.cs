using System;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="MySqlAttribute"/> objects. This class cannot be inherited.
    /// </summary>
    public static class MySqlAttributeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="MySqlAttribute"/> object to a <see cref="WhippetMySqlAttribute"/> object.
        /// </summary>
        /// <param name="attribute"><see cref="MySqlAttribute"/> object.</param>
        /// <returns><see cref="WhippetMySqlAttribute"/> object.</returns>
        public static WhippetMySqlAttribute ToWhippetMySqlAttribute(this MySqlAttribute attribute)
        {
            WhippetMySqlAttribute wAttrib = null;

            if (attribute != null)
            {
                if (attribute is WhippetMySqlAttribute)
                {
                    wAttrib = (WhippetMySqlAttribute)(attribute);
                }
                else
                {
                    wAttrib = new WhippetMySqlAttribute(attribute);
                }
            }

            return wAttrib;
        }
    }
}

