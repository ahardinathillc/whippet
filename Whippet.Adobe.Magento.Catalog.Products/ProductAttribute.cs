using System;
using System.Formats.Tar;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a <see cref="Product"/> attribute.
    /// </summary>
    public class ProductAttribute : MagentoRestEntity<ProductAttributeInterface>, IMagentoEntity, IProductAttribute, IEqualityComparer<IProductAttribute>, IMagentoCustomAttributesEntity, IMagentoRestEntity, IMagentoRestEntity<ProductAttributeInterface>
    {
        private MagentoCustomAttributeCollection _attribs;
        
        /// <summary>
        /// Specifies whether the attribute is enabled for Magento's page builder.
        /// </summary>
        public virtual bool PageBuilderEnabled
        { get; set; }
        
        /// <summary>
        /// Specifies whether What You See Is What You Get (WYSIWYG) is enabled.
        /// </summary>
        public virtual bool WYSIWYG
        { get; set; }
        
        /// <summary>
        /// Specifies whether HTML is allowed on the frontend.
        /// </summary>
        public virtual bool AllowHTML
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used for sorting.
        /// </summary>
        public virtual bool UsedForSortBy
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in layered navigation.
        /// </summary>
        public virtual bool Filterable
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in search results layered navigation.
        /// </summary>
        public virtual bool FilterableInSearch
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in the catalog product grid.
        /// </summary>
        public virtual bool UsedInGrid
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is filterable in the catalog product grid.
        /// </summary>
        public virtual bool FilterableInGrid
        { get; set; }

        /// <summary>
        /// Gets or sets the position of the attribute.
        /// </summary>
        public virtual int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the "apply to" value of the element.
        /// </summary>
        public virtual IEnumerable<string> ApplyTo
        { get; set; }

        /// <summary>
        /// Indicates whether the attribute can be used in Quick Search.
        /// </summary>
        public virtual bool IsSearchable
        { get; set; }

        /// <summary>
        /// Indicates whether the attribute can be used in Advanced Search.
        /// </summary>
        public virtual bool IsVisibleInAdvancedSearch
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be compared on the frontend.
        /// </summary>
        public virtual bool IsComparable
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be used for promo rules. 
        /// </summary>
        public virtual bool UsedForPromoRules
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is visible on the frontend.
        /// </summary>
        public virtual bool VisibleOnFront
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be used in the product listing.
        /// </summary>
        public virtual bool UsedInProductListing
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute scope.
        /// </summary>
        public virtual string Scope
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the HTML for the attribute's input element.
        /// </summary>
        public virtual string FrontendInput
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type's ID.
        /// </summary>
        public virtual string EntityTypeID
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is required.
        /// </summary>
        public virtual bool IsRequired
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute options.
        /// </summary>
        public virtual IEnumerable<AttributeOption> Options
        { get; set; }

        /// <summary>
        /// Specifies whether the current attribute is defined by a user.
        /// </summary>
        public virtual bool IsUserDefined
        { get; set; }

        /// <summary>
        /// Gets or sets the default frontend label for the default store.
        /// </summary>
        public virtual string DefaultFrontendLabel
        { get; set; }

        /// <summary>
        /// Gets or sets the frontend label for each store.
        /// </summary>
        public virtual IEnumerable<AttributeFrontendLabel> FrontendLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the note attribute of the element.
        /// </summary>
        public virtual string Note
        { get; set; }

        /// <summary>
        /// Gets or sets the backend type.
        /// </summary>
        public virtual string BackendType
        { get; set; }

        /// <summary>
        /// Gets or sets the backend model.
        /// </summary>
        public virtual string BackendModel
        { get; set; }

        /// <summary>
        /// Gets or sets the source model.
        /// </summary>
        public virtual string SourceModel
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is unique.
        /// </summary>
        public virtual bool IsUnique
        { get; set; }

        /// <summary>
        /// Gets or sets the frontend class of the attribute.
        /// </summary>
        public virtual string FrontendClass
        { get; set; }

        /// <summary>
        /// Gets or sets the validation rules of the attribute.
        /// </summary>
        public virtual IEnumerable<AttributeValidationRule> ValidationRules
        { get; set; }

        /// <summary>
        /// Gets the entity's <see cref="MagentoCustomAttributeCollection"/> that contains all <see cref="MagentoCustomAttribute"/> entries. This property is read-only.
        /// </summary>
        public virtual MagentoCustomAttributeCollection CustomAttributes
        {
            get
            {
                if (_attribs == null)
                {
                    _attribs = new MagentoCustomAttributeCollection();
                }

                return _attribs;
            }
            protected internal set
            {
                _attribs = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAttribute"/> class with no arguments.
        /// </summary>
        public ProductAttribute()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAttribute"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductAttribute(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAttribute"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductAttribute(ProductAttributeInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IProductAttribute)) ? false : Equals((IProductAttribute)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductAttribute obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductAttribute x, IProductAttribute y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.PageBuilderEnabled == y.PageBuilderEnabled 
                            && x.WYSIWYG == y.WYSIWYG
                            && x.AllowHTML == y.AllowHTML
                            && x.UsedForSortBy == y.UsedForSortBy
                            && x.Filterable == y.Filterable
                            && x.FilterableInSearch == y.FilterableInSearch
                            && x.UsedInGrid == y.UsedInGrid
                            && x.FilterableInGrid == y.FilterableInGrid
                            && x.Position == y.Position
                            && (((x.ApplyTo == null) && (y.ApplyTo == null)) || ((x.ApplyTo != null) && x.ApplyTo.SequenceEqual(y.ApplyTo)))
                            && x.IsSearchable == y.IsSearchable
                            && x.IsVisibleInAdvancedSearch == y.IsVisibleInAdvancedSearch
                            && x.IsComparable == y.IsComparable
                            && x.UsedForPromoRules == y.UsedForPromoRules
                            && x.VisibleOnFront == y.VisibleOnFront
                            && x.UsedInProductListing == y.UsedInProductListing
                            && String.Equals(x.Scope?.Trim(), y.Scope?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.FrontendInput?.Trim(), y.FrontendInput?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.EntityTypeID?.Trim(), y.EntityTypeID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && x.IsRequired == y.IsRequired
                            && (((x.Options == null) && (y.Options == null)) || ((x.Options != null) && x.Options.SequenceEqual(y.Options)))
                            && x.IsUserDefined == y.IsUserDefined
                            && String.Equals(x.DefaultFrontendLabel?.Trim(), y.DefaultFrontendLabel?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && (((x.FrontendLabels == null) && (y.FrontendLabels == null)) || ((x.FrontendLabels != null) && x.FrontendLabels.SequenceEqual(y.FrontendLabels)))
                            && String.Equals(x.Note?.Trim(), y.Note?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.BackendType?.Trim(), y.BackendType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.BackendModel?.Trim(), y.BackendModel?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.SourceModel?.Trim(), y.SourceModel?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && x.IsUnique == y.IsUnique
                            && String.Equals(x.FrontendClass?.Trim(), y.FrontendClass?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && (((x.ValidationRules == null) && (y.ValidationRules == null)) || ((x.ValidationRules != null) && x.ValidationRules.SequenceEqual(y.ValidationRules)))
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.CustomAttributes == null) && (y.CustomAttributes == null)) || ((x.CustomAttributes != null) && x.CustomAttributes.Equals(y.CustomAttributes)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductAttributeInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductAttributeInterface"/>.</returns>
        public override ProductAttributeInterface ToInterface()
        {
            ProductAttributeInterface attribInterface = new ProductAttributeInterface();
            attribInterface.ExtensionAttributes = new AttributeExtensionInterface(PageBuilderEnabled);
            attribInterface.WYSIWYG = WYSIWYG;
            attribInterface.AllowHTML = AllowHTML;
            attribInterface.UsedForSortBy = UsedForSortBy;
            attribInterface.Filterable = Filterable;
            attribInterface.FilterableInSearch = FilterableInSearch;
            attribInterface.UsedInGrid = UsedInGrid;
            attribInterface.FilterableInGrid = FilterableInGrid;
            attribInterface.Position = Position;
            attribInterface.ApplyTo = (ApplyTo == null) ? null : ApplyTo.ToArray();
            attribInterface.IsSearchable = IsSearchable.ToString();
            attribInterface.IsVisibleInAdvancedSearch = IsVisibleInAdvancedSearch.ToString();
            attribInterface.IsComparable = IsComparable.ToString();
            attribInterface.UsedForPromoRules = UsedForPromoRules.ToString();
            attribInterface.VisibleOnFront = VisibleOnFront.ToString();
            attribInterface.UsedInProductListing = UsedInProductListing.ToString();
            attribInterface.Scope = Scope;
            attribInterface.ID = ID;
            attribInterface.Code = Code;
            attribInterface.FrontendInput = FrontendInput;
            attribInterface.EntityTypeID = EntityTypeID;
            attribInterface.IsRequired = IsRequired;
            attribInterface.Options = (Options == null) ? null : Options.Select(o => o.ToInterface()).ToArray();
            attribInterface.IsUserDefined = IsUserDefined;
            attribInterface.DefaultFrontendLabel = DefaultFrontendLabel;
            attribInterface.FrontendLabels = (FrontendLabels == null) ? null : FrontendLabels.Select(fl => fl.ToInterface()).ToArray();
            attribInterface.Note = Note;
            attribInterface.BackendType = BackendType;
            attribInterface.BackendModel = BackendModel;
            attribInterface.SourceModel = SourceModel;
            attribInterface.IsUnique = IsUnique.ToString();
            attribInterface.FrontendClass = FrontendClass;
            attribInterface.ValidationRules = (ValidationRules == null) ? null : ValidationRules.Select(vr => vr.ToInterface()).ToArray();
            attribInterface.CustomAttributes = CustomAttributes.ToInterfaceArray();
            
            return attribInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            ProductAttribute attribute = new ProductAttribute();

            attribute.PageBuilderEnabled = PageBuilderEnabled;
            attribute.WYSIWYG = WYSIWYG;
            attribute.AllowHTML = AllowHTML;
            attribute.UsedForSortBy = UsedForSortBy;
            attribute.Filterable = Filterable;
            attribute.FilterableInSearch = FilterableInSearch;
            attribute.FilterableInGrid = FilterableInGrid;
            attribute.UsedInGrid = UsedInGrid;
            attribute.Position = Position;
            attribute.ApplyTo = (ApplyTo == null) ? null : ApplyTo.ToArray();
            attribute.IsSearchable = IsSearchable;
            attribute.IsVisibleInAdvancedSearch = IsVisibleInAdvancedSearch;
            attribute.IsComparable = IsComparable;
            attribute.UsedForPromoRules = UsedForPromoRules;
            attribute.VisibleOnFront = VisibleOnFront;
            attribute.UsedInProductListing = UsedInProductListing;
            attribute.Scope = Scope;
            attribute.Code = Code;
            attribute.FrontendInput = FrontendInput;
            attribute.EntityTypeID = EntityTypeID;
            attribute.IsRequired = IsRequired;
            attribute.Options = (Options == null) ? null : Options.ToArray();
            attribute.IsUserDefined = IsUserDefined;
            attribute.DefaultFrontendLabel = DefaultFrontendLabel;
            attribute.FrontendLabels = (FrontendLabels == null) ? null : FrontendLabels.ToArray();
            attribute.Note = Note;
            attribute.BackendType = BackendType;
            attribute.BackendModel = BackendModel;
            attribute.SourceModel = SourceModel;
            attribute.IsUnique = IsUnique;
            attribute.FrontendClass = FrontendClass;
            attribute.ValidationRules = (ValidationRules == null) ? null : ValidationRules.ToArray();
            
            return attribute;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(PageBuilderEnabled);
            hash.Add(WYSIWYG);
            hash.Add(AllowHTML);
            hash.Add(UsedForSortBy);
            hash.Add(Filterable);
            hash.Add(FilterableInSearch);
            hash.Add(UsedInGrid);
            hash.Add(FilterableInGrid);
            hash.Add(Position);
            hash.Add(ApplyTo);
            hash.Add(IsSearchable);
            hash.Add(IsVisibleInAdvancedSearch);
            hash.Add(IsComparable);
            hash.Add(UsedForPromoRules);
            hash.Add(VisibleOnFront);
            hash.Add(UsedInProductListing);
            hash.Add(Scope);
            hash.Add(Code);
            hash.Add(FrontendInput);
            hash.Add(EntityTypeID);
            hash.Add(IsRequired);
            hash.Add(Options);
            hash.Add(IsUserDefined);
            hash.Add(DefaultFrontendLabel);
            hash.Add(FrontendLabels);
            hash.Add(Note);
            hash.Add(BackendType);
            hash.Add(BackendModel);
            hash.Add(SourceModel);
            hash.Add(IsUnique);
            hash.Add(FrontendClass);
            hash.Add(ValidationRules);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(ProductAttributeInterface model)
        {
            if (model != null)
            {
                PageBuilderEnabled = (model.ExtensionAttributes == null) ? default(bool) : model.ExtensionAttributes.PageBuilderEnabled;
                WYSIWYG = model.WYSIWYG;
                AllowHTML = model.AllowHTML;
                UsedForSortBy = model.UsedForSortBy;
                Filterable = model.Filterable;
                FilterableInSearch = model.FilterableInSearch;
                UsedInGrid = model.UsedInGrid;
                FilterableInGrid = model.FilterableInGrid;
                Position = model.Position;
                ApplyTo = model.ApplyTo;
                IsSearchable = model.IsSearchable.FromMagentoBoolean();
                IsVisibleInAdvancedSearch = model.IsVisibleInAdvancedSearch.FromMagentoBoolean();
                IsComparable = model.IsComparable.FromMagentoBoolean();
                UsedForPromoRules = model.UsedForPromoRules.FromMagentoBoolean();
                VisibleOnFront = model.VisibleOnFront.FromMagentoBoolean();
                UsedInProductListing = model.UsedInProductListing.FromMagentoBoolean();
                Scope = model.Scope;
                Code = model.Code;
                FrontendInput = model.FrontendInput;
                EntityTypeID = model.EntityTypeID;
                IsRequired = model.IsRequired;
                Options = (model.Options == null) ? null : model.Options.Select(o => new AttributeOption(o));
                IsUserDefined = model.IsUserDefined;
                DefaultFrontendLabel = model.DefaultFrontendLabel;
                FrontendLabels = (model.FrontendLabels == null) ? null : model.FrontendLabels.Select(l => new AttributeFrontendLabel());
                Note = model.Note;
                BackendType = model.BackendType;
                BackendModel = model.BackendModel;
                SourceModel = model.SourceModel;
                IsUnique = model.IsUnique.FromMagentoBoolean();
                FrontendClass = model.FrontendClass;
                ValidationRules = (model.ValidationRules == null) ? null : model.ValidationRules.Select(vr => new AttributeValidationRule());

                if (model.CustomAttributes != null)
                {
                    CustomAttributes = new MagentoCustomAttributeCollection(model.CustomAttributes.Select(c => new KeyValuePair<string, string>(c.AttributeCode, c.Value)));
                }
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="attribute"><see cref="IProductAttribute"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IProductAttribute attribute)
        {
            ArgumentNullException.ThrowIfNull(attribute);
            return attribute.GetHashCode();
        }
    }
}
