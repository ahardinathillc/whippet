using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Specifies the password complexity requirements set in the application's configuration file or data store.
    /// </summary>
    public struct WhippetPasswordComplexityOptions
    {
        private const string SECURITY_PATH = "WhippetSecuritySettings:PasswordComplexity";

        /// <summary>
        /// Gets the minimum length requirement of the password. This property is read-only.
        /// </summary>
        public int? MinimumLength
        { get; private set; }

        /// <summary>
        /// Gets the minimum number of alphabetical letters required for the password to be valid. This property is read-only.
        /// </summary>
        public int? MinimumLetters
        { get; private set; }

        /// <summary>
        /// Gets the minimum number of digits (0-9) required for the password to be valid. This property is read-only.
        /// </summary>
        public int? MinimumDigits
        { get; private set; }

        /// <summary>
        /// Gets the minimum number of uppercase alphabetical letters required for the password to be valid. This property is read-only.
        /// </summary>
        public int? MinimumUpperCase
        { get; private set; }

        /// <summary>
        /// Gets the minimum number of lowercase alphabetical letters required for the password to be valid. This property is read-only.
        /// </summary>
        public int? MinimumLowerCase
        { get; private set; }

        /// <summary>
        /// Gets the minimum number of non-alphanumeric characters required for the password to be valid. This property is read-only.
        /// </summary>
        public int? MinimumSymbols
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordComplexityOptions"/> struct with no arguments.
        /// </summary>
        public WhippetPasswordComplexityOptions()
            : this(null, null, null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordComplexityOptions"/> struct.
        /// </summary>
        /// <param name="minimumLength">Minimum length requirement of the password.</param>
        /// <param name="minimumLetters">Minimum number of alphabetical letters required for the password to be valid.</param>
        /// <param name="minimumDigits">Minimum number of digits (0-9) required for the password to be valid.</param>
        /// <param name="minimumUpperCase">Minimum number of uppercase alphabetical letters required for the password to be valid.</param>
        /// <param name="minimumLowerCase">Minimum number of lowercase alphabetical letters required for the password to be valid.</param>
        /// <param name="minimumSymbols">Minimum number of non-alphanumeric characters required for the password to be valid.</param>
        public WhippetPasswordComplexityOptions(int? minimumLength, int? minimumLetters, int? minimumDigits, int? minimumUpperCase, int? minimumLowerCase, int? minimumSymbols)
        {
            MinimumLength = minimumLength;
            MinimumLetters = minimumLetters;
            MinimumDigits = minimumDigits;
            MinimumUpperCase = minimumUpperCase;
            MinimumLowerCase = minimumLowerCase;
            MinimumSymbols = minimumSymbols;
        }

        /// <summary>
        /// Validates the specified password and returns an <see cref="IReadOnlyDictionary{TKey, TValue}"/> containing the properties and associated <see cref="Boolean"/> value that indicates whether the password satisfies the individual complexity requirement.
        /// </summary>
        /// <param name="password">Password to validate.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        public IReadOnlyDictionary<string, bool> ValidatePassword(string password)
        {
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            int digitCount = 0;
            int letterCount = 0;
            int symbolCount = 0;
            int upperCaseCount = 0;
            int lowerCaseCount = 0;

            results.Add(nameof(MinimumDigits), true);
            results.Add(nameof(MinimumLength), true);
            results.Add(nameof(MinimumLetters), true);
            results.Add(nameof(MinimumLowerCase), true);
            results.Add(nameof(MinimumSymbols), true);
            results.Add(nameof(MinimumUpperCase), true);

            if (String.IsNullOrWhiteSpace(password) || (password.Length < MinimumLength.GetValueOrDefault()))
            {
                results[nameof(MinimumLength)] = false;
            }

            // if the string is empty and all the other properties have a value, set them to false...

            if (String.IsNullOrWhiteSpace(password)
                    && ((MinimumDigits.GetValueOrDefault() > 0)
                        || (MinimumLetters.GetValueOrDefault() > 0)
                        || (MinimumLowerCase.GetValueOrDefault() > 0)
                        || (MinimumSymbols.GetValueOrDefault() > 0)
                        || (MinimumUpperCase.GetValueOrDefault() > 0)))
            {
                foreach (string key in results.Keys.Where(k => !String.Equals(k, nameof(MinimumLength), StringComparison.InvariantCultureIgnoreCase)))
                {
                    results[key] = false;
                }
            }

            if (!String.IsNullOrWhiteSpace(password))
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (Char.IsDigit(password[i]))
                    {
                        digitCount++;
                    }
                    else if (Char.IsLetter(password[i]))
                    {
                        letterCount++;

                        if (Char.IsLower(password[i]))
                        {
                            lowerCaseCount++;
                        }
                        else
                        {
                            upperCaseCount++;
                        }
                    }
                    else
                    {
                        symbolCount++;
                    }
                }

                // set the results
                results[nameof(MinimumDigits)] = digitCount >= MinimumDigits.GetValueOrDefault();
                results[nameof(MinimumLetters)] = letterCount >= MinimumLetters.GetValueOrDefault();
                results[nameof(MinimumLowerCase)] = lowerCaseCount >= MinimumLowerCase.GetValueOrDefault();
                results[nameof(MinimumSymbols)] = symbolCount >= MinimumSymbols.GetValueOrDefault();
                results[nameof(MinimumUpperCase)] = upperCaseCount >= MinimumUpperCase.GetValueOrDefault();
            }

            return results;
        }

        /// <summary>
        /// Parses the specified <see cref="IConfiguration"/> file to create a new <see cref="WhippetPasswordComplexityOptions"/> instance.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that represents the root configuration file.</param>
        /// <returns><see cref="WhippetPasswordComplexityOptions"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetPasswordComplexityOptions Parse(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            else
            {
                IConfiguration section = configuration.GetSection(SECURITY_PATH);

                int? minimumLength = null;
                int? minimumLetters = null;
                int? minimumDigits = null;
                int? minimumUpperCase = null;
                int? minimumLowerCase = null;
                int? minimumSymbols = null;

                if (section != null)
                {
                    if (!String.IsNullOrWhiteSpace(section[nameof(MinimumLength)]))
                    {
                        minimumLength = Convert.ToInt32(section[nameof(MinimumLength)]);
                    }

                    if (!String.IsNullOrWhiteSpace(section[nameof(MinimumLetters)]))
                    {
                        minimumLetters = Convert.ToInt32(section[nameof(MinimumLetters)]);
                    }

                    if (!String.IsNullOrWhiteSpace(section[nameof(MinimumDigits)]))
                    {
                        minimumDigits = Convert.ToInt32(section[nameof(MinimumDigits)]);
                    }

                    if (!String.IsNullOrWhiteSpace(section[nameof(MinimumUpperCase)]))
                    {
                        minimumUpperCase = Convert.ToInt32(section[nameof(MinimumUpperCase)]);
                    }

                    if (!String.IsNullOrWhiteSpace(section[nameof(MinimumLowerCase)]))
                    {
                        minimumLowerCase = Convert.ToInt32(section[nameof(MinimumLowerCase)]);
                    }

                    if (!String.IsNullOrWhiteSpace(section[nameof(MinimumSymbols)]))
                    {
                        minimumSymbols = Convert.ToInt32(section[nameof(MinimumSymbols)]);
                    }
                }

                return new WhippetPasswordComplexityOptions(minimumLength, minimumLetters, minimumDigits, minimumUpperCase, minimumLowerCase, minimumSymbols);
            }
        }
    }
}