using System;
using System.Text;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Parser utility for parsing JSON responses from Magento exports. This class cannot be inherited.
    /// </summary>
    public static class MagentoJsonResponseParser
    {
        /// <summary>
        /// Creates an <see cref="IReadOnlyDictionary{TKey, TValue}"/> object consisting of key/value pairs of the contents of the specified raw JSON provided from Magento.
        /// </summary>
        /// <param name="rawJson">Raw JSON provided from Magento.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        public static IReadOnlyDictionary<string, string> CreateDictionary(string rawJson)
        {
            if (String.IsNullOrWhiteSpace(rawJson))
            {
                throw new ArgumentNullException(nameof(rawJson));
            }
            else
            {
                Dictionary<string, string> contents = null;

                string[] entries = null;

                string keyName = null;
                string keyValue = null;

                if (rawJson.StartsWith('['))
                {
                    rawJson = rawJson.Substring(1);
                }

                if (rawJson.EndsWith(']'))
                {
                    rawJson = rawJson.Substring(0, rawJson.Length - 1);
                }

                contents = new Dictionary<string, string>();

                // All key/value pairs are broken up into {[key]:[value]} pairs separated by a delimiter

                entries = rawJson.Split("},{", StringSplitOptions.RemoveEmptyEntries);

                if (entries != null)
                {
                    for (int i = 0; i < entries.Length; i++)
                    {
                        if (entries[i].StartsWith('{') && entries[i].Length > 1)
                        {
                            entries[i] = entries[i].Substring(1);
                        }

                        if (entries[i].EndsWith('}') && entries[i].Length > 1)
                        {
                            entries[i] = entries[i].Substring(0, entries[i].Length - 1);
                        }

                        keyName = entries[i].Substring(0, entries[i].IndexOf("\":\""));

                        if (keyName.StartsWith('"'))
                        {
                            keyName = keyName.Substring(1, keyName.Length - 1);
                        }

                        if (keyName.EndsWith('"'))
                        {
                            keyName = keyName.Substring(0, keyName.Length - 1);
                        }

                        keyValue = entries[i].Substring(entries[i].IndexOf("\":\"") + 2);

                        if (keyValue.StartsWith('"'))
                        {
                            keyValue = keyValue.Substring(1, keyValue.Length - 1);
                        }

                        if (keyValue.EndsWith('"'))
                        {
                            keyValue = keyValue.Substring(0, keyValue.Length - 1);
                        }

                        contents.Add(keyName, keyValue);
                    }
                }

                return contents.AsReadOnly();
            }
        }
    }
}
