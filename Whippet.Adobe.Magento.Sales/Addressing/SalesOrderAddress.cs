using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Extensions.Text;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Addressing;
using Athi.Whippet.Adobe.Magento.Customer.Addressing.Extensions;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.Sales.Addressing
{
    /// <summary>
    /// Represents an address for a <see cref="SalesOrder"/>.
    /// </summary>
    public class SalesOrderAddress : MagentoRestEntity<SalesOrderAddressInterface>, IMagentoEntity, ISalesOrderAddress, IEqualityComparer<ISalesOrderAddress>, IMagentoRestEntity, IMagentoRestEntity<SalesOrderAddressInterface>
    {
        private SalesOrder _parent;
        private Region _region;
        private Country _country;
        private CustomerAddress _parentAddress;
        
        private MagentoCustomAttributeCollection _attribs = null;
        
        /// <summary>
        /// Gets or sets the parent <see cref="SalesOrder"/> associated with the address.
        /// </summary>
        public virtual SalesOrder Parent
        {
            get
            {
                if (_parent == null)
                {
                    _parent = new SalesOrder();
                }

                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ISalesOrder"/> associated with the address.
        /// </summary>
        ISalesOrder ISalesOrderAddress.Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value.ToSalesOrder();
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
        /// Gets or sets the e-mail address associated with the order address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the parent customer address.
        /// </summary>
        public virtual CustomerAddress CustomerAddress
        {
            get
            {
                if (_parentAddress == null)
                {
                    _parentAddress = new CustomerAddress();
                }

                return _parentAddress;
            }
            set
            {
                _parentAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent customer address.
        /// </summary>
        ICustomerAddress ISalesOrderAddress.CustomerAddress
        {
            get
            {
                return CustomerAddress;
            }
            set
            {
                CustomerAddress = value.ToCustomerAddress();
            }
        }
        
        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> address.
        /// </summary>
        IRegion ISalesOrderAddress.Region
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
        ICountry ISalesOrderAddress.Country
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
        /// Specifies whether the <see cref="VAT"/> value is valid.
        /// </summary>
        public virtual bool ValueAddedTaxIsValid
        { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="VAT"/> request date.
        /// </summary>
        public virtual LocalDate? ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="VAT"/> request ID.
        /// </summary>
        public virtual string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VAT"/> request was successful.
        /// </summary>
        public virtual bool ValueAddedTaxSuccessfullyRequested
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAddress"/> class with no arguments.
        /// </summary>
        public SalesOrderAddress()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAddress"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrderAddress(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAddress"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrderAddress(SalesOrderAddressInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ISalesOrderAddress)) ? false : Equals((ISalesOrderAddress)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderAddress obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderAddress x, ISalesOrderAddress y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = (x.ValueAddedTaxIsValid == y.ValueAddedTaxIsValid)
                         && (x.ValueAddedTaxRequestDate.GetValueOrDefault().Equals(y.ValueAddedTaxRequestDate.GetValueOrDefault()))
                         && x.ValueAddedTaxSuccessfullyRequested == y.ValueAddedTaxSuccessfullyRequested
                         && String.Equals(x.ValueAddedTaxRequestID?.Trim(), y.ValueAddedTaxRequestID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
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
                         && String.Equals(x.Email?.Trim(), y.Email?.Trim());
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderAddressInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderAddressInterface"/>.</returns>
        public override SalesOrderAddressInterface ToInterface()
        {
            SalesOrderAddressInterface addressInterface = new SalesOrderAddressInterface();

            addressInterface.ID = ID;
            addressInterface.CustomerID = Parent.ID;
            addressInterface.Region = Region.Code;
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
            addressInterface.Email = Email;
            addressInterface.ValueAddedTaxRequestDate = ValueAddedTaxRequestDate.HasValue ? ValueAddedTaxRequestDate.Value.ToDateOnly().ToString() : String.Empty;
            addressInterface.ValueAddedTaxRequestID = ValueAddedTaxRequestID;
            addressInterface.ValueAddedTaxNumberValid = ValueAddedTaxIsValid.ToMagentoBoolean();
            addressInterface.ValueAddedTaxRequestSuccess = ValueAddedTaxSuccessfullyRequested.ToMagentoBoolean();

            return addressInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesOrderAddress address = new SalesOrderAddress();

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
            address.Email = Email;
            address.ValueAddedTaxRequestDate = ValueAddedTaxRequestDate;
            address.ValueAddedTaxSuccessfullyRequested = ValueAddedTaxSuccessfullyRequested;
            address.ValueAddedTaxRequestID = ValueAddedTaxRequestID;
            address.ValueAddedTaxIsValid = ValueAddedTaxIsValid;
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
            hash.Add(Email);
            hash.Add(ValueAddedTaxRequestDate);
            hash.Add(ValueAddedTaxSuccessfullyRequested);
            hash.Add(ValueAddedTaxRequestID);
            hash.Add(ValueAddedTaxIsValid);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(SalesOrderAddressInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Parent = new SalesOrder(Convert.ToUInt32(model.ID));
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
                ValueAddedTaxIsValid = model.ValueAddedTaxNumberValid.FromMagentoBoolean();
                ValueAddedTaxRequestDate = !String.IsNullOrWhiteSpace(model.ValueAddedTaxRequestDate) ? LocalDate.FromDateOnly(DateOnly.Parse(model.ValueAddedTaxRequestDate)) : null;
                ValueAddedTaxSuccessfullyRequested = model.ValueAddedTaxRequestSuccess.FromMagentoBoolean();
                ValueAddedTaxRequestID = model.ValueAddedTaxRequestID;
                Email = model.Email;

                if (model.Region != null)
                {
                    Region.ID = model.RegionID;
                    Region.Code = model.RegionCode;
                }
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="address"><see cref="ISalesOrderAddress"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesOrderAddress address)
        {
            ArgumentNullException.ThrowIfNull(address);
            return address.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
            {
                builder.Append(base.ToString());
            }
            else
            {
                builder.Append(FirstName);
                builder.AppendSpace();
                builder.Append(LastName);
                builder.AppendSpace();

                if (!String.IsNullOrWhiteSpace(Region.Name))
                {
                    builder.Append('[');
                    builder.Append(Region.Name);

                    if (!String.IsNullOrWhiteSpace(Country.Name))
                    {
                        builder.AppendSpace();
                        builder.Append('(');
                        builder.Append(Country.Name);
                        builder.Append(')');
                    }

                    builder.Append(']');
                }
                else if (!String.IsNullOrWhiteSpace(Country.Name))
                {
                    builder.Append('[');
                    builder.Append(Country.Name);
                    builder.Append(']');
                }
            }
            
            return builder.ToString().Trim();
        }
    }
}
