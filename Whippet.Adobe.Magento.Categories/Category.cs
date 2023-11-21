using System;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Categories.Extensions;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Provides support for organizing products in a Magento store.
    /// </summary>
    public class Category : MagentoRestEntity<CategoryInterface>, IMagentoEntity, ICategory, IEqualityComparer<ICategory>, IWhippetActiveEntity, IMagentoAuditableEntity, IMagentoCustomAttributesEntity
    {
        private CategoryCollection _children;
        private MagentoCustomAttributeCollection _attributes;
        
        /// <summary>
        /// Gets or sets the parent <see cref="Category"/> (if any).
        /// </summary>
        public virtual Category Parent
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="ICategory"/>.
        /// </summary>
        ICategory ICategory.Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value.ToCategory();
            }
        }

        /// <summary>
        /// Indicates whether the current <see cref="IWhippetEntity"/> is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the category position.
        /// </summary>
        public virtual int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the category level.
        /// </summary>
        public virtual int Level
        { get; set; }

        /// <summary>
        /// Gets a collection of all child <see cref="ICategory"/> objects of the current instance. This property is read-only. 
        /// </summary>
        public virtual CategoryCollection Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new CategoryCollection();
                }

                return _children;
            }
            protected internal set
            {
                _children = value;
            }
        }

        /// <summary>
        /// Gets or sets the full path of the category.
        /// </summary>
        public virtual string Path
        { get; set; }

        /// <summary>
        /// Gets or sets the available values that the <see cref="ICategory"/> can be sorted by.
        /// </summary>
        public virtual IEnumerable<string> SortByValues
        { get; set; }

        /// <summary>
        /// Specifies whether the category should be included in the menu.
        /// </summary>
        public virtual bool IncludeInMenu
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
        /// Initializes a new instance of the <see cref="Category"/> class with no arguments.
        /// </summary>
        public Category()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Category(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Category(CategoryInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(default(uint), server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICategory)) ? false : Equals((ICategory)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICategory obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICategory x, ICategory y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.IncludeInMenu == y.IncludeInMenu
                             && (((x.Children == null) && (y.Children == null)) || ((x.Children != null) && x.Children.Equals(y.Children)))
                             && (((x.SortByValues == null) && (y.SortByValues == null)) || (((x.SortByValues != null) && (y.SortByValues != null)) && (x.SortByValues.Count() == y.SortByValues.Count()) && x.SortByValues.SequenceEqual(y.SortByValues, StringComparer.InvariantCultureIgnoreCase)))
                             && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                             && Equals(x.Parent, y.Parent)
                             && x.Active == y.Active
                             && x.Level == y.Level
                             && String.Equals(x.Path, y.Path, StringComparison.InvariantCultureIgnoreCase)
                             && x.Position == y.Position
                             && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                             && x.CreatedTimestamp.Equals(y.CreatedTimestamp)
                             && (((x.CustomAttributes == null) && (y.CustomAttributes == null)) || ((x.CustomAttributes != null) && x.CustomAttributes.Equals(y.CustomAttributes)))
                             && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CategoryInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CategoryInterface"/>.</returns>
        public override CategoryInterface ToInterface()
        {
            CategoryInterface catInterface = new CategoryInterface();
            catInterface.Children = Children.ToString(true);
            catInterface.Active = Active;
            catInterface.Position = Position;
            catInterface.ID = ID;
            catInterface.IncludeInMenu = IncludeInMenu;
            catInterface.Level = Level;
            catInterface.Name = Name;
            catInterface.Path = Path;
            catInterface.CreatedAt = CreatedTimestamp.ToDateTimeUtc().ToString();

            if (UpdatedTimestamp.HasValue)
            {
                catInterface.UpdatedAt = UpdatedTimestamp.Value.ToDateTimeUtc().ToString();
            }

            catInterface.CustomAttributes = CustomAttributes.ToInterfaceArray();
            catInterface.ExtensionAttributes = new CategoryExtensionInterface();
            catInterface.AvailableSortBy = (SortByValues == null) ? null : SortByValues.ToArray();
            
            return catInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Category category = new Category();

            category.ID = ID;
            category.SortByValues = new List<string>(SortByValues);
            category.Parent = (Parent == null) ? null : Parent.Clone<Category>();
            category.CustomAttributes = new MagentoCustomAttributeCollection(CustomAttributes);
            category.Active = Active;
            category.Children = ((Children == null) || (Children.Count == 0)) ? null : new CategoryCollection(Children);
            category.Level = Level;
            category.Name = Name;
            category.Path = Path;
            category.Position = Position;
            category.CreatedTimestamp = CreatedTimestamp;
            category.UpdatedTimestamp = UpdatedTimestamp;
            category.IncludeInMenu = IncludeInMenu;
            category.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            category.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return category;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);

            if (Parent != null)
            {
                hash.Add(Parent);
            }

            hash.Add(Name);
            hash.Add(Position);
            hash.Add(Level);
            hash.Add(Children);
            hash.Add(Path);
            hash.Add(SortByValues);
            hash.Add(IncludeInMenu);
            hash.Add(CustomAttributes);
            hash.Add(Active);
            hash.Add(CreatedTimestamp);
            hash.Add(UpdatedTimestamp.GetValueOrDefault());
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CategoryInterface model)
        {
            string[] pieces = null;
            
            if (model != null)
            {
                ID = model.ID;
                Parent = new Category(Convert.ToUInt32(model.ID));
                Name = model.Name;
                Position = model.Position;
                Level = model.Level;

                if (!String.IsNullOrWhiteSpace(model.Children))
                {
                    pieces = model.Children.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    if (pieces != null && pieces.Length > 0)
                    {
                        Children.AddRange(pieces.Select(p => new Category(Convert.ToUInt32(p))));
                    }
                }

                Path = model.Path;
                SortByValues = model.AvailableSortBy;
                IncludeInMenu = model.IncludeInMenu;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="category"><see cref="ICategory"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICategory category)
        {
            ArgumentNullException.ThrowIfNull(category);
            return category.GetHashCode();
        }
    }
}
