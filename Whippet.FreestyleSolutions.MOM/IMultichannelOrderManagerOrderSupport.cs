using System;
namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Provides support to Multichannel Order Manager entities that reference an order number.
    /// </summary>
    public interface IMultichannelOrderManagerOrderSupport : IMultichannelOrderManagerEntity
    {
        /// <summary>
        /// Gets or sets the order number of the entity.
        /// </summary>
        long OrderNumber
        { get; set; }
    }
}
