using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Athi.Whippet.Json.Newtonsoft;
//using Athi.Whippet.Collections.Extensions;

namespace Athi.Whippet.Json
{
    /// <summary>
    /// Provides a default JSON writer tailored for Newtonsoft's JSON library. This class cannot be inherited.
    /// </summary>
    public sealed class DefaultWhippetJsonObjectWriter
    {
        private static DefaultWhippetJsonObjectWriter _writer;

        /// <summary>
        /// Gets a singleton instance of the <see cref="DefaultWhippetJsonObjectWriter"/> class. This property is read-only.
        /// </summary>
        public static DefaultWhippetJsonObjectWriter Instance
        {
            get
            {
                if (_writer == null)
                {
                    _writer = new DefaultWhippetJsonObjectWriter();
                }

                return _writer;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWhippetJsonObjectWriter"/> class with no arguments.
        /// </summary>
        private DefaultWhippetJsonObjectWriter()
        { }

        /// <summary>
        /// Returns a JSON string representing the current object.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <param name="toSerialize">Instance of type <typeparamref name="T"/> to serialize.</param>
        /// <returns>JSON string.</returns>
        public string ToJson<T>(T toSerialize, Type type = null, Formatting formatting = Formatting.Indented, JsonSerializerSettings settings = null) where T : IJsonSerializableObject
        {
            string json = null;

            if (settings != null && NewtonsoftJsonConverterIndex.HasConverters)
            {
                settings.Converters.AddRange(NewtonsoftJsonConverterIndex.GetRegisteredConverters());
                json = JsonConvert.SerializeObject(toSerialize, type, formatting, settings);
            }
            else
            {
                try
                {
                    json = JsonConvert.SerializeObject(toSerialize, formatting, NewtonsoftJsonConverterIndex.GetRegisteredConverters());
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debugger.Log(0, typeof(DefaultWhippetJsonObjectWriter).FullName, e.ToString());
                    // try converting without the converters; throw if it can't be serialized correctly
                    json = JsonConvert.SerializeObject(toSerialize, formatting);
                }
            }

            return json;
        }
    }
}
