using System;
using NodaTime;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a database entity within the Freestyle Multichannel Order Manager (M.O.M.) database.
    /// </summary>
    public interface IMultichannelOrderManagerEntity : IWhippetEntity
    {
        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerServer"/> object that the <see cref="IMultichannelOrderManagerEntity"/> is registered with.
        /// </summary>
        IMultichannelOrderManagerServer Server
        { get; set; }
    }
}
