using System;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Represents a link type for an <see cref="ICategory"/>. 
    /// </summary>
    public struct CategoryLink : IEqualityComparer<CategoryLink>, IExtensionInterfaceMap<CategoryLinkInterface>
    {
        /// <summary>
        /// Gets or sets the position of the link.
        /// </summary>
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public string CategoryID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryLink"/> class with no arguments.
        /// </summary>
        public CategoryLink()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryLink"/> class with the specified <see cref="CategoryLinkInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="CategoryLinkInterface"/> object.</param>
        public CategoryLink(CategoryLinkInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryLink"/> class with the specified parameters.
        /// </summary>
        /// <param name="position">Position of the link.</param>
        /// <param name="categoryId">Category ID.</param>
        public CategoryLink(int position, string categoryId)
            : this()
        {
            Position = position;
            CategoryID = categoryId;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is CategoryLink)) ? false : Equals((CategoryLink)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CategoryLink obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CategoryLink x, CategoryLink y)
        {
            return String.Equals(x.CategoryID?.Trim(), y.CategoryID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.Position == y.Position;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(CategoryID, Position);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="CategoryLink"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(CategoryLink obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CategoryLinkInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CategoryLinkInterface"/>.</returns>
        public CategoryLinkInterface ToInterface()
        {
            return new CategoryLinkInterface(Position, CategoryID, new CategoryLinkExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="CategoryLinkInterface"/> object used to populate the object.</param>
        public void FromModel(CategoryLinkInterface model)
        {
            if (model != null)
            {
                Position = model.Position;
                CategoryID = model.CategoryID;
            }
        }
    }
}
