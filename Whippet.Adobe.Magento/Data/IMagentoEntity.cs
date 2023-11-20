using System;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents a Magento domain object in Whippet.
    /// </summary>
    public interface IMagentoEntity : IWhippetEntity, IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        new uint ID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMagentoServer"/> that the <see cref="IMagentoEntity"/> resides on.
        /// </summary>
        IMagentoServer Server
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMagentoRestEndpoint"/> that the <see cref="IMagentoEntity"/> resides on.
        /// </summary>
        IMagentoRestEndpoint RestEndpoint
        { get; set; }

        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        string ToMagentoJsonString();
    }
}
