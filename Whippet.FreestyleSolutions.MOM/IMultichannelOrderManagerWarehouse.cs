using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Reflection;
using NodaTime;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a warehouse in the Multichannel Order Management (M.O.M.) system.
    /// </summary>
    public interface IMultichannelOrderManagerWarehouse : IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerWarehouse>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerLookup, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IComparable<IMultichannelOrderManagerWarehouse>
    {
        /// <summary>
        /// Unique record identifier of the warehouse.
        /// </summary>
        new long ID
        { get; set; }

        /// <summary>
        /// Unique record identifier of the warehouse.
        /// </summary>
        long WarehouseID
        { get; set; }

        /// <summary>
        /// Warehouse code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string Code
        { get; set; }

        /// <summary>
        /// Warehouse description.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string Description
        { get; set; }

        /// <summary>
        /// First address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string AddressLineOne
        { get; set; }

        /// <summary>
        /// Second address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string AddressLineTwo
        { get; set; }

        /// <summary>
        /// Warehouse city.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string City
        { get; set; }

        /// <summary>
        /// Warehouse state.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string State
        { get; set; }

        /// <summary>
        /// Warehouse ZIP code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string ZipCode
        { get; set; }

        /// <summary>
        /// Country code of the warehouse.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Country
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for UPS Canada.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string UPS_Canada_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for UPS.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string UPS_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for FedEx.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string FedEx_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for USPS.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string MessageOne
        { get; set; }

        /// <summary>
        /// Message line two to print on receipts.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string MessageTwo
        { get; set; }

        /// <summary>
        /// For use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AddressID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool IsPickup
        { get; set; }
    }
}

