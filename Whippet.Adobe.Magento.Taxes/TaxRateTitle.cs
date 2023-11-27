using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using MagentoStore = Athi.Whippet.Adobe.Magento.Store.Store;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rate title in Magento.
    /// </summary>
    public class TaxRateTitle : MagentoRestEntity<TaxRateTitleInterface>, IMagentoEntity, ITaxRateTitle, IEqualityComparer<ITaxRateTitle>, IMagentoRestEntity<TaxRateTitleInterface>
    {
        private MagentoStore _store;

        /// <summary>
        /// Gets or sets the <see cref="MagentoStore"/> that the title applies to.
        /// </summary>
        public virtual MagentoStore Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new MagentoStore();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the title applies to.
        /// </summary>
        IStore ITaxRateTitle.Store
        {
            get
            {
                return Store;
            }
            set
            {
                Store = value.ToStore();
            }
        }
        
        /// <summary>
        /// Gets or sets the title value.
        /// </summary>
        public virtual string Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitle"/> class with no arguments.
        /// </summary>
        public TaxRateTitle()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitle"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxRateTitle(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitle"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxRateTitle(TaxRateTitleInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ITaxRateTitle)) ? false : Equals((ITaxRateTitle)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRateTitle obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRateTitle x, ITaxRateTitle y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Store == null) && (y.Store == null)) || ((x.Store != null) && x.Store.Equals(y.Store)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="TaxRateTitleInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="TaxRateTitleInterface"/>.</returns>
        public override TaxRateTitleInterface ToInterface()
        {
            TaxRateTitleInterface taxInterface = new TaxRateTitleInterface();
            taxInterface.StoreID = Convert.ToString(Store.ID);
            taxInterface.Value = Value;
            
            return taxInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            TaxRateTitle title = new TaxRateTitle();

            title.ID = ID;
            title.Store = Store.Clone<MagentoStore>();
            title.Value = Value;
            title.Server = Server.Clone<MagentoServer>();
            title.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();

            return title;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Store);
            hash.Add(Value);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(TaxRateTitleInterface model)
        {
            if (model != null)
            {
                Store = new MagentoStore() { ID = Convert.ToInt32(model.StoreID) };
                Value = model.Value;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="title"><see cref="ITaxRateTitle"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxRateTitle title)
        {
            ArgumentNullException.ThrowIfNull(title);
            return title.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Value) ? base.ToString() : Value;
        }
    }
}
