using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using NodaTime.TimeZones;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a <see cref="Store"/> configuration which specifies locality, currency used, and store URLs.
    /// </summary>
    public class StoreConfiguration : MagentoRestEntity<StoreConfigurationInterface>, IMagentoEntity, IStoreConfiguration, IEqualityComparer<IStoreConfiguration>, IMagentoRestEntity
    {
        private IReadOnlyDictionary<StoreLinkType, StoreLinkValue> _links;
        
        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the store website.
        /// </summary>
        public virtual StoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the store website.
        /// </summary>
        IStoreWebsite IStoreConfiguration.Website
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
        /// Gets or sets the locale of the store.
        /// </summary>
        public virtual string Locale
        { get; set; }

        /// <summary>
        /// Gets or sets the store's currency code.
        /// </summary>
        public virtual string CurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the default display currency code.
        /// </summary>
        public virtual string DisplayCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the time zone that applies to the store.
        /// </summary>
        public virtual DateTimeZone Timezone
        { get; set; }

        /// <summary>
        /// Gets or sets the unit of weight used by the store.
        /// </summary>
        public virtual string UnitOfWeight
        { get; set; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey,TValue}"/> of <see cref="StoreLinkType"/> objects and their associated <see cref="StoreLinkValue"/> (mutable) values. This property is read-only.
        /// </summary>
        public virtual IReadOnlyDictionary<StoreLinkType, StoreLinkValue> Links
        {
            get
            {
                if (_links == null)
                {
                    _links = new ReadOnlyDictionary<StoreLinkType, StoreLinkValue>(
                        new Dictionary<StoreLinkType, StoreLinkValue>(Enum.GetValues<StoreLinkType>().Select(slt => new KeyValuePair<StoreLinkType, StoreLinkValue>(slt, new StoreLinkValue(slt, null))))
                    );
                }

                return _links;
            }
            protected internal set
            {
                _links = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreConfiguration"/> class with no arguments.
        /// </summary>
        public StoreConfiguration()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreConfiguration"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StoreConfiguration(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreConfiguration"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StoreConfiguration(StoreConfigurationInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IStoreConfiguration)) ? false : Equals((IStoreConfiguration)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreConfiguration obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreConfiguration x, IStoreConfiguration y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                             && String.Equals(x.Locale, y.Locale, StringComparison.InvariantCultureIgnoreCase)
                             && String.Equals(x.CurrencyCode, y.CurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                             && String.Equals(x.DisplayCurrencyCode, y.DisplayCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                             && String.Equals(x.UnitOfWeight, y.UnitOfWeight, StringComparison.InvariantCultureIgnoreCase)
                             && ((((x.Website == null) && (y.Website == null))) || ((x.Website != null) && (x.Website.Equals(y.Website))))
                             && x.Links._Equals(y.Links)
                             && x.Timezone.Equals(y.Timezone);
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="StoreInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="StoreInterface"/>.</returns>
        public override StoreConfigurationInterface ToInterface()
        {
            StoreConfigurationInterface configInterface = new StoreConfigurationInterface();

            configInterface.URL = Links[StoreLinkType.Store].URL?.ToString();
            configInterface.Code = Code;
            configInterface.Locale = Locale;
            configInterface.Timezone = Timezone.ToString();
            configInterface.ID = ID;
            configInterface.WeightUnit = UnitOfWeight;
            configInterface.BaseCurrencyCode = CurrencyCode;
            configInterface.DefaultDisplayCurrencyCode = DisplayCurrencyCode;
            configInterface.LinkURL = Links[StoreLinkType.Link].URL?.ToString();
            configInterface.MediaURL = Links[StoreLinkType.Media].URL?.ToString();
            configInterface.StaticURL = Links[StoreLinkType.Static].URL?.ToString();
            configInterface.SecureURL = Links[StoreLinkType.SecureStore].URL?.ToString();
            configInterface.SecureLinkURL = Links[StoreLinkType.SecureLink].URL?.ToString();
            configInterface.SecureMediaURL = Links[StoreLinkType.SecureMedia].URL?.ToString();
            configInterface.SecureStaticURL = Links[StoreLinkType.Static].URL?.ToString();

            if (Website != null)
            {
                configInterface.WebsiteID = Website.ID;
            }

            return configInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            StoreConfiguration configuration = new StoreConfiguration();

            configuration.Code = Code;
            configuration.Website = (Website == null) ? null : Website.Clone<StoreWebsite>();
            configuration.Timezone = Timezone;
            configuration.CurrencyCode = CurrencyCode;
            configuration.Links = Links;
            configuration.Locale = Locale;
            configuration.DisplayCurrencyCode = DisplayCurrencyCode;
            configuration.UnitOfWeight = UnitOfWeight;
            configuration.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            configuration.ID = ID;
            configuration.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return configuration;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(Code);
            hash.Add(Website);
            hash.Add(Timezone);
            hash.Add(CurrencyCode);
            hash.Add(Links);
            hash.Add(Locale);
            hash.Add(DisplayCurrencyCode);
            hash.Add(UnitOfWeight);
            hash.Add(Server);
            hash.Add(ID);
            hash.Add(RestEndpoint);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="config"><see cref="IStoreConfiguration"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStoreConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(config);
            return config.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(StoreConfigurationInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Code = model.Code;
                Website = new StoreWebsite(Convert.ToUInt32(model.WebsiteID));

                if (String.IsNullOrWhiteSpace(model.Timezone))
                {
                    Timezone = BclDateTimeZone.FromTimeZoneInfo(TimeZoneInfo.Local);    // default to server time zone
                }
                else
                {
                    Timezone = BclDateTimeZone.FromTimeZoneInfo(TimeZoneInfo.FindSystemTimeZoneById(model.Timezone));
                }

                CurrencyCode = model.BaseCurrencyCode;
                Locale = model.Locale;
                DisplayCurrencyCode = model.DefaultDisplayCurrencyCode;
                UnitOfWeight = model.WeightUnit;

                if (!String.IsNullOrWhiteSpace(model.URL))
                {
                    Links[StoreLinkType.Store].URL = new Uri(model.URL);
                }

                if (!String.IsNullOrWhiteSpace(model.LinkURL))
                {
                    Links[StoreLinkType.Link].URL = new Uri(model.LinkURL);
                }

                if (!String.IsNullOrWhiteSpace(model.MediaURL))
                {
                    Links[StoreLinkType.Media].URL = new Uri(model.MediaURL);
                }

                if (!String.IsNullOrWhiteSpace(model.StaticURL))
                {
                    Links[StoreLinkType.Static].URL = new Uri(model.StaticURL);
                }

                if (!String.IsNullOrWhiteSpace(model.SecureURL))
                {
                    Links[StoreLinkType.SecureStore].URL = new Uri(model.SecureURL);
                }

                if (!String.IsNullOrWhiteSpace(model.SecureLinkURL))
                {
                    Links[StoreLinkType.SecureLink].URL = new Uri(model.SecureLinkURL);
                }

                if (!String.IsNullOrWhiteSpace(model.SecureMediaURL))
                {
                    Links[StoreLinkType.SecureMedia].URL = new Uri(model.SecureMediaURL);
                }

                if (!String.IsNullOrWhiteSpace(model.SecureStaticURL))
                {
                    Links[StoreLinkType.SecureStatic].URL = new Uri(model.SecureStaticURL);
                }
            }
        }
    }
}
