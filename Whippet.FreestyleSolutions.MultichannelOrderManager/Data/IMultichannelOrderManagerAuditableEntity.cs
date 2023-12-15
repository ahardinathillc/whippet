using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Represents a domain object in Freestyle Solutions Multichannel Order Manager.
    /// </summary>
    public interface IMultichannelOrderManagerAuditableEntity : IMultichannelOrderManagerEntity, IWhippetEntity
    {
        /// <summary>
        /// Gets or sets the date and time the entity was last accessed.
        /// </summary>
        Instant? LastAccessed
        { get; set; }
        
        /// <summary>
        /// Gets or sets the three character username who accessed the entity.
        /// </summary>
        string LastAccessedBy
        { get; set; }
    }
}
