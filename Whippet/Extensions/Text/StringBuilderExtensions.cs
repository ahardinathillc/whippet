using System;
using System.Text;

namespace Athi.Whippet.Extensions.Text
{
    /// <summary>
    /// Provides extension methods to <see cref="StringBuilder"/> objects. This class cannot be inherited.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends an individual space to the end of the string in the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder"><see cref="StringBuilder"/> object.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static StringBuilder AppendSpace(this StringBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            else
            {
                return builder.Append(' ');
            }
        }
    }
}

