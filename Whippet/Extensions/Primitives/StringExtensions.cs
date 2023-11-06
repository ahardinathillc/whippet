using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Text.RegularExpressions;
using Athi.Whippet.Data;

namespace Athi.Whippet.Extensions.Primitives
{
    /// <summary>
    /// Provides extension methods to <see cref="string"/> types. This class cannot be inherited.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Gets the maximum length of a string. In SQL-based databases, this is typically stored in an NVARCHAR(MAX) or VARBINARY field.
        /// </summary>
        /// <param name="o"><see cref="object"/> used to invoke the method.</param>
        /// <returns><see cref="int"/> representing the maximum length of a string.</returns>
        public static int GetMaximumStringLength(this object o)
        {
            return InternalAggregateConstantsIndex.STRING_MAX_LENGTH;
        }

        /// <summary>
        /// Default maximum length of a string. In SQL-based databases, this is typically stored in a VARCHAR or NVARCHAR field.
        /// </summary>
        /// <param name="o"><see cref="object"/> used to invoke the method.</param>
        /// <returns><see cref="int"/> representing the default length of a string.</returns>
        public static int GetDefaultStringLength(this object o)
        {
            return InternalAggregateConstantsIndex.STRING_DEFAULT_LENGTH;
        }

        /// <summary>
        /// Gets the maximum length that an entity name can be by default.
        /// </summary>
        /// <param name="o"><see cref="object"/> used to invoke the method.</param>
        /// <returns><see cref="int"/> representing the maximum length the entity name can be by default.</returns>
        public static int GetDefaultEntityNameMaxLength(this object o)
        {
            return InternalAggregateConstantsIndex.ENTITY_NAME_MAX_LENGTH;
        }

        /// <summary>
        /// Gets the maximum length of a URL that Google (and Internet Explorer) can parse.
        /// </summary>
        /// <param name="o"><see cref="object"/> used to invoke the method.</param>
        /// <returns><see cref="int"/> representing the maximum length a URL can be that Google (and Internet Explorer) can parse.</returns>
        public static short GetMaximumGoogleUrlLength(this object o)
        {
            return InternalAggregateConstantsIndex.GOOGLE_MAXIMUM_URL_LENGTH;
        }

        /// <summary>
        /// Determines if all characters in the given <see cref="string"/> are digits.
        /// </summary>
        /// <param name="value"><see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if all characters in the <see cref="string"/> are digits; otherwise, <see langword="false"/>.</returns>
        public static bool AllNumbers(this string value)
        {
            bool allNumbers = false;

            if(!String.IsNullOrWhiteSpace(value))
            {
                for(int i = 0; i < value.Length; i++)
                {
                    if(!Char.IsDigit(value[i]))
                    {
                        allNumbers = false;
                        break;
                    }
                    else
                    {
                        allNumbers = true;
                    }
                }
            }

            return allNumbers;
        }

