using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Extensions.Primitives
{
    /// <summary>
    /// Provides extension methods to <see cref="Boolean"/> objects. This class cannot be inherited.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="bool"/> value to its <see cref="YesNoValue"/> equivalent.
        /// </summary>
        /// <param name="value"><see cref="bool"/> value.</param>
        /// <returns><see cref="YesNoValue"/> value.</returns>
        public static YesNoValue ToYesNo(this bool value)
        {
            return value ? YesNoValue.Yes : YesNoValue.No;
        }

        /// <summary>
        /// Converts the specified <see cref="bool"/> value to its <see cref="YesNoUnspecifiedValue"/> equivalent.
        /// </summary>
        /// <param name="value">Nullable <see cref="bool"/> value.</param>
        /// <returns><see cref="YesNoUnspecifiedValue"/> value.</returns>
        public static YesNoUnspecifiedValue ToYesNoUnspecified(this bool? value)
        {
            if (value.HasValue)
            {
                return Enum.Parse<YesNoUnspecifiedValue>(Convert.ToInt32(value.Value.ToYesNo()).ToString());
            }
            else
            {
                return YesNoUnspecifiedValue.Unspecified;
            }
        }
    }
}
