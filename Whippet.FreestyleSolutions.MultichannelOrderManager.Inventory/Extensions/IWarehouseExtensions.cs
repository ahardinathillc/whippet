using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWarehouse"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWarehouseExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWarehouse"/> object to a <see cref="Warehouse"/> object.
        /// </summary>
        /// <param name="warehouse"><see cref="IWarehouse"/> object.</param>
        /// <returns><see cref="Warehouse"/> object.</returns>
        public static Warehouse ToWarehouse(this IWarehouse warehouse)
        {
            Warehouse wh = null;

            if (warehouse is Warehouse)
            {
                wh = (Warehouse)(warehouse);
            }
            else if (warehouse != null)
            {
                wh = new Warehouse(new MultichannelOrderManagerEntityKey<int>(warehouse.ID.ToInt32(null)), warehouse.LastAccessed, warehouse.LastAccessedBy);
                wh.Code = warehouse.Code;
                wh.Description = warehouse.Description;
                wh.Address = warehouse.Address;
                wh.UPS_Canada_ID = warehouse.UPS_Canada_ID;
                wh.UPS_ID = warehouse.UPS_ID;
                wh.FedEx_ID = warehouse.FedEx_ID;
                wh.USPS_ID = warehouse.USPS_ID;
                wh.IsRetail = warehouse.IsRetail;
                wh.CustomerNumber = warehouse.CustomerNumber;
                wh.MessageOne = warehouse.MessageOne;
                wh.MessageTwo = warehouse.MessageTwo;
                wh.AddressID = warehouse.AddressID;
                wh.IsPickup = warehouse.IsPickup;
            }

            return wh;
        }
    }
}
