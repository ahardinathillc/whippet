using System;
using System.Globalization;
using System.Text;
using Athi.Whippet.Data;
using Newtonsoft.Json;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Base class for all domain objects in Freestyle Solutions Multichannel Order Manager. This class must be inherited.
    /// </summary>
    public abstract class MultichannelOrderManagerEntity : WhippetEntity, IWhippetEntity, IMultichannelOrderManagerEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        [JsonRequired]
        public new virtual IMultichannelOrderManagerEntityKey ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntity"/> class with no arguments.
        /// </summary>
        protected MultichannelOrderManagerEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique identifier of the entity.</param>
        protected MultichannelOrderManagerEntity(IMultichannelOrderManagerEntityKey id)
            : base()
        {
            ID = id;
        }
    }
}
