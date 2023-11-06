using System;

namespace Athi.Whippet.Json
{
    /// <summary>
    /// Allows for the emitting of JSON that represents the current object.
    /// </summary>
    public interface IJsonObject : IJsonSerializableObject
    {
        /// <summary>
        /// Returns a JSON string representing the current object.
        /// </summary>
        /// <typeparam name="T"><see cref="IJsonSerializableObject"/> object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        string ToJson<T>() where T : IJsonSerializableObject;
    }
}

