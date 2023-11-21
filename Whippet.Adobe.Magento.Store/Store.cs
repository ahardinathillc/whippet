using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a Magento store.
    /// </summary>
    public class Store : MagentoRestEntity<StoreInterface>, IMagentoEntity, IStore, IEqualityComparer<IStore>, IMagentoRestEntity, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Store"/> website.
        /// </summary>
        public virtual StoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> website.
        /// </summary>
        IStoreWebsite IStore.Website
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
        /// Gets or sets the <see cref="Store"/> group.
        /// </summary>
        public virtual StoreGroup Group
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> group.
        /// </summary>
        IStoreGroup IStore.Group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value.ToStoreGroup();
            }
        }
        
        /// <summary>
        /// Specifies whether the current entity is active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class with no arguments.
        /// </summary>
        public Store()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Store(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Store(StoreInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IStore)) ? false : Equals((IStore)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStore obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStore x, IStore y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                         && x.Active == y.Active
                         && (((x.Website == null) && (y.Website == null)) || (x.Website != null && x.Website.Equals(y.Website)))
                         && (((x.Group == null) && (y.Group == null)) || (x.Group != null && x.Group.Equals(y.Group)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="StoreInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="StoreInterface"/>.</returns>
        public override StoreInterface ToInterface()
        {
            StoreInterface storeInterface = new StoreInterface();

            storeInterface.Active = ConvertBooleanToFlag(Active);
            storeInterface.Code = Code;
            storeInterface.ExtensionAttributes = new StoreExtensionInterface();
            storeInterface.ID = ID;
            storeInterface.Name = Name;

            if (Group != null)
            {
                storeInterface.StoreGroupID = Group.ID;
            }

            if (Website != null)
            {
                storeInterface.WebsiteID = Website.ID;
            }

            return storeInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Store store = new Store();

            store.Active = Active;
            store.Code = Code;
            store.Group = (Group == null) ? null : Group.Clone<StoreGroup>();
            store.ID = ID;
            store.Name = Name;
            store.Website = (Website == null) ? null : Website.Clone<StoreWebsite>();
            store.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            store.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return store;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(Active);
            hash.Add(Code);
            hash.Add(Group);
            hash.Add(ID);
            hash.Add(Name);
            hash.Add(Website);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(StoreInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Active = ConvertFlagToBoolean(model.Active);
                Code = model.Code;
                Group = new StoreGroup(Convert.ToUInt32(model.StoreGroupID));
                Name = model.Name;
                Website = new StoreWebsite(Convert.ToUInt32(model.WebsiteID));
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="store"><see cref="IStore"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStore store)
        {
            ArgumentNullException.ThrowIfNull(store);
            return store.GetHashCode();
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
