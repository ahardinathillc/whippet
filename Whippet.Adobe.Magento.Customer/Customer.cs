using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Addressing;
using Athi.Whippet.Adobe.Magento.Customer.Addressing.Extensions;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using Athi.Whippet.Extensions.Text;
using MagentoStore = Athi.Whippet.Adobe.Magento.Store.Store;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents an individual customer in Magento.
    /// </summary>
    public class Customer : MagentoRestEntity<CustomerInterface>, IMagentoEntity, ICustomer, IEqualityComparer<ICustomer>, IMagentoAuditableEntity
    {
        private CustomerGroup _group;

        private CustomerAddress _defaultBilling;
        private CustomerAddress _defaultShipping;

        private MagentoStore _store;

        private StoreWebsite _website;

        private MagentoCustomAttributeCollection _attributes;
        
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
        ICustomerGroup ICustomer.Group
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
        /// Gets or sets the customer's default billing address.
        /// </summary>
        public virtual CustomerAddress DefaultBilling
        {
            get
            {
                if (_defaultBilling == null)
                {
                    _defaultBilling = new CustomerAddress();
                }

                return _defaultBilling;
            }
            set
            {
                _defaultBilling = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the customer's default billing address.
        /// </summary>
        ICustomerAddress ICustomer.DefaultBilling
        {
            get
            {
                return DefaultBilling;
            }
            set
            {
                DefaultBilling = value.ToCustomerAddress();
            }
        }

        /// <summary>
        /// Gets or sets the customer's default shipping address.
        /// </summary>
        public virtual CustomerAddress DefaultShipping
        {
            get
            {
                if (_defaultBilling == null)
                {
                    _defaultBilling = new CustomerAddress();
                }
                
                return _defaultShipping;
            }
            set
            {
                _defaultBilling = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the customer's default shipping address.
        /// </summary>
        ICustomerAddress ICustomer.DefaultShipping
        {
            get
            {
                return DefaultShipping;
            }
            set
            {
                DefaultShipping = value.ToCustomerAddress();
            }
        }
        
        /// <summary>
        /// Gets or sets the customer confirmation number.
        /// </summary>
        public virtual string ConfirmationNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the area in which the <see cref="Customer"/> was created.
        /// </summary>
        public virtual string CreatedArea
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        public virtual LocalDate? DateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the user's e-mail address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        public virtual string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        public virtual string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        public virtual string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the Magento attribute ID of the <see cref="Customer"/> object's gender.
        /// </summary>
        public virtual int? Gender
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Store"/> that the <see cref="Customer"/>
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
        /// Gets or sets the <see cref="IStore"/> that the <see cref="ICustomer"/> object belongs to.
        /// </summary>
        IStore ICustomer.Store
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
        /// Gets or sets the customer's Value Added Tax (VAT) number.
        /// </summary>
        public virtual string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> that the <see cref="Customer"/> is registered with.
        /// </summary>
        public StoreWebsite Website
        {
            get
            {
                if (_website == null)
                {
                    _website = new StoreWebsite();
                }

                return _website;
            }
            set
            {
                _website = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IStoreWebsite"/> that the <see cref="ICustomer"/> is registered with.
        /// </summary>
        IStoreWebsite ICustomer.Website
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
        /// Gets or sets the customer's associated addresses.
        /// </summary>
        public virtual IEnumerable<CustomerAddress> Addresses
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's associated addresses.
        /// </summary>
        IEnumerable<ICustomerAddress> ICustomer.Addresses
        {
            get
            {
                return Addresses;
            }
            set
            {
                Addresses = (value == null) ? null : value.Select(a => a.ToCustomerAddress());
            }
        }

        /// <summary>
        /// Specifies whether auto group reassignment should be disabled.
        /// </summary>
        public virtual bool DisableAutoGroupChange
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's company profile.
        /// </summary>
        public virtual CustomerCompanyProfile? CompanyProfile
        { get; set; }

        /// <summary>
        /// Specifies whether customer support is allowed for the current instance.
        /// </summary>
        public virtual bool AssistanceAllowed
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is currently a subscriber.
        /// </summary>
        public virtual bool IsSubscribed
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time the entity was created.
        /// </summary>
        public virtual Instant CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was last updated (if any).
        /// </summary>
        public virtual Instant? UpdatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets the entity's <see cref="MagentoCustomAttributeCollection"/> that contains all <see cref="MagentoCustomAttribute"/> entries. This property is read-only.
        /// </summary>
        public virtual MagentoCustomAttributeCollection CustomAttributes
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new MagentoCustomAttributeCollection();
                }

                return _attributes;
            }
            protected internal set
            {
                _attributes = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with no arguments.
        /// </summary>
        public Customer()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Customer(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Customer(CustomerInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICustomer)) ? false : Equals((ICustomer)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomer obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomer x, ICustomer y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = (((x.Group == null) && (y.Group == null)) || ((x.Group != null) && x.Group.Equals(y.Group)))
                         && (((x.DefaultBilling == null) && (y.DefaultBilling == null)) || ((x.DefaultBilling != null) && x.DefaultBilling.Equals(y.DefaultBilling)))
                         && (((x.DefaultShipping == null) && (y.DefaultShipping == null)) || ((x.DefaultShipping != null) && x.DefaultShipping.Equals(y.DefaultShipping)))
                         && String.Equals(x.ConfirmationNumber?.Trim(), y.ConfirmationNumber?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (x.CreatedTimestamp.Equals(y.CreatedTimestamp))
                         && (x.UpdatedTimestamp.GetValueOrDefault().Equals(y.UpdatedTimestamp.GetValueOrDefault()))
                         && String.Equals(x.CreatedArea?.Trim(), y.CreatedArea?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (x.DateOfBirth.GetValueOrDefault().Equals(y.DateOfBirth.GetValueOrDefault()))
                         && String.Equals(x.Email?.Trim(), y.Email?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (String.Equals(x.FirstName?.Trim(), y.FirstName?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                         && (String.Equals(x.MiddleName?.Trim(), y.MiddleName?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                         && (String.Equals(x.LastName?.Trim(), y.LastName?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                         && (String.Equals(x.Prefix?.Trim(), y.Prefix?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                         && (x.Gender.GetValueOrDefault() == y.Gender.GetValueOrDefault())
                         && (((x.Store == null) && (y.Store == null)) || ((x.Store != null) && x.Store.Equals(y.Store)))
                         && (String.Equals(x.VAT?.Trim(), y.VAT?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                         && (((x.Website == null) && (y.Website == null)) || ((x.Website != null) && x.Website.Equals(y.Website)))
                         && (((x.Addresses == null) && (y.Addresses == null)) || ((x.Addresses != null) && x.Addresses.SequenceEqual(y.Addresses)))
                         && (x.DisableAutoGroupChange == y.DisableAutoGroupChange)
                         && (((x.CompanyProfile == null) && (y.CompanyProfile == null)) || ((x.CompanyProfile != null) && x.CompanyProfile.Equals(y.CompanyProfile)))
                         && (((x.CustomAttributes == null) && (y.CustomAttributes == null)) || ((x.CustomAttributes != null) && x.CustomAttributes.Equals(y.CustomAttributes)))
                         && (x.AssistanceAllowed == y.AssistanceAllowed)
                         && (x.IsSubscribed == y.IsSubscribed)
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CustomerInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CustomerAddressInterface"/>.</returns>
        public override CustomerInterface ToInterface()
        {
            CustomerInterface customerInterface = new CustomerInterface();
            CustomerCompanyInterface companyInterface = new CustomerCompanyInterface(ID,
                CompanyProfile.GetValueOrDefault().CompanyID,
                CompanyProfile.GetValueOrDefault().Title,
                CompanyProfile.GetValueOrDefault().Status,
                CompanyProfile.GetValueOrDefault().Telephone,
                new CustomerCompanyExtensionInterface()
            );
            
            customerInterface.ID = ID;
            customerInterface.GroupID = Group.ID;
            customerInterface.DefaultBillingAddressID = Convert.ToString(DefaultBilling.ID);
            customerInterface.DefaultShippingAddressID = Convert.ToString(DefaultShipping.ID);
            customerInterface.Confirmation = ConfirmationNumber;
            customerInterface.CreatedAt = CreatedTimestamp.ToDateTimeUtc().ToString();
            customerInterface.UpdatedAt = UpdatedTimestamp.HasValue ? UpdatedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            customerInterface.CreatedIn = CreatedArea;
            customerInterface.DateOfBirth = DateOfBirth.HasValue ? DateOfBirth.Value.ToString() : String.Empty;
            customerInterface.Email = Email;
            customerInterface.FirstName = FirstName;
            customerInterface.MiddleName = MiddleName;
            customerInterface.LastName = LastName;
            customerInterface.Prefix = Prefix;
            customerInterface.Gender = Gender.GetValueOrDefault();
            customerInterface.StoreID = Store.ID;
            customerInterface.VAT = VAT;
            customerInterface.WebsiteID = Website.ID;
            customerInterface.Addresses = (Addresses == null) ? null : Addresses.Select(a => a.ToInterface()).ToArray();
            customerInterface.DisableAutoGroupChange = DisableAutoGroupChange.ToMagentoBoolean();
            customerInterface.ExtensionAttributes = new CustomerExtensionInterface(companyInterface, AssistanceAllowed.ToMagentoBoolean(), IsSubscribed);
            customerInterface.CustomAttributes = CustomAttributes.ToInterface();
            
            return customerInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Customer customer = new Customer(Convert.ToUInt32(ID), Server, RestEndpoint);

            customer.Group = Group.Clone<CustomerGroup>();
            customer.DefaultBilling = DefaultBilling.Clone<CustomerAddress>();
            customer.DefaultShipping = DefaultShipping.Clone<CustomerAddress>();
            customer.ConfirmationNumber = ConfirmationNumber;
            customer.CreatedTimestamp = CreatedTimestamp;
            customer.UpdatedTimestamp = UpdatedTimestamp;
            customer.CreatedArea = CreatedArea;
            customer.DateOfBirth = DateOfBirth;
            customer.Email = Email;
            customer.FirstName = FirstName;
            customer.MiddleName = MiddleName;
            customer.LastName = LastName;
            customer.Prefix = Prefix;
            customer.Gender = Gender;
            customer.Store = Store.Clone<MagentoStore>();
            customer.VAT = VAT;
            customer.Website = Website.Clone<StoreWebsite>();
            customer.Addresses = (Addresses == null) ? null : Addresses.Select(a => a.Clone<CustomerAddress>());
            customer.DisableAutoGroupChange = DisableAutoGroupChange;
            customer.CompanyProfile = CompanyProfile;
            customer.CustomAttributes = new MagentoCustomAttributeCollection(CustomAttributes);
            customer.AssistanceAllowed = AssistanceAllowed;
            customer.IsSubscribed = IsSubscribed;
            
            return customer;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Group);
            hash.Add(DefaultBilling);
            hash.Add(DefaultShipping);
            hash.Add(ConfirmationNumber);
            hash.Add(CreatedTimestamp);
            hash.Add(UpdatedTimestamp.GetValueOrDefault());
            hash.Add(CreatedArea);
            hash.Add(DateOfBirth.GetValueOrDefault());
            hash.Add(Email);
            hash.Add(FirstName);
            hash.Add(MiddleName);
            hash.Add(LastName);
            hash.Add(Prefix);
            hash.Add(Gender);
            hash.Add(Store);
            hash.Add(VAT);
            hash.Add(Website);
            hash.Add(Addresses);
            hash.Add(DisableAutoGroupChange);
            hash.Add(CompanyProfile);
            hash.Add(CustomAttributes);
            hash.Add(AssistanceAllowed);
            hash.Add(IsSubscribed);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="customer"><see cref="ICustomerAddress"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICustomer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            return customer.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CustomerInterface model)
        {
            DateTime dttm;
            DateOnly date;
            
            if (model != null)
            {
                Group = new CustomerGroup(Convert.ToUInt32(model.GroupID));
                DefaultBilling = new CustomerAddress(Convert.ToUInt32(model.DefaultBillingAddressID));
                DefaultShipping = new CustomerAddress(Convert.ToUInt32(model.DefaultShippingAddressID));
                ConfirmationNumber = model.Confirmation;

                if (!String.IsNullOrWhiteSpace(model.CreatedAt) && DateTime.TryParse(model.CreatedAt, out dttm))
                {
                    CreatedTimestamp = Instant.FromDateTimeUtc(dttm.ToUniversalTime(true));
                }
                
                if (!String.IsNullOrWhiteSpace(model.UpdatedAt) && DateTime.TryParse(model.UpdatedAt, out dttm))
                {
                    CreatedTimestamp = Instant.FromDateTimeUtc(dttm.ToUniversalTime(true));
                }

                CreatedArea = model.CreatedIn;

                if (!String.IsNullOrWhiteSpace(model.DateOfBirth) && DateOnly.TryParse(model.DateOfBirth, out date))
                {
                    DateOfBirth = LocalDate.FromDateOnly(date);
                }
                
                Email = model.Email;
                FirstName = model.FirstName;
                MiddleName = model.MiddleName;
                LastName = model.LastName;
                Prefix = model.Prefix;
                Gender = model.Gender;
                Store = new MagentoStore(Convert.ToUInt32(model.StoreID));
                VAT = model.VAT;
                Website = new StoreWebsite(Convert.ToUInt32(model.WebsiteID));

                if (model.Addresses != null && model.Addresses.Length > 0)
                {
                    Addresses = model.Addresses.Select(a => new CustomerAddress(a));
                }

                DisableAutoGroupChange = model.DisableAutoGroupChange.FromMagentoBoolean();

                if (model.ExtensionAttributes != null && model.ExtensionAttributes.Company != null)
                {
                    CompanyProfile = new CustomerCompanyProfile(model.ExtensionAttributes.Company.CustomerID, model.ExtensionAttributes.Company.CompanyID, model.ExtensionAttributes.Company.JobTitle, model.ExtensionAttributes.Company.Telephone, model.ExtensionAttributes.Company.Status);
                }

                AssistanceAllowed = model.ExtensionAttributes.AssistanceAllowed.FromMagentoBoolean();
                IsSubscribed = model.ExtensionAttributes.IsSubscribed;
                
                if (model.CustomAttributes != null && model.CustomAttributes.Length > 0)
                {
                    CustomAttributes = new MagentoCustomAttributeCollection(model.CustomAttributes.Select(ca => new KeyValuePair<string, string>(ca.AttributeCode, ca.Value)));
                }
            }
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
            }
            
            return builder.ToString().Trim();
        }
    }
}
