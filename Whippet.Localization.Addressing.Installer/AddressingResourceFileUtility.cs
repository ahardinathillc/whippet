using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Athi.Whippet.Localization.Addressing.Installer.ResourceFiles;

namespace Athi.Whippet.Localization.Addressing.Installer
{
    /// <summary>
    /// Provides I/O support for resource files in the addressing installer. This class cannot be inherited.
    /// </summary>
    internal static class AddressingResourceFileUtility
    {
        private static IReadOnlyDictionary<ICountry, string> _prefixes;
        private static IReadOnlyDictionary<ICountry, string> _directories;
        private static IReadOnlyDictionary<ICountry, string> _stateProvinces;

        /// <summary>
        /// Gets a read-only index of <see cref="ICountry"/> objects with their respective file prefixes stored in the ResourceFiles directory. This property is read-only.
        /// </summary>
        private static IReadOnlyDictionary<ICountry, string> CountryFilePrefixes
        {
            get
            {
                if (_prefixes == null)
                {
                    _prefixes = GetCountryFilePrefixes();
                }

                return _prefixes;
            }
        }

        /// <summary>
        /// Gets a read-only index of <see cref="ICountry"/> objets with their respective resource file directory names stored in the ResourcesFiles directory. This property is read-only.
        /// </summary>
        private static IReadOnlyDictionary<ICountry, string> CountryResourceFileDirectory
        {
            get
            {
                if (_directories == null)
                {
                    _directories = GetCountryResourceFileDirectories();
                }

                return _directories;
            }
        }

        /// <summary>
        /// Gets a read-only index of <see cref="ICountry"/> objects with their respective state/province resource files. This property is read-only.
        /// </summary>
        private static IReadOnlyDictionary<ICountry, string> CountryStateProvinceResourceFiles
        {
            get
            {
                if (_stateProvinces == null)
                {
                    _stateProvinces = GetCountryStateProvincesFiles();
                }

                return _stateProvinces;
            }
        }

        /// <summary>
        /// Gets the state/province resource file for the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to load the resource file for.</param>
        /// <returns>Resource file name or <see langword="null"/> if no resource file exists.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetCountryStateProvinceResourceFile(ICountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                IEnumerable<string> files = GetCountryResourceFiles(country);
                ICountry rfCountry = null;
                ICountry pfCountry = null;

                string resourceFile = null;

                if (files != null && files.Any())
                {
                    // search for the file
                    rfCountry = (from key in CountryStateProvinceResourceFiles.Keys where key.ID.Equals(country.ID) || String.Equals(key.Name, country.Name, StringComparison.InvariantCultureIgnoreCase) select key).FirstOrDefault();
                    pfCountry = (from key in CountryFilePrefixes.Keys where key.ID.Equals(country.ID) || String.Equals(key.Name, country.Name, StringComparison.InvariantCultureIgnoreCase) select key).FirstOrDefault();

                    if (rfCountry != null && pfCountry != null)
                    {
                        resourceFile = (from file in files where Path.GetFileName(file).Equals(CountryFilePrefixes[pfCountry] + CountryStateProvinceResourceFiles[rfCountry], StringComparison.InvariantCultureIgnoreCase) select file).FirstOrDefault();
                    }
                }

                return resourceFile;
            }
        }

        /// <summary>
        /// Gets all resource files for the specified <see cref="ICountry"/> object.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to get resource files for.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of resource files that can be loaded.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<string> GetCountryResourceFiles(ICountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                IEnumerable<string> fileNames = null;
                string filePath = null;
                bool loadedFiles = false;

                foreach (KeyValuePair<ICountry, string> directoryEntry in CountryResourceFileDirectory)
                {
                    // first check to see if an entry exists for the resource file directory

                    if (directoryEntry.Key.ID.Equals(country.ID) || String.Equals(directoryEntry.Key.Name, country.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // now check to see if there are any file prefixes -- this is to prevent file collisions in the event we need to copy them to a different directory

                        foreach (KeyValuePair<ICountry, string> kvp in CountryFilePrefixes)
                        {
                            if (kvp.Key.ID.Equals(country.ID) || String.Equals(kvp.Key.Name, country.Name, StringComparison.InvariantCultureIgnoreCase))
                            {
                                filePath = Path.Combine(Path.GetDirectoryName(typeof(AddressingResourceFileUtility).Assembly.Location), ResourceIndex.ResourceFilesDirectory, directoryEntry.Value);
                                fileNames = Directory.GetFiles(filePath, kvp.Value + "*");
                                loadedFiles = true;
                                break;
                            }
                        }
                    }

                    if (loadedFiles)
                    {
                        break;
                    }
                }

                return fileNames;
            }
        }

        /// <summary>
        /// Generates the available index of <see cref="ICountry"/> objects and their associated file prefixes.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        private static IReadOnlyDictionary<ICountry, string> GetCountryFilePrefixes()
        {
            Dictionary<ICountry, string> prefixes = new Dictionary<ICountry, string>();

            // these must match what's in the seed data!!!

            prefixes.Add(new Country(new Guid("84F5C84D-6029-4E46-8B86-935AC3B9F52E"), "United States of America", "us"), "us");
            prefixes.Add(new Country(new Guid("EC8418CB-C061-4E35-A9E1-BFB51E29221D"), "Canada", "ca"), "ca");

            return prefixes;
        }

        /// <summary>
        /// Generates the available index of <see cref="ICountry"/> objects and their associated resource directories.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        private static IReadOnlyDictionary<ICountry, string> GetCountryResourceFileDirectories()
        {
            Dictionary<ICountry, string> prefixes = new Dictionary<ICountry, string>();

            // these must match what's in the seed data!!!

            prefixes.Add(new Country(new Guid("84F5C84D-6029-4E46-8B86-935AC3B9F52E"), "United States of America", "us"), "UnitedStates");
            prefixes.Add(new Country(new Guid("EC8418CB-C061-4E35-A9E1-BFB51E29221D"), "Canada", "ca"), "Canada");

            return prefixes;
        }

        /// <summary>
        /// Generates the available state/province resource files for each supported <see cref="ICountry"/>.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        private static IReadOnlyDictionary<ICountry, string> GetCountryStateProvincesFiles()
        {
            Dictionary<ICountry, string> prefixes = new Dictionary<ICountry, string>();

            // these must match what's in the seed data!!!

            prefixes.Add(new Country(new Guid("84F5C84D-6029-4E46-8B86-935AC3B9F52E"), "United States of America", "us"), "-stateprovinces.json");    // file will get the country prefix attached to it on loading
            prefixes.Add(new Country(new Guid("EC8418CB-C061-4E35-A9E1-BFB51E29221D"), "Canada", "ca"), "-stateprovinces.json");

            return prefixes;
        }
    }
}

