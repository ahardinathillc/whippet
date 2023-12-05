using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems
{
    /// <summary>
    /// Represents an inventory stock unit of a Magento product.
    /// </summary>
    public class StockItem : MagentoRestEntity<StockItemInterface>, IMagentoEntity, IStockItem, IEqualityComparer<IStockItem>, IMagentoRestEntity<StockItemInterface>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        public virtual int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public virtual int ProductID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the stock item.
        /// </summary>
        public virtual decimal Quantity
        { get; set; }

        /// <summary>
        /// Specifies whether the stock item is available.
        /// </summary>
        public virtual bool InStock
        { get; set; }

        /// <summary>
        /// Specifies whether <see cref="Quantity"/> is a <see cref="Decimal"/> value or an <see cref="Int32"/> value.
        /// </summary>
        public virtual bool IsQuantityDecimal
        { get; set; }

        /// <summary>
        /// Specifies whether notification messages should be dispatched when the quantity reaches a certain level. 
        /// </summary>
        public virtual bool ShowDefaultNotificationMessage
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's minimum quantity value should be used for determining whether the item is in stock.
        /// </summary>
        public virtual bool UseConfigurationMinimumQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity available for item status in stock.
        /// </summary>
        public virtual decimal MinimumQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether to use the configuration's minimum sale quantity value.
        /// </summary>
        public virtual bool UseConfigurationMinimumSaleQuantity
        { get; set; }
        
        /// <summary>
        /// Specifies the minimal quantity allowed in the shopping cart or <see langword="null"/> if there is no limitation.
        /// </summary>
        public virtual decimal? MinimumSaleQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether to use the configuration's maximum sale quantity value.
        /// </summary>
        public virtual bool UseConfigurationMaximumSaleQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity allowed in a Magento shopping cart or <see langword="null"/> if there is no limit.
        /// </summary>
        public virtual decimal? MaximumSaleQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's backorder status level should be used for determining when a stock item is on backorder.
        /// </summary>
        public virtual bool UseConfigurationBackorder
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of the current stock item that is on backorder.
        /// </summary>
        public virtual int Backorders
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's minimum quantity level notification should be used to notify when a stock item's on-hand quantity is below a particular threshold.
        /// </summary>
        public virtual bool UseConfigurationNotifyStockBelowQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the stock item on-hand quantity level that is the minimum threshold for availability before notifying Magento users.
        /// </summary>
        public virtual decimal NotifyStockBelowQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's quantity increments value should be used.
        /// </summary>
        public virtual bool UseConfigurationQuantityIncrements
        { get; set; }

        /// <summary>
        /// Gets or sets the value to increment the <see cref="Quantity"/> by when new stock is added.
        /// </summary>
        public virtual decimal QuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration should control whether quantity increments are enabled.
        /// </summary>
        public virtual bool UseConfigurationEnableQuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether quantity increments are enabled.
        /// </summary>
        public virtual bool EnableQuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration should manage stock.
        /// </summary>
        public virtual bool UseConfigurationManageStock
        { get; set; }

        /// <summary>
        /// Specifies whether stock can be managed.
        /// </summary>
        public virtual bool ManageStock
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the stock was at a low level.
        /// </summary>
        public virtual Instant? LowStockDate
        { get; set; }

        /// <summary>
        /// Specifies whether the quantity is in fractional units or whole units.
        /// </summary>
        public virtual bool IsDecimalDivided
        { get; set; }

        /// <summary>
        /// Specifies whether the stock status is automatically updated based on quantity values.
        /// </summary>
        public virtual bool AutoStockStatusChanged
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockItem"/> class with no arguments.
        /// </summary>
        public StockItem()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StockItem"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StockItem(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockItem"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StockItem(StockItemInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IStockItem)) ? false : Equals((IStockItem)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStockItem obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStockItem x, IStockItem y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.ItemID == y.ItemID
                    && x.ProductID == y.ProductID
                    && x.ID == y.ID
                    && x.Quantity == y.Quantity
                    && x.InStock == y.InStock
                    && x.IsQuantityDecimal == y.IsQuantityDecimal
                    && x.ShowDefaultNotificationMessage == y.ShowDefaultNotificationMessage
                    && x.UseConfigurationMinimumQuantity == y.UseConfigurationMinimumQuantity
                    && x.MinimumQuantity == y.MinimumQuantity
                    && x.UseConfigurationMinimumSaleQuantity == y.UseConfigurationMinimumSaleQuantity
                    && x.MinimumSaleQuantity.GetValueOrDefault() == y.MinimumSaleQuantity.GetValueOrDefault()
                    && x.UseConfigurationMaximumSaleQuantity == y.UseConfigurationMaximumSaleQuantity
                    && x.MaximumSaleQuantity.GetValueOrDefault() == y.MaximumSaleQuantity.GetValueOrDefault()
                    && x.UseConfigurationBackorder == y.UseConfigurationBackorder
                    && x.Backorders == y.Backorders
                    && x.UseConfigurationNotifyStockBelowQuantity == y.UseConfigurationNotifyStockBelowQuantity
                    && x.NotifyStockBelowQuantity == y.NotifyStockBelowQuantity
                    && x.UseConfigurationQuantityIncrements == y.UseConfigurationQuantityIncrements
                    && x.QuantityIncrement == y.QuantityIncrement
                    && x.UseConfigurationEnableQuantityIncrement == y.UseConfigurationEnableQuantityIncrement
                    && x.EnableQuantityIncrement == y.EnableQuantityIncrement
                    && x.UseConfigurationManageStock == y.UseConfigurationManageStock
                    && x.ManageStock == y.ManageStock
                    && x.LowStockDate == y.LowStockDate
                    && x.IsDecimalDivided == y.IsDecimalDivided
                    && x.AutoStockStatusChanged == y.AutoStockStatusChanged
                    && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                    && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="StockItemInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="StockItemInterface"/>.</returns>
        public override StockItemInterface ToInterface()
        {
            StockItemInterface stockInterface = new StockItemInterface();
            stockInterface.ExtensionAttributes = new StockItemExtensionInterface();
            stockInterface.ItemID = ItemID;
            stockInterface.ProductID = ProductID;
            stockInterface.StockID = ID;
            stockInterface.Quantity = Quantity;
            stockInterface.InStock = InStock;
            stockInterface.IsQuantityDecimal = IsQuantityDecimal;
            stockInterface.ShowDefaultNotificationMessage = ShowDefaultNotificationMessage;
            stockInterface.UseConfigurationMinimumQuantity = UseConfigurationMinimumQuantity;
            stockInterface.MinimumQuantity = MinimumQuantity;
            stockInterface.UseConfigurationMinimumSaleQuantity = UseConfigurationMinimumSaleQuantity.ToMagentoBoolean();
            stockInterface.MinimumSaleQuantity = MinimumSaleQuantity;
            stockInterface.UseConfigurationMaximumSaleQuantity = UseConfigurationMaximumSaleQuantity;
            stockInterface.MaximumSaleQuantity = MaximumSaleQuantity;
            stockInterface.UseConfigurationBackorder = UseConfigurationBackorder;
            stockInterface.Backorders = Backorders;
            stockInterface.UseConfigurationNotifyStockBelowQuantity = UseConfigurationNotifyStockBelowQuantity;
            stockInterface.NotifyStockBelowQuantity = NotifyStockBelowQuantity;
            stockInterface.UseConfigurationQuantityIncrements = UseConfigurationQuantityIncrements;
            stockInterface.QuantityIncrement = QuantityIncrement;
            stockInterface.UseConfigurationEnableQuantityIncrement = UseConfigurationEnableQuantityIncrement;
            stockInterface.EnableQuantityIncrement = EnableQuantityIncrement;
            stockInterface.UseConfigurationManageStock = UseConfigurationManageStock;
            stockInterface.ManageStock = ManageStock;
            stockInterface.LowStockDate = LowStockDate.HasValue ? LowStockDate.Value.ToDateTimeUtc().ToString() : null;
            stockInterface.IsDecimalDivided = IsDecimalDivided;
            stockInterface.AutoStockStatusChanged = AutoStockStatusChanged.ToMagentoBoolean();
                
            return stockInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            StockItem stock = new StockItem();
            stock.ItemID = ItemID;
            stock.ProductID = ProductID;
            stock.ID = ID;
            stock.Quantity = Quantity;
            stock.InStock = InStock;
            stock.IsQuantityDecimal = IsQuantityDecimal;
            stock.ShowDefaultNotificationMessage = ShowDefaultNotificationMessage;
            stock.UseConfigurationMinimumQuantity = UseConfigurationMinimumQuantity;
            stock.MinimumQuantity = MinimumQuantity;
            stock.UseConfigurationMinimumSaleQuantity = UseConfigurationMinimumSaleQuantity;
            stock.MinimumSaleQuantity = MinimumSaleQuantity;
            stock.UseConfigurationMaximumSaleQuantity = UseConfigurationMaximumSaleQuantity;
            stock.MaximumSaleQuantity = MaximumSaleQuantity;
            stock.UseConfigurationBackorder = UseConfigurationBackorder;
            stock.Backorders = Backorders;
            stock.UseConfigurationNotifyStockBelowQuantity = UseConfigurationNotifyStockBelowQuantity;
            stock.NotifyStockBelowQuantity = NotifyStockBelowQuantity;
            stock.UseConfigurationQuantityIncrements = UseConfigurationQuantityIncrements;
            stock.QuantityIncrement = QuantityIncrement;
            stock.UseConfigurationEnableQuantityIncrement = UseConfigurationEnableQuantityIncrement;
            stock.EnableQuantityIncrement = EnableQuantityIncrement;
            stock.UseConfigurationManageStock = UseConfigurationManageStock;
            stock.ManageStock = ManageStock;
            stock.LowStockDate = LowStockDate;
            stock.IsDecimalDivided = IsDecimalDivided;
            stock.AutoStockStatusChanged = AutoStockStatusChanged;
            
            return stock;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(ItemID);
            hash.Add(ProductID);
            hash.Add(Quantity);
            hash.Add(InStock);
            hash.Add(IsQuantityDecimal);
            hash.Add(ShowDefaultNotificationMessage);
            hash.Add(UseConfigurationMinimumQuantity);
            hash.Add(MinimumQuantity);
            hash.Add(UseConfigurationMinimumSaleQuantity);
            hash.Add(MinimumSaleQuantity);
            hash.Add(UseConfigurationMaximumSaleQuantity);
            hash.Add(MaximumSaleQuantity);
            hash.Add(UseConfigurationBackorder);
            hash.Add(Backorders);
            hash.Add(UseConfigurationNotifyStockBelowQuantity);
            hash.Add(NotifyStockBelowQuantity);
            hash.Add(UseConfigurationQuantityIncrements);
            hash.Add(QuantityIncrement);
            hash.Add(UseConfigurationEnableQuantityIncrement);
            hash.Add(EnableQuantityIncrement);
            hash.Add(UseConfigurationManageStock);
            hash.Add(ManageStock);
            hash.Add(LowStockDate);
            hash.Add(IsDecimalDivided);
            hash.Add(AutoStockStatusChanged);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="attribute"><see cref="IStockItem"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStockItem attribute)
        {
            ArgumentNullException.ThrowIfNull(attribute);
            return attribute.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(StockItemInterface model)
        {
            if (model != null)
            {
                ItemID = model.ItemID;
                ProductID = model.ProductID;
                ID = model.StockID;
                Quantity = model.Quantity;
                InStock = model.InStock;
                IsQuantityDecimal = model.IsQuantityDecimal;
                ShowDefaultNotificationMessage = model.ShowDefaultNotificationMessage;
                UseConfigurationMinimumQuantity = model.UseConfigurationMinimumQuantity;
                MinimumQuantity = model.MinimumQuantity;
                UseConfigurationMinimumSaleQuantity = model.UseConfigurationMinimumSaleQuantity.FromMagentoBoolean();
                MinimumSaleQuantity = model.MinimumSaleQuantity;
                UseConfigurationMaximumSaleQuantity = model.UseConfigurationMaximumSaleQuantity;
                MaximumSaleQuantity = model.MaximumSaleQuantity;
                UseConfigurationBackorder = model.UseConfigurationBackorder;
                Backorders = model.Backorders;
                UseConfigurationNotifyStockBelowQuantity = model.UseConfigurationNotifyStockBelowQuantity;
                NotifyStockBelowQuantity = model.NotifyStockBelowQuantity;
                UseConfigurationQuantityIncrements = model.UseConfigurationQuantityIncrements;
                QuantityIncrement = model.QuantityIncrement;
                UseConfigurationEnableQuantityIncrement = model.UseConfigurationEnableQuantityIncrement;
                EnableQuantityIncrement = model.EnableQuantityIncrement;
                UseConfigurationManageStock = model.UseConfigurationManageStock;
                ManageStock = model.ManageStock;
                LowStockDate = String.IsNullOrWhiteSpace(model.LowStockDate) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.LowStockDate).ToUniversalTime(true));
                IsDecimalDivided = model.IsDecimalDivided;
                AutoStockStatusChanged = model.AutoStockStatusChanged.FromMagentoBoolean();
            }
        }
    }
}
