using System;
using Newtonsoft.Json;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.Data
{
    /// <summary>
    /// Represents a domain object in Super Duper legacy applications.
    /// </summary>
    public interface ISuperDuperLegacyEntity : IWhippetEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        [JsonRequired]
        new int ID
        { get; set; }
    }
}
