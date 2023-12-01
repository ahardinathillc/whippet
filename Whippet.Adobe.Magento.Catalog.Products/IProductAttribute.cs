using System;
using System.Linq;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents an <see cref="IProduct"/> attribute.
    /// </summary>
    public interface IProductAttribute : IMagentoEntity, IEqualityComparer<IProductAttribute>, IMagentoCustomAttributesEntity, IMagentoRestEntity
    {
        /// <summary>
        /// Specifies whether the attribute is enabled for Magento's page builder.
        /// </summary>
        bool PageBuilderEnabled
        { get; set; }
        
        /// <summary>
        /// Specifies whether What You See Is What You Get (WYSIWYG) is enabled.
        /// </summary>
        bool WYSIWYG
        { get; set; }
        
        /// <summary>
        /// Specifies whether HTML is allowed on the frontend.
        /// </summary>
        bool AllowHTML
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used for sorting.
        /// </summary>
        bool UsedForSortBy
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in layered navigation.
        /// </summary>
        bool Filterable
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in search results layered navigation.
        /// </summary>
        bool FilterableInSearch
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in the catalog product grid.
        /// </summary>
        bool UsedInGrid
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is filterable in the catalog product grid.
        /// </summary>
        bool FilterableInGrid
        { get; set; }

        /// <summary>
        /// Gets or sets the position of the attribute.
        /// </summary>
        int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the "apply to" value of the element.
        /// </summary>
        IEnumerable<string> ApplyTo
        { get; set; }

        /// <summary>
        /// Indicates whether the attribute can be used in Quick Search.
        /// </summary>
        bool IsSearchable
        { get; set; }

        /// <summary>
        /// Indicates whether the attribute can be used in Advanced Search.
        /// </summary>
        bool IsVisibleInAdvancedSearch
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be compared on the frontend.
        /// </summary>
        bool IsComparable
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be used for promo rules. 
        /// </summary>
        bool UsedForPromoRules
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is visible on the frontend.
        /// </summary>
        bool VisibleOnFront
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be used in the product listing.
        /// </summary>
        bool UsedInProductListing
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute scope.
        /// </summary>
        string Scope
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the HTML for the attribute's input element.
        /// </summary>
        string FrontendInput
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type's ID.
        /// </summary>
        string EntityTypeID
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is required.
        /// </summary>
        bool IsRequired
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute options.
        /// </summary>
        IEnumerable<AttributeOption> Options
        { get; set; }

        /// <summary>
        /// Specifies whether the current attribute is defined by a user.
        /// </summary>
        bool IsUserDefined
        { get; set; }

        /// <summary>
        /// Gets or sets the default frontend label for the default store.
        /// </summary>
        string DefaultFrontendLabel
        { get; set; }

        /// <summary>
        /// Gets or sets the frontend label for each store.
        /// </summary>
        IEnumerable<AttributeFrontendLabel> FrontendLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the note attribute of the element.
        /// </summary>
        string Note
        { get; set; }

        /// <summary>
        /// Gets or sets the backend type.
        /// </summary>
        string BackendType
        { get; set; }

        /// <summary>
        /// Gets or sets the backend model.
        /// </summary>
        string BackendModel
        { get; set; }

        /// <summary>
        /// Gets or sets the source model.
        /// </summary>
        string SourceModel
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is unique.
        /// </summary>
        bool IsUnique
        { get; set; }

        /// <summary>
        /// Gets or sets the frontend class of the attribute.
        /// </summary>
        string FrontendClass
        { get; set; }

        /// <summary>
        /// Gets or sets the validation rules of the attribute.
        /// </summary>
        IEnumerable<AttributeValidationRule> ValidationRules
        { get; set; }        
    }
}
