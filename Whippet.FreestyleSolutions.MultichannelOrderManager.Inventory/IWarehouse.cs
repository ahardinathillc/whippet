using System;
using NodaTime;
using Athi.Whippet.Collections.Comparers;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory
{
    /// <summary>
    /// Represents a warehouse in the Multichannel Order Manager application.
    /// </summary>
    public interface IWarehouse : IMultichannelOrderManagerAuditableEntity, IMultichannelOrderManagerEntity, IWhippetEntity, IEqualityComparer<IWarehouse>
    {
        /// <summary>
        /// Gets or sets the warehouse code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the warehouse description.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the warehouse address.
        /// </summary>
        MultichannelOrderManagerObjectAddress Address
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for UPS Canada.
        /// </summary>
        string UPS_Canada_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for UPS.
        /// </summary>
        string UPS_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for FedEx.
        /// </summary>
        string FedEx_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for USPS.
        /// </summary>
        string USPS_ID
        { get; set; }

        /// <summary>
        /// Indicates if the warehouse is a retail location.
        /// </summary>
        bool IsRetail
        { get; set; }

        /// <summary>
        /// For use by M.O.M. internally.
        /// </summary>
        long CustomerNumber
        { get; set; }

        /// <summary>
        /// Message line one to print on receipts.
        /// </summary>
        string MessageOne
        { get; set; }

        /// <summary>
        /// Message line two to print on receipts.
        /// </summary>
        string MessageTwo
        { get; set; }

        /// <summary>
        /// For use by M.O.M. internally.
        /// </summary>
        string AddressID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool IsPickup
        { get; set; }
    }
}
