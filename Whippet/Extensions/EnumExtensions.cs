using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Enum"/> objects. This class cannot be inherited.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="Enum"/> to an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by its enumeration values.
        /// </summary>
        /// <typeparam name="T"><see cref="Enum"/> type to convert.</typeparam>
        /// <param name="enumObject"><see cref="Enum"/> object.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the enumeration values.</returns>
        public static IReadOnlyDictionary<int, string> ToDictionary<T>(this T enumObject) where T : struct, Enum
        {
            Dictionary<int, string> kvPairs = new Dictionary<int, string>();

            foreach (T itemValue in Enum.GetValues<T>())
            {
                kvPairs.Add(Convert.ToInt32(itemValue), itemValue.ToString());
            }

            return kvPairs;
        }

        /// <summary>
        /// Converts the specified <see cref="YesNoValue"/> to a <see cref="YesNoUnspecifiedValue"/>.
        /// </summary>
        /// <param name="value"><see cref="YesNoValue"/> to convert.</param>
        /// <returns><see cref="YesNoUnspecifiedValue"/> value.</returns>
        public static YesNoUnspecifiedValue ToYesNoUnspecified(this YesNoValue value)
        {
            return Enum.Parse<YesNoUnspecifiedValue>(Convert.ToInt32(value).ToString());
        }

        /// <summary>
        /// Converts the specified <see cref="YesNoUnspecifiedValue"/> to a <see cref="YesNoValue"/>.
        /// </summary>
        /// <param name="value"><see cref="YesNoUnspecifiedValue"/> to convert.</param>
        /// <param name="unspecifiedEquivalent"><see cref="YesNoValue"/> to use if <paramref name="value"/> is set to <see cref="YesNoUnspecifiedValue.Unspecified"/>.</param>
        /// <returns><see cref="YesNoValue"/> value.</returns>
        /// <exception cref="Exception"></exception>
        public static YesNoValue ToYesNo(this YesNoUnspecifiedValue value, YesNoValue? unspecifiedEquivalent = null)
        {
            if (value == YesNoUnspecifiedValue.Unspecified)
            {
                if (!unspecifiedEquivalent.HasValue)
                {
                    throw new Exception("The supplied value is set to " + value.ToString() + ". Supply a value to " + nameof(unspecifiedEquivalent) + " in order to use this method.");
                }
                else
                {
                    if (value != YesNoUnspecifiedValue.Unspecified)
                    {
                        return value.ToYesNo();
                    }
                    else
                    {
                        return unspecifiedEquivalent.Value;
                    }
                }
            }
            else
            {
                return value.ToYesNo();
            }
        }

        /// <summary>
        /// Converts the specified <see cref="YesNoValue"/> to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="value"><see cref="YesNoValue"/> value.</param>
        /// <returns><see cref="Boolean"/> value.</returns>
        public static bool ToBoolean(this YesNoValue value)
        {
            return (value == YesNoValue.Yes) ? true : false;
        }

        /// <summary>
        /// Converts the specified <see cref="YesNoUnspecifiedValue"/> to its nullable <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="value"><see cref="YesNoUnspecifiedValue"/> value.</param>
        /// <returns><see cref="Boolean"/> value.</returns>
        public static bool? ToBoolean(this YesNoUnspecifiedValue value)
        {
            return (value == YesNoUnspecifiedValue.Unspecified) ? (bool?)(null) : value.ToYesNo().ToBoolean();
        }

        /// <summary>
        /// If an <see cref="Enum"/> value is decorated with a <see cref="DescriptionAttribute"/>, will return the value of the <see cref="DescriptionAttribute.Description"/>. Otherwise, will return the string representation of the value.
        /// </summary>
        /// <param name="value"><see cref="Enum"/> value.</param>
        /// <returns><see cref="DescriptionAttribute.Description"/> value or the string representation of the value if no attribute is applied.</returns>
        public static string GetDescription(this Enum value)
        {
            string returnValue = String.Empty;
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])(fi.GetCustomAttributes(typeof(DescriptionAttribute), false));

            if (attributes != null && attributes.Any())
            {
                returnValue = attributes[0].Description;
            }
            else
            {
                returnValue = value.ToString();
            }

            return returnValue;
        }

        /// <summary>
        /// Determines if the specified <see cref="Enum"/> value contains more than one value if the <see cref="FlagsAttribute"/> is applied.
        /// </summary>
        /// <typeparam name="TValue"><see cref="Enum"/> value type.</typeparam>
        /// <param name="flag"><see cref="Enum"/> of type <typeparamref name="TValue"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="Enum"/> contains more than one value; otherwise, <see langword="false"/>.</returns>
        public static bool HasMultipleFlags<TValue>(this TValue flag) where TValue : Enum
        {
            return (Convert.ToInt32(flag) & (Convert.ToInt32(flag) - 1)) != 0;
        }
    }
}
