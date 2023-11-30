using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides metadata about a Magento product.
    /// </summary>
    public class ProductAttributeInterface : IExtensionInterface, IExtensionAttributes<AttributeExtensionInterface>, ICustomAttributes
    {
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public AttributeExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Specifies whether What You See Is What You Get (WYSIWYG) is enabled.
        /// </summary>
        [JsonProperty("is_wysiwyg_enabled")]
        public bool WYSIWYG
        { get; set; }
        
        /// <summary>
        /// Specifies whether HTML is allowed on the frontend.
        /// </summary>
        [JsonProperty("is_html_allowed_on_front")]
        public bool AllowHTML
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used for sorting.
        /// </summary>
        [JsonProperty("used_for_sort_by")]
        public bool UsedForSortBy
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in layered navigation.
        /// </summary>
        [JsonProperty("is_filterable")]
        public bool Filterable
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in search results layered navigation.
        /// </summary>
        [JsonProperty("is_filterable_in_search")]
        public bool FilterableInSearch
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is used in the catalog product grid.
        /// </summary>
        [JsonProperty("is_used_in_grid")]
        public bool UsedInGrid
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is filterable in the catalog product grid.
        /// </summary>
        [JsonProperty("is_filterable_in_grid")]
        public bool FilterableInGrid
        { get; set; }

        /// <summary>
        /// Gets or sets the position of the attribute.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the "apply to" value of the element.
        /// </summary>
        [JsonProperty("apply_to")]
        public string[] ApplyTo
        { get; set; }

        /// <summary>
        /// Indicates whether the attribute can be used in Quick Search.
        /// </summary>
        [JsonProperty("is_searchable")]
        public string IsSearchable
        { get; set; }

        /// <summary>
        /// Indicates whether the attribute can be used in Advanced Search.
        /// </summary>
        [JsonProperty("is_visible_in_advanced_search")]
        public string IsVisibleInAdvancedSearch
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be compared on the frontend.
        /// </summary>
        [JsonProperty("is_comparable")]
        public string IsComparable
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be used for promo rules. 
        /// </summary>
        [JsonProperty("is_used_for_promo_rules")]
        public string UsedForPromoRules
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is visible on the frontend.
        /// </summary>
        [JsonProperty("is_visible_on_front")]
        public string VisibleOnFront
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute can be used in the product listing.
        /// </summary>
        [JsonProperty("used_in_product_listing")]
        public string UsedInProductListing
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute scope.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute ID.
        /// </summary>
        [JsonProperty("attribute_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute code.
        /// </summary>
        [JsonProperty("attribute_code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the HTML for the attribute's input element.
        /// </summary>
        [JsonProperty("frontend_input")]
        public string FrontendInput
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type's ID.
        /// </summary>
        [JsonProperty("entity_type_id")]
        public string EntityTypeID
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is required.
        /// </summary>
        [JsonProperty("is_required")]
        public bool IsRequired
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute options.
        /// </summary>
        [JsonProperty("options")]
        public AttributeOptionInterface[] Options
        { get; set; }

        /// <summary>
        /// Specifies whether the current attribute is defined by a user.
        /// </summary>
        [JsonProperty("is_user_defined")]
        public bool IsUserDefined
        { get; set; }

        /// <summary>
        /// Gets or sets the default frontend label for the default store.
        /// </summary>
        [JsonProperty("default_frontend_label")]
        public string DefaultFrontendLabel
        { get; set; }

        /// <summary>
        /// Gets or sets the frontend label for each store.
        /// </summary>
        [JsonProperty("frontend_labels")]
        public AttributeFrontendLabelInterface[] FrontendLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the note attribute of the element.
        /// </summary>
        [JsonProperty("note")]
        public string Note
        { get; set; }

        /// <summary>
        /// Gets or sets the backend type.
        /// </summary>
        [JsonProperty("backend_type")]
        public string BackendType
        { get; set; }

        /// <summary>
        /// Gets or sets the backend model.
        /// </summary>
        [JsonProperty("backend_model")]
        public string BackendModel
        { get; set; }

        /// <summary>
        /// Gets or sets the source model.
        /// </summary>
        [JsonProperty("source_model")]
        public string SourceModel
        { get; set; }

        /// <summary>
        /// Specifies whether the attribute is unique.
        /// </summary>
        [JsonProperty("is_unique")]
        public string IsUnique
        { get; set; }

        /// <summary>
        /// Gets or sets the frontend class of the attribute.
        /// </summary>
        [JsonProperty("frontend_class")]
        public string FrontendClass
        { get; set; }

        /// <summary>
        /// Gets or sets the validation rules of the attribute.
        /// </summary>
        [JsonProperty("validation_rules")]
        public AttributeValidationRuleInterface[] ValidationRules
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom attributes of the current instance.
        /// </summary>
        [JsonProperty("custom_attributes")]
        public CustomAttributeInterface[] CustomAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAttributeInterface"/> class with no arguments.
        /// </summary>
        public ProductAttributeInterface()
        { }
    }
}
