using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Provides shipping information for an <see cref="ISalesOrder"/>.
    /// </summary>
    public struct SalesOrderShippingAssignment : IExtensionInterfaceMap<SalesOrderShippingAssignmentInterface>
    {
        /// <summary>
        /// Gets or sets the shipping information.
        /// </summary>
        public SalesOrderShipping ShippingInformation
        { get; set; }
        
        /// <summary>
        /// Gets or sets the items to ship.
        /// </summary>
        public IEnumerable<ISalesOrderItem> Items
        { get; set; }
        
        /// <summary>
        /// Gets or sets the stock from which the inventory is drawn. 
        /// </summary>
        public IStock Stock
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with no arguments.
        /// </summary>
        static SalesOrderShippingAssignment()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with no arguments.
        /// </summary>
        public SalesOrderShippingAssignment()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with the specified <see cref="SalesOrderShippingAssignmentInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderShippingAssignmentInterface"/> object.</param>
        public SalesOrderShippingAssignment(SalesOrderShippingAssignmentInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with the specified parameters.
        /// </summary>
        /// <param name="shippingInformation">Shipping information.</param>
        /// <param name="items">Items associated with the sales order.</param>
        /// <param name="stock">Stock location from which to draw the inventory.</param>
        public SalesOrderShippingAssignment(SalesOrderShipping shippingInformation, IEnumerable<ISalesOrderItem> items, IStock stock)
            : this()
        {
            ShippingInformation = shippingInformation;
            Items = items;
            Stock = stock;
        }
        
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderShippingAssignmentInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderShippingAssignmentInterface"/>.</returns>
        public SalesOrderShippingAssignmentInterface ToInterface()
        {
            SalesOrderShippingAssignmentInterface sInterface = new SalesOrderShippingAssignmentInterface();

            sInterface.StockID = (Stock == null) ? default(int) : Stock.ID;
            sInterface.Items = (Items == null) ? null : Items.Select(i => i.ToSalesOrderItem().ToInterface()).ToArray();
            sInterface.ExtensionAttributes = new SalesOrderShippingAssignmentExtensionInterface();
            sInterface.Shipping = ShippingInformation.ToInterface();
            
            return sInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderShippingAssignmentInterface"/> object used to populate the object.</param>
        public void FromModel(SalesOrderShippingAssignmentInterface model)
        {
            if (model != null)
            {
                Stock = new Stock(Convert.ToUInt32(model.StockID));
                Items = (model.Items == null) ? null : model.Items.Select(i => new SalesOrderItem(i));
                ShippingInformation = new SalesOrderShipping(model.Shipping);
            }
        }
    }
}
