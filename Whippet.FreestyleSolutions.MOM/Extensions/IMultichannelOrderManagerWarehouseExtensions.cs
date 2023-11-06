using System;
using Athi.Whippet.Data;
using System.Data;
using System.Reflection;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerWarehouse"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerWarehouseExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerWarehouse"/> object to a <see cref="MultichannelOrderManagerWarehouse"/> object.
        /// </summary>
        /// <param name="warehouse"><see cref="IMultichannelOrderManagerWarehouse"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerWarehouse ToMultichannelOrderManagerWarehouse(this IMultichannelOrderManagerWarehouse warehouse)
        {
            MultichannelOrderManagerWarehouse mom = null;

            if (warehouse != null)
            {
                if (warehouse is MultichannelOrderManagerWarehouse)
                {
                    mom = (MultichannelOrderManagerWarehouse)(warehouse);
                }
                else
                {
                    mom = new MultichannelOrderManagerWarehouse();
                    mom.AddressID = warehouse.AddressID;
                    mom.AddressLineOne = warehouse.AddressLineOne;
                    mom.AddressLineTwo = warehouse.AddressLineTwo;
                    mom.City = warehouse.City;
                    mom.Code = warehouse.Code;
                    mom.Country = warehouse.Country;
                    mom.CustomerNumber = warehouse.CustomerNumber;
                    mom.Description = warehouse.Description;
                    mom.FedEx_ID = warehouse.FedEx_ID;
                    mom.ID = warehouse.ID;
                    mom.IsPickup = warehouse.IsPickup;
                    mom.IsRetail = warehouse.IsRetail;
                    mom.LookupBy = warehouse.LookupBy;
                    mom.LookupOn = warehouse.LookupOn;
                    mom.MessageOne = warehouse.MessageOne;
                    mom.MessageTwo = warehouse.MessageTwo;
                    mom.Server = warehouse.Server.ToMultichannelOrderManagerServer();
                    mom.State = warehouse.State;
                    mom.UPS_Canada_ID = warehouse.UPS_Canada_ID;
                    mom.UPS_ID = warehouse.UPS_ID;
                    mom.USPS_ID = warehouse.USPS_ID;
                    mom.WarehouseID = warehouse.WarehouseID;
                    mom.ZipCode = warehouse.ZipCode;
                }
            }

            return mom;
        }

    }
}

