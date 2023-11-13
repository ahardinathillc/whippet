using System;
namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Provides support to <see cref="IMultichannelOrderManagerEntity"/> objects that reference a purchase order.
    /// </summary>
    public interface IMultichannelOrderManagerPurchaseOrderSupport : IMultichannelOrderManagerEntity
    {
        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        long PurchaseOrder
        { get; set; }
    }
}
