using System;
using System.Text;

namespace Athi.Whippet.Integrations.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IThirdPartyEntityMap"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IThirdPartyEntityMapExtensions
    {
        /// <summary>
        /// Creates an <see cref="object.ToString"/> value to use for <see cref="IThirdPartyEntityMap"/> objects that describe their synchronization (1:1 synchronization objects only).
        /// </summary>
        /// <param name="map"><see cref="IThirdPartyEntityMap"/> object.</param>
        /// <param name="internalEntityValue">Internal entity string value or description.</param>
        /// <param name="externalEntityValue">External entity string value or description.</param>
        /// <param name="bidirectional">If <see langword="true"/>, the synchronization is bidirectional.</param>
        /// <param name="internalEntityReadOnly">If <see langword="true"/>, the internal entity is read-only.</param>
        /// <param name="externalEntityReadOnly">If <see langword="true"/>, the external entity is read-only.</param>
        /// <param name="bidirectionalValue">Value to display if the synchronization is bidirectional.</param>
        /// <param name="internalEntityReadOnlyValue">Value to display if the internal entity is read-only.</param>
        /// <param name="externalEntityReadOnlyValue">Value to display if the external entity is read-only.</param>
        /// <param name="associationOnlyValue">Value to display if both the internal and external entities are read-only.</param>
        /// <returns>String that describes the synchronization relationship.</returns>
        public static string EntitySynchronizationToString(this IThirdPartyEntityMap map, string internalEntityValue, string externalEntityValue, bool bidirectional, bool internalEntityReadOnly, bool externalEntityReadOnly, string bidirectionalValue = "Bidirectional", string internalEntityReadOnlyValue = "Internal Entity Read Only", string externalEntityReadOnlyValue = "External Entity Read Only", string associationOnlyValue = "Association Only")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append('[');
            builder.Append(internalEntityValue);
            builder.Append('|');
            builder.Append(externalEntityValue);
            builder.Append('|');

            if (bidirectional)
            {
                builder.Append(bidirectionalValue);
            }
            else if (internalEntityReadOnly)
            {
                builder.Append(internalEntityReadOnlyValue);
            }
            else if (externalEntityReadOnly)
            {
                builder.Append(externalEntityReadOnlyValue);
            }
            else
            {
                builder.Append(associationOnlyValue);
            }

            return builder.ToString();
        }
    }
}

