using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents a logical grouping for <see cref="Magento.Customer.Customer"/> entities.
    /// </summary>
    public class CustomerGroup : MagentoRestEntity<CustomerGroupInterface>, IMagentoEntity, ICustomerGroup, IEqualityComparer<ICustomerGroup>, IMagentoRestEntity, IMagentoRestEntity<CustomerGroupInterface>
    {
        private TaxClass _taxClass;
        
        /// <summary>
        /// Gets or sets the customer group code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class that the <see cref="CustomerGroup"/> falls under.
        /// </summary>
        public virtual TaxClass TaxClass
        {
            get
            {
                if (_taxClass == null)
                {
                    _taxClass = new TaxClass();
                }

                return _taxClass;
            }
            set
            {
                _taxClass = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax class that the <see cref="ICustomerGroup"/> falls under.
        /// </summary>
        ITaxClass ICustomerGroup.TaxClass
        {
            get
            {
                return TaxClass;
            }
            set
            {
                TaxClass = value.ToTaxClass();
            }
        }
        
        /// <summary>
        /// Gets or sets the excluded <see cref="StoreWebsite"/> objects for the <see cref="CustomerGroup"/>.
        /// </summary>
        public virtual IEnumerable<StoreWebsite> ExcludedWebsites
        { get; set; }

        /// <summary>
        /// Gets or sets the excluded <see cref="IStoreWebsite"/> objects for the <see cref="ICustomerGroup"/>.
        /// </summary>
        IEnumerable<IStoreWebsite> ICustomerGroup.ExcludedWebsites
        {
            get
            {
                return ExcludedWebsites;
            }
            set
            {
                ExcludedWebsites = (value == null) ? null : value.Select(w => w.ToStoreWebsite());
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroup"/> class with no arguments.
        /// </summary>
        public CustomerGroup()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroup"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public CustomerGroup(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroup"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public CustomerGroup(CustomerGroupInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICustomerGroup)) ? false : Equals((ICustomerGroup)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerGroup obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerGroup x, ICustomerGroup y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.TaxClass == null) && (y.TaxClass == null)) || ((x.TaxClass != null) && (x.TaxClass.Equals(y.TaxClass))))
                         && (((x.ExcludedWebsites == null) && (y.ExcludedWebsites == null)) || ((x.ExcludedWebsites != null) && (x.ExcludedWebsites.SequenceEqual(y.ExcludedWebsites))));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CustomerGroupInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CustomerGroupInterface"/>.</returns>
        public override CustomerGroupInterface ToInterface()
        {
            CustomerGroupInterface groupInterface = new CustomerGroupInterface();

            groupInterface.Code = Code;
            
            groupInterface.ExtensionAttributes = new CustomerGroupExtensionInterface();
            groupInterface.ID = ID;

            return groupInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            CustomerGroup group = new CustomerGroup();

            group.ExcludedWebsites = (ExcludedWebsites == null) ? null : ExcludedWebsites.Select(w => w.Clone<StoreWebsite>());
            group.Code = Code;
            group.ID = ID;
            group.TaxClass = (TaxClass == null) ? null : TaxClass.Clone<TaxClass>();
            group.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            group.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return group;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Code);
            hash.Add(TaxClass);
            hash.Add(ExcludedWebsites);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CustomerGroupInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Code = model.Code;
                TaxClass.ID = model.TaxClassID;
                TaxClass.Name = model.TaxClassName;

                if (model.ExtensionAttributes != null && model.ExtensionAttributes.ExcludedWebsiteIDs != null)
                {
                    ExcludedWebsites = (model.ExtensionAttributes.ExcludedWebsiteIDs.Select(w => new StoreWebsite(Convert.ToUInt32(w))));
                }
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="group"><see cref="ICustomerGroup"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICustomerGroup group)
        {
            ArgumentNullException.ThrowIfNull(group);
            return group.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Code) ? base.ToString() : Code;
        }

    }
}
