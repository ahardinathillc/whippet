using System;
using NodaTime;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Represents a company in Magento.
    /// </summary>
    public class Company : MagentoRestEntity<CompanyInterface>, IMagentoEntity, ICompany, IEqualityComparer<ICompany>, IMagentoRestEntity, IMagentoRestEntity<CompanyInterface>
    {
        private CustomerGroup _group;
        private Region _region;
        private Country _country;
        private MagentoCustomer _salesRep;
        private MagentoCustomer _admin;
        
        /// <summary>
        /// Gets or sets the company's status code.
        /// </summary>
        public virtual int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public virtual string CompanyName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's legal name.
        /// </summary>
        public virtual string LegalName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's e-mail address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the company's Value Added Tax (VAT) number.
        /// </summary>
        public virtual string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the company's reseller ID.
        /// </summary>
        public virtual string ResellerID
        { get; set; }

        /// <summary>
        /// Gets or sets the comment for the company account.
        /// </summary>
        public virtual string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the company's address.
        /// </summary>
        public virtual IEnumerable<string> Street
        { get; set; }
        
        /// <summary>
        /// Gets or sets the city portion of the company's address.
        /// </summary>
        public virtual string City
        { get; set; }
        
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
        ICountry ICompany.Country
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
        IRegion ICompany.Region
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
        /// Gets or sets the postal code of the company's address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number associated with the company's address.
        /// </summary>
        public virtual string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CustomerGroup"/> for the current instance.
        /// </summary>
        public virtual CustomerGroup Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new CustomerGroup();
                }

                return _group;
            }
            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICustomerGroup"/> for the current instance.
        /// </summary>
        ICustomerGroup ICompany.Group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value.ToCustomerGroup();
            }
        }

        /// <summary>
        /// Gets or sets the sales representative of the company.
        /// </summary>
        public virtual MagentoCustomer SalesRepresentative
        {
            get
            {
                if (_salesRep == null)
                {
                    _salesRep = new MagentoCustomer();
                }

                return _salesRep;
            }
            set
            {
                _salesRep = value;
            }
        }

        /// <summary>
        /// Gets or sets the sales representative of the company.
        /// </summary>
        ICustomer ICompany.SalesRepresentative
        {
            get
            {
                return SalesRepresentative;
            }
            set
            {
                SalesRepresentative = value.ToCustomer();
            }
        }

        /// <summary>
        /// Gets or sets the reject reason for the company.
        /// </summary>
        public virtual string RejectReason
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the company was rejected.
        /// </summary>
        public virtual Instant? RejectedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the company's administrator user.
        /// </summary>
        public virtual MagentoCustomer Administrator
        {
            get
            {
                if (_admin == null)
                {
                    _admin = new MagentoCustomer();
                }

                return _admin;
            }
            set
            {
                _admin = value;
            }
        }

        /// <summary>
        /// Gets or sets the company's administrator user.
        /// </summary>
        ICustomer ICompany.Administrator
        {
            get
            {
                return Administrator;
            }
            set
            {
                Administrator = value.ToCustomer();
            }
        }

        /// <summary>
        /// Gets or sets the applicable payment method ID.
        /// </summary>
        public virtual int ApplicablePaymentMethodID
        { get; set; }
        
        /// <summary>
        /// Gets or sets a list of available payment methods.
        /// </summary>
        public virtual IEnumerable<string> AvailablePaymentMethods
        { get; set; }

        /// <summary>
        /// Specifies whether the Magento configuration settings should be used instead of custom values.
        /// </summary>
        public virtual bool UseConfigurationSettings
        { get; set; }

        /// <summary>
        /// Specifies whether quotes are enabled for the company.
        /// </summary>
        public virtual bool QuotesEnabled
        { get; set; }

        /// <summary>
        /// Specifies whether purchase orders are enabled for the company.
        /// </summary>
        public virtual bool PurchaseOrdersEnabled
        { get; set; }

        /// <summary>
        /// Gets or sets the applicable shipping method ID.
        /// </summary>
        public virtual int ApplicableShippingMethodID
        { get; set; }

        /// <summary>
        /// Gets or sets the available shipping methods.
        /// </summary>
        public virtual IEnumerable<string> AvailableShippingMethods
        { get; set; }

        /// <summary>
        /// Specifies whether the Magento configuration settings should be used instead of custom values for shipping.
        /// </summary>
        public virtual bool UseShippingConfigurationSettings
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class with no arguments.
        /// </summary>
        public Company()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Company(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Company(CompanyInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICompany)) ? false : Equals((ICompany)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICompany obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICompany x, ICompany y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = (((x.Group == null) && (y.Group == null)) || ((x.Group != null) && x.Group.Equals(y.Group)))
                         && x.Status == y.Status
                         && String.Equals(x.CompanyName?.Trim(), y.CompanyName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.LegalName?.Trim(), y.LegalName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Email?.Trim(), y.Email?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.VAT?.Trim(), y.VAT?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ResellerID?.Trim(), y.ResellerID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Comment?.Trim(), y.Comment?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Street == null) && (y.Street == null)) || ((x.Street != null) && x.Street.SequenceEqual(y.Street)))
                         && String.Equals(x.City?.Trim(), y.City?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Country == null) && (y.Country == null)) || ((x.Country != null) && x.Country.Equals(y.Country)))
                         && (((x.Region == null) && (y.Region == null)) || ((x.Region != null) && x.Region.Equals(y.Region)))
                         && String.Equals(x.PostalCode?.Trim(), y.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Telephone?.Trim(), y.Telephone?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.SalesRepresentative == null) && (y.SalesRepresentative == null)) || ((x.SalesRepresentative != null) && x.SalesRepresentative.Equals(y.SalesRepresentative)))
                         && String.Equals(x.RejectReason?.Trim(), y.RejectReason?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.RejectedTimestamp.GetValueOrDefault().Equals(y.RejectedTimestamp.GetValueOrDefault())
                         && (((x.Administrator == null) && (y.Administrator == null)) || ((x.Administrator != null) && x.Administrator.Equals(y.Administrator)))
                         && x.ApplicableShippingMethodID == y.ApplicableShippingMethodID
                         && (((x.AvailablePaymentMethods == null) && (y.AvailablePaymentMethods == null)) || ((x.AvailablePaymentMethods != null) && x.AvailablePaymentMethods.SequenceEqual(y.AvailablePaymentMethods)))
                         && x.UseConfigurationSettings == y.UseConfigurationSettings
                         && x.QuotesEnabled == y.QuotesEnabled
                         && x.PurchaseOrdersEnabled == y.PurchaseOrdersEnabled
                         && x.ApplicablePaymentMethodID == y.ApplicablePaymentMethodID
                         && (((x.AvailableShippingMethods == null) && (y.AvailableShippingMethods == null)) || ((x.AvailableShippingMethods != null) && x.AvailableShippingMethods.SequenceEqual(y.AvailableShippingMethods)))
                         && x.UseShippingConfigurationSettings == y.UseShippingConfigurationSettings
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CustomerInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CustomerAddressInterface"/>.</returns>
        public override CompanyInterface ToInterface()
        {
            string[] paymentMethods = (AvailablePaymentMethods == null) ? null : AvailablePaymentMethods.ToArray();
            string[] shippingMethods = (AvailableShippingMethods == null) ? null : AvailableShippingMethods.ToArray();
            
            CompanyInterface cInterface = new CompanyInterface();
            
            cInterface.ID = ID;
            cInterface.Status = Status;
            cInterface.Name = CompanyName;
            cInterface.LegalName = LegalName;
            cInterface.Email = Email;
            cInterface.VAT = VAT;
            cInterface.ResellerID = ResellerID;
            cInterface.Comment = Comment;
            cInterface.Street = (Street == null) ? null : Street.Select(s => s).ToArray();
            cInterface.City = City;
            cInterface.CountryID = Country.ID;
            cInterface.Region = Region.Name;
            cInterface.RegionID = Region.Code;
            cInterface.PostalCode = PostalCode;
            cInterface.Telephone = Telephone;
            cInterface.CustomerGroupID = Group.ID;
            cInterface.SalesRepresentativeID = SalesRepresentative.ID;
            cInterface.RejectReason = RejectReason;
            cInterface.RejectedAt = RejectedTimestamp.HasValue ? RejectedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            cInterface.AdministratorID = Administrator.ID;
            cInterface.ExtensionAttributes = new CompanyExtensionInterface();
            cInterface.ExtensionAttributes.ApplicablePaymentMethod = ApplicablePaymentMethodID;
            cInterface.ExtensionAttributes.AvailablePaymentMethods = (paymentMethods == null) ? null : paymentMethods.Concat(",");
            cInterface.ExtensionAttributes.UseConfigurationSettings = UseConfigurationSettings.ToMagentoBoolean();
            cInterface.ExtensionAttributes.QuoteConfiguration = new CompanyQuoteConfigurationInterface(Convert.ToString(ID), QuotesEnabled, new CompanyQuoteConfigurationExtensionInterface());
            cInterface.ExtensionAttributes.PurchaseOrdersEnabled = PurchaseOrdersEnabled;
            cInterface.ExtensionAttributes.ApplicableShippingMethod = ApplicableShippingMethodID;
            cInterface.ExtensionAttributes.AvailableShippingMethods = (shippingMethods == null) ? null : shippingMethods.Concat(",");
            cInterface.ExtensionAttributes.UseShippingConfigurationSettings = UseShippingConfigurationSettings.ToMagentoBoolean();

            return cInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Company company = new Company();

            company.ID = ID;
            company.Status = Status;
            company.CompanyName = CompanyName;
            company.LegalName = LegalName;
            company.Email = Email;
            company.VAT = VAT;
            company.ResellerID = ResellerID;
            company.Comment = Comment;
            company.Street = (Street == null) ? null : Street.Select(s => s);
            company.City = City;
            company.Country = Country.Clone<Country>();
            company.Region = Region.Clone<Region>();
            company.PostalCode = PostalCode;
            company.Telephone = Telephone;
            company.Group = Group.Clone<CustomerGroup>();
            company.SalesRepresentative = SalesRepresentative.Clone<MagentoCustomer>();
            company.RejectReason = RejectReason;
            company.RejectedTimestamp = RejectedTimestamp;
            company.Administrator = Administrator.Clone<MagentoCustomer>();
            company.ApplicablePaymentMethodID = ApplicablePaymentMethodID;
            company.AvailablePaymentMethods = (AvailablePaymentMethods == null) ? null : AvailablePaymentMethods.Select(p => p);
            company.UseConfigurationSettings = UseConfigurationSettings;
            company.QuotesEnabled = QuotesEnabled;
            company.PurchaseOrdersEnabled = PurchaseOrdersEnabled;
            company.ApplicableShippingMethodID = ApplicableShippingMethodID;
            company.AvailableShippingMethods = (AvailableShippingMethods == null) ? null : AvailableShippingMethods.Select(s => s);
            company.UseShippingConfigurationSettings = UseShippingConfigurationSettings;

            return company;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Status);
            hash.Add(CompanyName);
            hash.Add(LegalName);
            hash.Add(Email);
            hash.Add(VAT);
            hash.Add(ResellerID);
            hash.Add(Comment);
            hash.Add(Street);
            hash.Add(City);
            hash.Add(Country);
            hash.Add(Region);
            hash.Add(PostalCode);
            hash.Add(Telephone);
            hash.Add(Group);
            hash.Add(SalesRepresentative);
            hash.Add(RejectReason);
            hash.Add(RejectedTimestamp);
            hash.Add(Administrator);
            hash.Add(ApplicablePaymentMethodID);
            hash.Add(AvailablePaymentMethods);
            hash.Add(UseConfigurationSettings);
            hash.Add(QuotesEnabled);
            hash.Add(PurchaseOrdersEnabled);
            hash.Add(ApplicableShippingMethodID);
            hash.Add(AvailableShippingMethods);
            hash.Add(UseShippingConfigurationSettings);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="company"><see cref="ICompany"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICompany company)
        {
            ArgumentNullException.ThrowIfNull(company);
            return company.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CompanyInterface model)
        {
            if (model != null)
            {
                model.ID = ID;
                model.Status = Status;
                model.Name = CompanyName;
                model.LegalName = LegalName;
                model.Email = Email;
                model.VAT = VAT;
                model.ResellerID = ResellerID;
                model.Comment = Comment;
                model.Street = (Street == null) ? null : Street.ToArray();
                model.City = City;
                model.CountryID = Country.ID;
                model.Region = Region.Name;
                model.RegionID = Region.Code;
                model.PostalCode = PostalCode;
                model.Telephone = Telephone;
                model.CustomerGroupID = Group.ID;
                model.SalesRepresentativeID = SalesRepresentative.ID;
                model.RejectReason = RejectReason;
                model.RejectedAt = RejectedTimestamp.HasValue ? RejectedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
                model.AdministratorID = Administrator.ID;
                model.ExtensionAttributes = new CompanyExtensionInterface();
                model.ExtensionAttributes.ApplicablePaymentMethod = ApplicablePaymentMethodID;
                model.ExtensionAttributes.AvailablePaymentMethods = (AvailablePaymentMethods == null) ? null : AvailablePaymentMethods.Concat(",");
                model.ExtensionAttributes.UseConfigurationSettings = UseConfigurationSettings.ToMagentoBoolean();
                model.ExtensionAttributes.QuoteConfiguration = new CompanyQuoteConfigurationInterface(Convert.ToString(ID), QuotesEnabled, new CompanyQuoteConfigurationExtensionInterface());
                model.ExtensionAttributes.PurchaseOrdersEnabled = PurchaseOrdersEnabled;
                model.ExtensionAttributes.ApplicableShippingMethod = ApplicableShippingMethodID;
                model.ExtensionAttributes.AvailableShippingMethods = (AvailableShippingMethods == null) ? null : AvailableShippingMethods.Concat(",");
                model.ExtensionAttributes.UseShippingConfigurationSettings = UseShippingConfigurationSettings.ToMagentoBoolean();
                
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(CompanyName) ? base.ToString() : CompanyName;
        }
    }
}
