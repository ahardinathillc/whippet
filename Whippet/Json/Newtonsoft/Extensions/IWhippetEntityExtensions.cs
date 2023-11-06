using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Json.Newtonsoft.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetEntity"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetEntityExtensions
    {
        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <param name="toSerialize">Object instance to serialize.</param>
        /// <returns>JSON string.</returns>
        public static string SerializeJson<T>(this IWhippetEntity entity, T toSerialize) where T : IJsonSerializableObject
        {
            return DefaultWhippetJsonObjectWriter.Instance.ToJson<T>(toSerialize);
        }
    }
}

