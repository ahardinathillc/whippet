using System;
using Newtonsoft.Json;
using NodaTime;
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
        
        /// <summary>
        /// Gets or sets the date and time the entity was created. This property may or may not be used by the backing entity.
        /// </summary>
        Instant CreatedDTTM
        { get; set; }
    }
}
