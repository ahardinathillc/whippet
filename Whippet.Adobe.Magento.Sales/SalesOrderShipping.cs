using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Addressing;
using Athi.Whippet.Adobe.Magento.Sales.Addressing.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Provides shipping information for an <see cref="ISalesOrder"/>.
    /// </summary>
    public struct SalesOrderShipping : IExtensionInterfaceMap<SalesOrderShippingInterface>
    {
        private ISalesOrderAddress _address;
        
        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        public ISalesOrderAddress Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new SalesOrderAddress();
                }

                return _address;
            }
            set
            {
                _address = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        public string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the order's shipping totals.
        /// </summary>
        public SalesOrderShippingTotal Totals
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShipping"/> struct with no arguments.
        /// </summary>
        static SalesOrderShipping()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShipping"/> struct with no arguments.
        /// </summary>
        public SalesOrderShipping()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShipping"/> struct with the specified <see cref="SalesOrderShippingInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderShippingInterface"/> object.</param>
        public SalesOrderShipping(SalesOrderShippingInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShipping"/> struct with the specified parameters.
        /// </summary>
        /// <param name="address">Shipping address.</param>
        /// <param name="method">Shipping method.</param>
        /// <param name="totals">Shipping totals.</param>
        public SalesOrderShipping(ISalesOrderAddress address, string method, SalesOrderShippingTotal totals)
            : this()
        {
            Address = address;
            Method = method;
            Totals = totals;
        }
        
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderShippingInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderShippingInterface"/>.</returns>
        public SalesOrderShippingInterface ToInterface()
        {
            SalesOrderShippingInterface sInterface = new SalesOrderShippingInterface();

            sInterface.Address = Address.ToSalesOrderAddress().ToInterface();
            sInterface.Method = Method;
            sInterface.ShippingTotal = Totals.ToInterface();
            sInterface.ExtensionAttributes = new SalesOrderShippingExtensionInterface();

            return sInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderShippingInterface"/> object used to populate the object.</param>
        public void FromModel(SalesOrderShippingInterface model)
        {
            if (model != null)
            {
                Address = (model.Address == null) ? null : new SalesOrderAddress(model.Address);
                Method = model.Method;

                if (model.ShippingTotal != null)
                {
                    Totals = new SalesOrderShippingTotal(model.ShippingTotal);
                }
            }
        }
    }
}
