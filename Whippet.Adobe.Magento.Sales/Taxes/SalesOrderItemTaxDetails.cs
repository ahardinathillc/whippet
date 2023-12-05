using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Catalog.Products;

namespace Athi.Whippet.Adobe.Magento.Sales.Taxes
{
    /// <summary>
    /// Lists all taxes and their respective rates for a sales order item in Magento.
    /// </summary>
    public struct SalesOrderItemTaxDetails : IExtensionInterfaceMap<SalesOrderItemTaxDetailsInterface>
    {
        /// <summary>
        /// Gets or sets the entity type the tax is applied to.
        /// </summary>
        public string Type
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item if the entity is a product.
        /// </summary>
        public IProduct Item
        { get; set; }

        /// <summary>
        /// Gets or sets the linked item if the entity is a product.
        /// </summary>
        public IProduct AssociatedItem
        { get; set; }

        /// <summary>
        /// Gets or sets the applied taxes.
        /// </summary>
        public IEnumerable<SalesOrderAppliedTax> AppliedTaxes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemTaxDetails"/> struct with no arguments.
        /// </summary>
        static SalesOrderItemTaxDetails()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemTaxDetails"/> struct with no arguments.
        /// </summary>
        public SalesOrderItemTaxDetails()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemTaxDetails"/> struct with the specified parameters.
        /// </summary>
        /// <param name="type">Type of entity the tax is applied to.</param>
        /// <param name="item">If the entity is a product, gets or sets the item the taxes are applied to.</param>
        /// <param name="associatedItem">If the entity is a product, gets or sets the linked item the taxes are applied to.</param>
        /// <param name="appliedTaxes">Gets or sets the applied taxes.</param>
        public SalesOrderItemTaxDetails(string type, IProduct item, IProduct associatedItem, IEnumerable<SalesOrderAppliedTax> appliedTaxes)
            : this()
        {
            Type = type;
            Item = item;
            AssociatedItem = associatedItem;
            AppliedTaxes = appliedTaxes;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemTaxDetails"/> struct with the specified <see cref="SalesOrderItemTaxDetailsInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderItemTaxDetailsInterface"/> object.</param>
        public SalesOrderItemTaxDetails(SalesOrderItemTaxDetailsInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderItemTaxDetailsInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderItemTaxDetailsInterface"/>.</returns>
        public SalesOrderItemTaxDetailsInterface ToInterface()
        {
            SalesOrderItemTaxDetailsInterface taxInterface = new SalesOrderItemTaxDetailsInterface();

            taxInterface.Type = Type;
            taxInterface.ItemID = (Item == null) ? default(int) : Item.ID;
            taxInterface.AssociatedItemID = (AssociatedItem == null) ? default(int) : AssociatedItem.ID;
            taxInterface.AppliedTaxes = (AppliedTaxes == null) ? null : AppliedTaxes.Select(at => at.ToInterface()).ToArray();
            taxInterface.ExtensionAttributes = new SalesOrderItemTaxDetailsExtensionInterface();
            
            return taxInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderItemTaxDetailsInterface"/> object used to populate the object.</param>
        public void FromModel(SalesOrderItemTaxDetailsInterface model)
        {
            if (model != null)
            {
                Type = model.Type;
                Item = (model.ItemID < 1) ? null : new Product(Convert.ToUInt32(model.ItemID));
                AssociatedItem = (model.AssociatedItemID < 1) ? null : new Product(Convert.ToUInt32(model.AssociatedItemID));
                AppliedTaxes = (model.AppliedTaxes == null) ? null : model.AppliedTaxes.Select(at => new SalesOrderAppliedTax(at));
            }
        }
    }
}
