using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Provides access to internal constants that are applied to Whippet domain objects. This class cannot be inherited.
    /// </summary>
    internal static class InternalAggregateConstantsIndex
    {
        /// <summary>
        /// Maximum length that a <see cref="string"/> can be for an aggregate name.
        /// </summary>
        internal const short ENTITY_NAME_MAX_LENGTH = 1024;

        /// <summary>
        /// Maximum length that Google's crawler can handle as well as Internet Explorer.
        /// </summary>
        internal const short GOOGLE_MAXIMUM_URL_LENGTH = 1855;

        /// <summary>
        /// Maximum length of a string. In SQL-based databases, this is typically stored in an NVARCHAR(MAX) or VARBINARY field.
        /// </summary>
        internal const int STRING_MAX_LENGTH = 5000;

        /// <summary>
        /// Default maximum length of a string. In SQL-based databases, this is typically stored in a VARCHAR or NVARCHAR field.
        /// </summary>
        internal const int STRING_DEFAULT_LENGTH = byte.MaxValue;
    }
}
