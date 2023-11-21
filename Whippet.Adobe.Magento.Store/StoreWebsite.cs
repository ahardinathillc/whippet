using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a Magento store's front-facing website.
    /// </summary>
    public class StoreWebsite : MagentoRestEntity<StoreWebsiteInterface>, IMagentoEntity, IStoreWebsite, IEqualityComparer<IStoreWebsite>
    {
        /// <summary>
        /// Gets or sets the website code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the default <see cref="StoreGroup"/> that the website is associated with.
        /// </summary>
        public virtual int DefaultGroupID
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsite"/> class with no arguments.
        /// </summary>
        public StoreWebsite()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsite"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StoreWebsite(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsite"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StoreWebsite(StoreWebsiteInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IStoreWebsite)) ? false : Equals((IStoreWebsite)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreWebsite obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreWebsite x, IStoreWebsite y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                         && x.DefaultGroupID == y.DefaultGroupID;
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="StoreWebsiteInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="StoreWebsiteInterface"/>.</returns>
        public override StoreWebsiteInterface ToInterface()
        {
            StoreWebsiteInterface siteInterface = new StoreWebsiteInterface();

            siteInterface.Code = Code;
            siteInterface.Name = Name;
            siteInterface.DefaultGroupID = DefaultGroupID;
            siteInterface.ExtensionAttributes = new StoreWebsiteExtensionInterface();
            siteInterface.ID = ID;

            return siteInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            StoreWebsite website = new StoreWebsite();

            website.Code = Code;
            website.Name = Name;
            website.DefaultGroupID = DefaultGroupID;
            website.ID = ID;
            website.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            website.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return website;
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
            hash.Add(Name);
            hash.Add(DefaultGroupID);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(StoreWebsiteInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Code = model.Code;
                Name = model.Name;
                DefaultGroupID = model.DefaultGroupID;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="website"><see cref="IStoreWebsite"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStoreWebsite website)
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
