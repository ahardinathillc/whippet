using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods to all <see cref="Object"/> instances. This class cannot be inherited.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Resolves the location of the assembly-scoped resource file for the specified object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Object type to resolve the assembly location for.</typeparam>
        /// <param name="obj">Object to invoke the method on.</param>
        /// <param name="fileName">Assembly resource filename.</param>
        /// <returns>Full path to the assembly resource file.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string ResolveAssemblyResourceFile<T>(this object obj, string fileName)
        {
            return ResolveAssemblyResourceFile(obj, typeof(T), fileName);
        }

        /// <summary>
        /// Resolves the location of the assembly-scoped resource file for the specified object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">Object to invoke the method on.</param>
        /// <param name="type">Object type to resolve the assembly location for.</param>
        /// <param name="fileName">Assembly resource filename.</param>
        /// <returns>Full path to the assembly resource file.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string ResolveAssemblyResourceFile(this object obj, Type type, string fileName)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            else
            {
                return Path.Combine(Path.GetDirectoryName(type.Assembly.Location), fileName);
            }
        }

        /// <summary>
        /// Parses the specified object to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="obj">Object to parse.</param>
        /// <returns><see cref="bool"/> value.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        public static bool ParseBoxedNumericValueToBool(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else if (!obj.GetType().IsNumericType())
            {
                throw new InvalidCastException();
            }
            else
            {
                if (Convert.ToInt64(obj) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Helper method that allows quick access to <see cref="String.Equals(string?, string?, StringComparison)"/>.
        /// </summary>
        /// <param name="obj"><see cref="Object"/> object.</param>
        /// <param name="x">First <see cref="String"/> to compare.</param>
        /// <param name="y">Second <see cref="String"/> to compare.</param>
        /// <returns><see langword="true"/> if the strings are equal; otherwise, <see langword="false"/>.</returns>
        public static bool StringInvariantIgnoreCaseEquals(this object obj, string x, string y)
        {
            return String.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
