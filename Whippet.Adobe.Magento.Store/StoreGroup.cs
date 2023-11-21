using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Categories;
using Athi.Whippet.Adobe.Magento.Categories.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a logical grouping of Magento stores.
    /// </summary>
    public class StoreGroup : MagentoRestEntity<StoreGroupInterface>, IMagentoEntity, IStoreGroup, IEqualityComparer<IStoreGroup>
    {
        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> that the group belongs to.
        /// </summary>
        public virtual StoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStoreWebsite"/> that the group belongs to.
        /// </summary>
        IStoreWebsite IStoreGroup.Website
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
        /// Gets or sets the group's root category.
        /// </summary>
        public virtual Category RootCategory
        { get; set; }

        /// <summary>
        /// Gets or sets the group's root category.
        /// </summary>
        ICategory IStoreGroup.RootCategory
        {
            get
            {
                return RootCategory;
            }
            set
            {
                RootCategory = value.ToCategory();
            }
        }
        
        /// <summary>
        /// Gets or sets the default store ID.
        /// </summary>
        public virtual int DefaultStoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        public virtual string Code
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroup"/> class with no arguments.
        /// </summary>
        public StoreGroup()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroup"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StoreGroup(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroup"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public StoreGroup(StoreGroupInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IStoreGroup)) ? false : Equals((IStoreGroup)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreGroup obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreGroup x, IStoreGroup y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                         && (((x.RootCategory == null) && (y.RootCategory == null)) || (x.RootCategory != null && x.RootCategory.Equals(y.RootCategory)))
                         && x.DefaultStoreID == y.DefaultStoreID
                         && (((x.Website == null) && (y.Website == null)) || (x.Website != null && x.Website.Equals(y.Website)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="StoreGroupInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="StoreGroupInterface"/>.</returns>
        public override StoreGroupInterface ToInterface()
        {
            StoreGroupInterface groupInterface = new StoreGroupInterface();

            groupInterface.Code = Code;
            groupInterface.DefaultStoreID = DefaultStoreID;
            groupInterface.ExtensionAttributes = new StoreGroupExtensionInterface();
            groupInterface.ID = ID;
            groupInterface.Name = Name;

            if (RootCategory != null)
            {
                groupInterface.RootCategoryID = RootCategory.ID;
            }

            if (Website != null)
            {
                groupInterface.WebsiteID = Website.ID;
            }
            
            return groupInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            StoreGroup group = new StoreGroup();

            group.ID = ID;
            group.Code = Code;
            group.DefaultStoreID = DefaultStoreID;
            group.Name = Name;
            group.RootCategory = (RootCategory == null) ? null : RootCategory.Clone<Category>();
            group.Website = (Website == null) ? null : Website.Clone<StoreWebsite>();
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
            hash.Add(DefaultStoreID);
            hash.Add(Name);
            hash.Add(RootCategory);
            hash.Add(Website);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(StoreGroupInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Code = model.Code;
                DefaultStoreID = model.DefaultStoreID;
                Name = model.Name;
                RootCategory = new Category(Convert.ToUInt32(model.RootCategoryID));
                Website = new StoreWebsite(Convert.ToUInt32(model.WebsiteID));
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="group"><see cref="IStoreGroup"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStoreGroup group)
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
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
    }
}
