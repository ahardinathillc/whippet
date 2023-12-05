using System;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.Sales;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory
{
    /// <summary>
    /// Represents a Magento stock.
    /// </summary>
    public class Stock : MagentoRestEntity<StockInterface>, IMagentoEntity, IStock, IEqualityComparer<IStock>, IMagentoRestEntity, IMagentoRestEntity<StockInterface>
    {
        /// <summary>
        /// Gets or sets the stock name.
        /// </summary>
        public virtual string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the sales channels for the stock.
        /// </summary>
        public virtual IEnumerable<SalesChannel> SalesChannels
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class with no arguments.
        /// </summary>
        public Stock()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Stock(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Stock(StockInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IStock)) ? false : Equals((IStock)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStock obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStock x, IStock y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && (((x.SalesChannels == null) && (y.SalesChannels == null)) || ((x.SalesChannels != null) && x.SalesChannels.SequenceEqual(y.SalesChannels)))
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="StockInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="StockInterface"/>.</returns>
        public override StockInterface ToInterface()
        {
            StockInterface stock = new StockInterface();

            stock.ID = ID;
            stock.Name = Name;
            stock.ExtensionAttributes = new StockExtensionInterface((SalesChannels == null) ? null : SalesChannels.Select(c => c.ToInterface()).ToArray());
            
            return stock;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Stock stock = new Stock();

            stock.Name = Name;
            stock.SalesChannels = (SalesChannels == null) ? null : SalesChannels.Select(c => c);
            stock.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();
            stock.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            
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
            hash.Add(Name);
            hash.Add(SalesChannels);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="product"><see cref="IStock"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStock product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return product.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(StockInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Name = model.Name;

                if (model.ExtensionAttributes != null && model.ExtensionAttributes.SalesChannels != null)
                {
                    SalesChannels = model.ExtensionAttributes.SalesChannels.Select(sc => new SalesChannel(sc));
                }
            }
        }
        
    }
}
