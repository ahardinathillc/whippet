using System;
using Newtonsoft.Json;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Represents a domain object in Freestyle Solutions Multichannel Order Manager.
    /// </summary>
    public interface IMultichannelOrderManagerEntity: IWhippetEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        [JsonRequired]
        new IMultichannelOrderManagerEntityKey ID
        { get; set; }
    }
}
