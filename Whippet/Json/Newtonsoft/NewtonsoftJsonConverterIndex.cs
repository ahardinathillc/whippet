using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Athi.Whippet.Json.Newtonsoft.Converters;

namespace Athi.Whippet.Json.Newtonsoft
{
    /// <summary>
    /// Provides a static index of <see cref="JsonConverter"/> objects that can be consumed. These are used by default by <see cref="DefaultWhippetJsonObjectReader"/> and <see cref="DefaultWhippetJsonObjectWriter"/>. This class cannot be inherited.
    /// </summary>
    public static class NewtonsoftJsonConverterIndex
    {
        private static NewtonsoftJsonConverterCollection _collection;

        /// <summary>
        /// Gets the internal <see cref="NewtonsoftJsonConverterCollection"/> object. This property is read-only.
        /// </summary>
        private static NewtonsoftJsonConverterCollection Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = new NewtonsoftJsonConverterCollection();
                }

                return _collection;
            }
        }

        /// <summary>
        /// Indicates whether any converters have been registered. This property is read-only.
        /// </summary>
        public static bool HasConverters
        {
            get
            {
                return Collection.Count > 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonConverterIndex"/> class with no arguments.
        /// </summary>
        static NewtonsoftJsonConverterIndex()
        {
            Register(new InstantConverter());
            Register(new NullableInstantConverter());
        }

        /// <summary>
        /// Registers the specified <see cref="JsonConverter"/>.
        /// </summary>
        /// <param name="converter"><see cref="JsonConverter"/> to register.</param>
        /// <exception cref="ArgumentNullException" />
        public static void Register(JsonConverter converter)
        {
            Collection.Add(converter);
        }

        /// <summary>
        /// Registers the specified collection of <see cref="JsonConverter"/> objects.
        /// </summary>
        /// <param name="converters"><see cref="IEnumerable{T}"/> collection of <see cref="JsonConverter"/> objects.</param>
        /// <exception cref="ArgumentNullException" />
        public static void Register(IEnumerable<JsonConverter> converters)
        {
            Collection.AddRange(converters);
        }

        /// <summary>
        /// Removes the specified <see cref="JsonConverter"/>.
        /// </summary>
        /// <param name="converter"><see cref="JsonConverter"/> to remove.</param>
        /// <exception cref="ArgumentNullException" />
        public static void Remove(JsonConverter converter)
        {
            Collection.Remove(converter);
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonConverter"/> is registered.
        /// </summary>
        /// <param name="converter"><see cref="JsonConverter"/> object to look for.</param>
        /// <returns><see langword="true"/> if the converter is registered; otherwise, <see langword="false"/>.</returns>
        public static bool IsRegistered(JsonConverter converter)
        {
            return Collection.Contains(converter);
        }

        /// <summary>
        /// Gets all <see cref="JsonConverter"/> objects registered in the system.
        /// </summary>
        /// <returns><see cref="IReadOnlyList{T}"/> collection.</returns>
        public static JsonConverter[] GetRegisteredConverters()
        {
            return Collection.ToArray();
        }
    }
}
