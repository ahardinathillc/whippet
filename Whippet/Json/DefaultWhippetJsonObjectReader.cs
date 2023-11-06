using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Collections.Extensions;

namespace Athi.Whippet.Json
{
    /// <summary>
    /// Provides a default JSON writer tailored for Newtonsoft's JSON library. This class cannot be inherited.
    /// </summary>
    public sealed class DefaultWhippetJsonObjectReader
    {
        private static DefaultWhippetJsonObjectReader _writer;

        /// <summary>
        /// Gets a singleton instance of the <see cref="DefaultWhippetJsonObjectReader"/> class. This property is read-only.
        /// </summary>
        public static DefaultWhippetJsonObjectReader Instance
        {
            get
            {
                if (_writer == null)
                {
                    _writer = new DefaultWhippetJsonObjectReader();
                }

                return _writer;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWhippetJsonObjectReader"/> class with no arguments.
        /// </summary>
        private DefaultWhippetJsonObjectReader()
        { }

        /// <summary>
        /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="json">JSON input string.</param>
        /// <param name="settings"><see cref="JsonSerializerSettings"/> to use. If <see langword="null"/>, default settings will be used.</param>
        /// <returns>Object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public T Deserialize<T>(string json, JsonSerializerSettings settings = null)
        {
            T obj;

            if (settings != null && NewtonsoftJsonConverterIndex.HasConverters)
            {
                settings.Converters.AddRange(NewtonsoftJsonConverterIndex.GetRegisteredConverters());
                obj = JsonConvert.DeserializeObject<T>(json, settings);
            }
            else
            {
                obj = JsonConvert.DeserializeObject<T>(json, NewtonsoftJsonConverterIndex.GetRegisteredConverters());
            }

            return obj;
        }
    }
}

