using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer.Addressing
{
    /// <summary>
    /// Represents an address for a Magento <see cref="Customer"/> instance.
    /// </summary>
    public class CustomerAddress : MagentoRestEntity<CustomerAddressInterface>, IMagentoEntity, ICustomerAddress, IEqualityComparer<ICustomerAddress>, IMagentoCustomAttributesEntity
    {
        private Customer _parent;
        private Region _region;
        private Country _country;

        private MagentoCustomAttributeCollection _attribs = null;
        
        /// <summary>
        /// Gets or sets the parent <see cref="Customer"/> associated with the address.
        /// </summary>
        public virtual Customer Parent
        {
            get
            {
                if (_parent == null)
                {
                    _parent = new Customer();
                }

                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> associated with the address.
        /// </summary>
        ICustomer ICustomerAddress.Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value.ToCustomer();
            }
        }

        /// <summary>
        /// Gets or sets the region that the address resides in. 
        /// </summary>
        public virtual Region Region
        {
            get
            {
                if (_region == null)
                {
                    _region = new Region();
                }

                return _region;
            }
            set
            {
                _region = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> address.
        /// </summary>
        IRegion ICustomerAddress.Region
        {
            get
            {
                return Region;
            }
            set
            {
                Region = value.ToRegion();
            }
        }

        /// <summary>
        /// Gets or sets the country that the address resides in.
        /// </summary>
        public virtual Country Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new Country();
                }

                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICountry"/> address.
        /// </summary>
        ICountry ICustomerAddress.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value.ToCountry();
            }
        }

        /// <summary>
        /// Gets or sets the street address portion address.
        /// </summary>
        public virtual IEnumerable<string> Street
        { get; set; }
        
        /// <summary>
        /// Gets or sets the company line address.
        /// </summary>
        public virtual string Company
        { get; set; }
        
        /// <summary>
        /// Gets or sets the telephone number associated with the address.
        /// </summary>
        public virtual string Telephone
        { get; set; }
        
        /// <summary>
        /// Gets or sets the facsimile number associated with the address.
        /// </summary>
        public virtual string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        public virtual string City
        { get; set; }

        /// <summary>
        /// Gets or sets the first name of the recipient.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name of the recipient.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the recipient.
        /// </summary>
        public virtual string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the recipient.
        /// </summary>
        public virtual string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix of the recipient.
        /// </summary>
        public virtual string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the Value Added Tax (VAT) identification number of the address.
        /// </summary>
        public virtual string VAT
        { get; set; }

        /// <summary>
        /// Specifies whether the address is the default shipping address.
        /// </summary>
        public virtual bool IsDefaultShipping
        { get; set; }

        /// <summary>
        /// Specifies whether the address is the default billing address.
        /// </summary>
        public virtual bool IsDefaultBilling
        { get; set; }

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
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class with no arguments.
        /// </summary>
        public CustomerAddress()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public CustomerAddress(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public CustomerAddress(CustomerAddressInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICustomerAddress)) ? false : Equals((ICustomerAddress)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerAddress obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerAddress x, ICustomerAddress y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = (x.IsDefaultBilling == y.IsDefaultBilling)
                         && (x.IsDefaultShipping == y.IsDefaultShipping)
                         && String.Equals(x.Company?.Trim(), y.Company?.Trim())
                         && String.Equals(x.City?.Trim(), y.City?.Trim())
                         && (((x.Country == null) && (y.Country == null)) || ((x.Country != null) && x.Country.Equals(y.Country)))
                         && (((x.Region == null) && (y.Region == null)) || ((x.Region != null) && x.Region.Equals(y.Region)))
                         && String.Equals(x.Fax?.Trim(), y.Fax?.Trim())
                         && (((x.Parent == null) && (y.Parent == null)) || ((x.Parent != null) && x.Parent.Equals(y.Parent)))
                         && String.Equals(x.Prefix?.Trim(), y.Prefix?.Trim())
                         && (((x.Street == null) && (y.Street == null)) || ((x.Street != null) && x.Street.SequenceEqual(y.Street)))
                         && String.Equals(x.Suffix?.Trim(), y.Suffix?.Trim())
                         && String.Equals(x.Telephone?.Trim(), y.Telephone?.Trim())
                         && String.Equals(x.FirstName?.Trim(), y.FirstName?.Trim())
                         && String.Equals(x.LastName?.Trim(), y.LastName?.Trim())
                         && String.Equals(x.MiddleName?.Trim(), y.MiddleName?.Trim())
                         && String.Equals(x.PostalCode?.Trim(), y.PostalCode?.Trim())
                         && String.Equals(x.VAT?.Trim(), y.VAT?.Trim())
                         && (((x.CustomAttributes == null) && (y.CustomAttributes == null)) || ((x.CustomAttributes != null) && x.CustomAttributes.Equals(y.CustomAttributes)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CustomerAddressInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CustomerAddressInterface"/>.</returns>
        public override CustomerAddressInterface ToInterface()
        {
            CustomerAddressInterface addressInterface = new CustomerAddressInterface();

            addressInterface.ID = ID;
            addressInterface.CustomerID = Parent.ID;
            addressInterface.Region = new CustomerRegionInterface(Region.ID, Region.Code, Region.Name, new CustomerRegionExtensionInterface());
            addressInterface.RegionID = Region.ID;
            addressInterface.CountryID = Country.ISO2;
            addressInterface.Street = (Street == null) ? null : Street.ToArray();
            addressInterface.Company = Company;
            addressInterface.Telephone = Telephone;
            addressInterface.Fax = Fax;
            addressInterface.PostalCode = PostalCode;
            addressInterface.City = City;
            addressInterface.FirstName = FirstName;
            addressInterface.LastName = LastName;
            addressInterface.MiddleName = MiddleName;
            addressInterface.Prefix = Prefix;
            addressInterface.Suffix = Suffix;
            addressInterface.VAT = VAT;
            addressInterface.IsDefaultBilling = IsDefaultBilling;
            addressInterface.IsDefaultShipping = IsDefaultShipping;
            addressInterface.CustomAttributes = CustomAttributes.ToInterface();

            return addressInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            CustomerAddress address = new CustomerAddress();

            address.CustomAttributes = new MagentoCustomAttributeCollection(CustomAttributes);
            address.City = City;
            address.Company = Company;
            address.Country = Country.Clone<Country>();
            address.Region = Region.Clone<Region>();
            address.Street = Street.Select(s => s);
            address.Telephone = Telephone;
            address.Fax = Fax;
            address.PostalCode = PostalCode;
            address.FirstName = FirstName;
            address.MiddleName = MiddleName;
            address.LastName = LastName;
            address.Prefix = Prefix;
            address.Suffix = Suffix;
            address.VAT = VAT;
            address.IsDefaultBilling = IsDefaultBilling;
            address.IsDefaultShipping = IsDefaultShipping;
            address.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            address.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return address;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(City);
            hash.Add(Company);
            hash.Add(Country);
            hash.Add(Region);
            hash.Add(Street);
            hash.Add(Telephone);
            hash.Add(Fax);
            hash.Add(PostalCode);
            hash.Add(FirstName);
            hash.Add(MiddleName);
            hash.Add(LastName);
            hash.Add(Prefix);
            hash.Add(Suffix);
            hash.Add(VAT);
            hash.Add(IsDefaultBilling);
            hash.Add(IsDefaultShipping);
            hash.Add(CustomAttributes);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CustomerAddressInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Parent = new Customer(Convert.ToUInt32(model.ID));
                Region = new Region(Convert.ToUInt32(model.RegionID));
                Country = new Country() { ID = model.CountryID };
                Street = model.Street;
                Company = model.Company;
                Telephone = model.Telephone;
                Fax = model.Fax;
                PostalCode = model.PostalCode;
                City = model.City;
                FirstName = model.FirstName;
                LastName = model.LastName;
                MiddleName = model.MiddleName;
                Prefix = model.Prefix;
                Suffix = model.Suffix;
                VAT = model.VAT;
                IsDefaultBilling = model.IsDefaultBilling;
                IsDefaultShipping = model.IsDefaultShipping;
                
                if (model.Region != null)
                {
                    Region.Name = model.Region.Region;
                    Region.Code = model.Region.Code;
                }

                if (model.CustomAttributes != null && model.CustomAttributes.Length > 0)
                {
                    CustomAttributes = new MagentoCustomAttributeCollection(model.CustomAttributes.Select(ca => new KeyValuePair<string, string>(ca.AttributeCode, ca.Value)));
                }
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="website"><see cref="ICustomerAddress"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICustomerAddress website)
        {
            ArgumentNullException.ThrowIfNull(website);
            return website.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
    }
}
