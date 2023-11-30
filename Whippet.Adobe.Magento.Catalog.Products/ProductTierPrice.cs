using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a tier price for a <see cref="Product"/> in Magento.
    /// </summary>
    public class ProductTierPrice : MagentoRestEntity<ProductTierPriceInterface>, IMagentoEntity, IProductTierPrice, IEqualityComparer<IProductTierPrice>, IMagentoCustomAttributesEntity, IMagentoRestEntity, IMagentoRestEntity<ProductTierPriceInterface>
    {
        private CustomerGroup _customerGroup;
        private StoreWebsite _store;
        private MagentoCustomAttributeCollection _attribs;
        
        /// <summary>
        /// Gets or sets the customer group the tier price applies to.
        /// </summary>
        public virtual CustomerGroup CustomerGroup
        {
            get
            {
                if (_customerGroup == null)
                {
                    _customerGroup = new CustomerGroup();
                    _customerGroup.ID = ID;                 // customer group serves as the key
                }

                return _customerGroup;
            }
            set
            {
                _customerGroup = value;
                ID = (value != null) ? value.ID : default(int);
            }
        }

        /// <summary>
        /// Gets or sets the customer group the tier price applies to.
        /// </summary>
        ICustomerGroup IProductTierPrice.CustomerGroup
        {
            get
            {
                return CustomerGroup;
            }
            set
            {
                CustomerGroup = value.ToCustomerGroup();
            }
        }
        
        /// <summary>
        /// Gets or sets the tier quantity.
        /// </summary>
        public virtual decimal Quantity
        { get; set; }
        
        /// <summary>
        /// Gets or sets the price value.
        /// </summary>
        public virtual decimal Value
        { get; set; }

        /// <summary>
        /// Gets or sets the tier price percentage.
        /// </summary>
        public virtual decimal Percentage
        { get; set; }

        /// <summary>
        /// Gets or sets the store website that the tier price applies to.
        /// </summary>
        public virtual StoreWebsite Website
        {
            get
            {
                if (_store == null)
                {
                    _store = new StoreWebsite();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the store website that the tier price applies to.
        /// </summary>
        IStoreWebsite IProductTierPrice.Website
        {
            get
            {
                return Website;
            }
            set
            {
                Website = value.ToStoreWebsite();
            }
        }

        /// <summary>
        /// Gets the entity's <see cref="MagentoCustomAttributeCollection"/> that contains all <see cref="MagentoCustomAttribute"/> entries. This property is read-only.
        /// </summary>
        public virtual MagentoCustomAttributeCollection CustomAttributes
        {
            get
            {
                if (_attribs == null)
                {
                    _attribs = new MagentoCustomAttributeCollection();
                }

                return _attribs;
            }
            protected internal set
            {
                _attribs = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPrice"/> class with no arguments.
        /// </summary>
        public ProductTierPrice()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPrice"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductTierPrice(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPrice"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductTierPrice(ProductTierPriceInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IProductTierPrice)) ? false : Equals((IProductTierPrice)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductTierPrice obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductTierPrice x, IProductTierPrice y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Percentage == y.Percentage
                         && (((x.CustomerGroup == null) && (y.CustomerGroup == null)) || ((x.CustomerGroup != null) && x.CustomerGroup.Equals(y.CustomerGroup)))
                         && (((x.Website == null) && (y.Website == null)) || ((x.Website != null) && x.Website.Equals(y.Website)))
                         && (((x.CustomAttributes == null) && (y.CustomAttributes == null)) || ((x.CustomAttributes != null) && x.CustomAttributes.Equals(y.CustomAttributes)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                         && x.Quantity == y.Quantity
                         && x.Value == y.Value;
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductTierPriceInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductTierPriceInterface"/>.</returns>
        public override ProductTierPriceInterface ToInterface()
        {
            ProductTierPriceInterface priceInterface = new ProductTierPriceInterface();

            priceInterface.Quantity = Quantity;
            priceInterface.ExtensionAttributes = new ProductTierPriceExtensionInterface(Percentage, Website.ID);
            priceInterface.Value = Value;
            priceInterface.CustomerGroupID = CustomerGroup.ID;
            
            return priceInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            ProductTierPrice price = new ProductTierPrice();

            price.ID = ID;
            price.CustomerGroup = CustomerGroup.Clone<CustomerGroup>();
            price.Quantity = Quantity;
            price.Value = Value;
            price.Percentage = Percentage;
            price.Website = Website.Clone<StoreWebsite>();
            price.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            price.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return price;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(CustomerGroup);
            hash.Add(Quantity);
            hash.Add(Value);
            hash.Add(Percentage);
            hash.Add(Website);
            hash.Add(CustomAttributes);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IProductTierPrice"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IProductTierPrice obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(ProductTierPriceInterface model)
        {
            if (model != null)
            {
                CustomerGroup = new CustomerGroup(Convert.ToUInt32(model.CustomerGroupID));
                Quantity = model.Quantity;
                Value = model.Value;

                if (model.ExtensionAttributes != null)
                {
                    Percentage = model.ExtensionAttributes.Percentage;
                    Website = new StoreWebsite(Convert.ToUInt32(model.ExtensionAttributes.WebsiteID));
                }
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Quantity: {0} | Price: {1}]", Quantity, Value);
        }
    }
}