        /// <summary>
        /// Truncates a <see cref="string"/>.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="length">Maximum length a string can be. If <paramref name="input"/> is longer than this value, then it will be truncated.</param>
        /// <param name="useElipses">If <see langword="true"/>, will append elipses ("...") to the end of the truncated string.</param>
        /// <returns><see cref="string"/> object.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static string Truncate(this string input, int length, bool useElipses = true)
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(input))
                {
                    if (input.Length > length)
                    {
                        input = input.Substring(0, length);

                        if (useElipses)
                        {
                            input = input.Substring(0, input.Length - 3) + "...";
                        }
                    }
                }

                return input;
            }
        }

        /// <summary>
        /// Removes any spaces inside the input string.
        /// </summary>
        /// <param name="input">Input string to remove spaces from.</param>
        /// <returns>Input string to remove spaces from.</returns>
        public static string RemoveSpaces(this string input)
        {
            StringBuilder output = new StringBuilder();
            string[] pieces = null;

            if (!String.IsNullOrWhiteSpace(input))
            {
                input = input.Trim();
                pieces = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string piece in pieces)
                {
                    output.Append(piece);
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Splits a camel-case string into separate values concatenated into one string separated by a space.
        /// </summary>
        /// <param name="value">Value to split.</param>
        /// <returns>Separated value based on camel-case styling.</returns>
        public static string SplitCamelCase(this string value)
        {
            string returnValue = String.Empty;

            if (!String.IsNullOrWhiteSpace(value))
            {
                returnValue = Regex.Replace(value, @"((?<=[A-Z])([A-Z])(?=[a-z]))|((?<=[a-z]+)([A-Z]))", @" $0", RegexOptions.Compiled).Trim();
            }

            return returnValue;
        }

        /// <summary>
        /// Converts the specified value to camel case.
        /// </summary>
        /// <param name="value"><see cref="String"/> value to convert.</param>
        /// <param name="changeWordCaps">If set to <see langword="true"/> letters in a word (apart from the first) will be lowercased.</param>
        /// <param name="culture">The culture to use to change the case of the characters or <see langword="null"/> to use <see cref="CultureInfo.InvariantCulture"/>.</param>
        /// <returns>Camel case <see cref="string"/> value.</returns>
        /// <remarks>See <a href="https://stackoverflow.com/a/7119707">Regex camelcase in c#</a> for more information.</remarks>
        public static string ToCamelCase(this string value, bool changeWordCaps = true, CultureInfo culture = null)
        {
            StringBuilder result = new StringBuilder();
            bool lastWasBreak = true;
            char c;

            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
            }

            if (!String.IsNullOrWhiteSpace(value))
            {
                for (int i = 0; i < value.Length; i++)
                {
                    c = value[i];

                    if (char.IsWhiteSpace(c) || char.IsPunctuation(c) || char.IsSeparator(c))
                    {
                        lastWasBreak = true;
                    }
                    else if (char.IsNumber(c))
                    {
                        result.Append(c);
                        lastWasBreak = true;
                    }
                    else
                    {
                        if (result.Length == 0)
                        {
                            result.Append(char.ToLower(c, culture));
                        }
                        else if (lastWasBreak)
                        {
                            result.Append(char.ToUpper(c, culture));
                        }
                        else if (changeWordCaps)
                        {
                            result.Append(char.ToLower(c, culture));
                        }
                        else
                        {
                            result.Append(c);
                        }

                        lastWasBreak = false;
                    }
                }

            }

            return result.ToString();
        }

        /// <summary>
        /// Concatenates all <see cref="string"/> entries in the specified <see cref="IEnumerable{T}"/> separated by <paramref name="delimiter"/>.
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection of <see cref="string"/> objects.</param>
        /// <param name="delimiter">Delimiter that separates each entry.</param>
        /// <returns><see cref="IEnumerable{T}"/> entries separated by <paramref name="delimiter"/>.</returns>
        public static string Concat(this IEnumerable<string> collection, string delimiter)
        {
            StringBuilder builder = new StringBuilder();
            int maxLength = -1;

            if (collection != null && collection.Any())
            {
                maxLength = collection.Count();

                for (int i = 0; i < maxLength; i++)
                {
                    builder.Append(collection.ElementAt(i));

                    if (i < (maxLength - 1))
                    {
                        builder.Append(delimiter);
                    }
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts the specified <see cref="String"/> to a UTF-8 base-64 encoded string.
        /// </summary>
        /// <param name="plainText">Plain text value to encode.</param>
        /// <returns>UTF-8 base-64 encoded string.</returns>
        public static string ToBase64(this string plainText)
        {
            string base64 = null;
            byte[] base64Bytes = null;

            if (!String.IsNullOrWhiteSpace(plainText))
            {
                base64Bytes = Encoding.UTF8.GetBytes(plainText);
                base64 = Convert.ToBase64String(base64Bytes);
            }
            
            return base64;
        }

        /// <summary>
        /// Converts the specified UTF-8 base-64 encoded <see cref="String"/> to a plaintext value.
        /// </summary>
        /// <param name="encodedText">UTF-8 base-64 encoded <see cref="String"/>.</param>
        /// <returns>UTF-8 plaintext value.</returns>
        public static string FromBase64(this string encodedText)
        {
            string plainText = null;
            byte[] base64Bytes = null;

            if (!String.IsNullOrWhiteSpace(encodedText))
            {
                base64Bytes = Convert.FromBase64String(encodedText);
                plainText = Encoding.UTF8.GetString(base64Bytes);
            }
            
            return plainText;
        }
    }
}
