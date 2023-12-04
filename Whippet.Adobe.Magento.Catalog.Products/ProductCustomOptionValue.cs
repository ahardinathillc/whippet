using System;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Provides information about a custom <see cref="IProduct"/> option type.
    /// </summary>
    public struct ProductCustomOptionValue : IEqualityComparer<ProductCustomOptionValue>, IExtensionInterfaceMap<ProductCustomOptionValueInterface>
    {
        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the price of the option.
        /// </summary>
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the price type of the option.
        /// </summary>
        public string PriceType
        { get; set; }

        /// <summary>
        /// Gets or sets the SKU of the parent option.
        /// </summary>
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the option type. 
        /// </summary>
        public int TypeID
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionValue"/> struct with no arguments.
        /// </summary>
        static ProductCustomOptionValue()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionValue"/> struct with no arguments. 
        /// </summary>
        public ProductCustomOptionValue()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionValue"/> struct with the specified parameters. 
        /// </summary>
        /// <param name="typeId">Option type ID.</param>
        /// <param name="title">Option value title.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="price">Option value price.</param>
        /// <param name="priceType">Price type.</param>
        /// <param name="sku">Option value SKU.</param>
        public ProductCustomOptionValue(int typeId, string title, int sortOrder, decimal price, string priceType, string sku)
            : this()
        {
            TypeID = typeId;
            Title = title;
            SortOrder = sortOrder;
            Price = price;
            PriceType = priceType;
            SKU = sku;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionValue"/> struct with the specified <see cref="ProductCustomOptionValueInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductCustomOptionValueInterface"/> object to initialize with.</param>
        public ProductCustomOptionValue(ProductCustomOptionValueInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ProductCustomOptionValue)) ? false : Equals((ProductCustomOptionValue)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductCustomOptionValue obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductCustomOptionValue x, ProductCustomOptionValue y)
        {
            return String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.PriceType?.Trim(), y.PriceType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.SortOrder == y.SortOrder
                   && x.Price == y.Price
                   && x.TypeID == y.TypeID;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(TypeID, Price, SortOrder, PriceType, SKU, Title);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ProductCustomOptionValue"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ProductCustomOptionValue obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductCustomOptionValueInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductCustomOptionValueInterface"/>.</returns>
        public ProductCustomOptionValueInterface ToInterface()
        {
            return new ProductCustomOptionValueInterface(Title, SortOrder, Price, PriceType, SKU, TypeID);
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductCustomOptionValueInterface"/> object used to populate the object.</param>
        public void FromModel(ProductCustomOptionValueInterface model)
        {
            if (model != null)
            {
                Title = model.Title;
                SKU = model.SKU;
                PriceType = model.PriceType;
                SortOrder = model.SortOrder;
                Price = model.Price;
                TypeID = model.OptionTypeID;
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Title) ? base.ToString() : Title + " [" + Price + "]";
        }
        
    }
}
