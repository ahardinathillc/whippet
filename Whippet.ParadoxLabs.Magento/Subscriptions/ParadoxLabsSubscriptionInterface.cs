using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions
{
    /// <summary>
    /// Interface that provides information about a Paradox Labs subscription in the Magento e-commerce product.
    /// </summary>
    public class ParadoxLabsSubscriptionInterface : IParadoxLabsExtensionInterface
    {
        /// <summary>
        /// Gets or sets the unique ID of the subscription.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated quote ID taken from the sales order.
        /// </summary>
        [JsonProperty("quote_id")]
        public int QuoteID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the subscription description, typically the product being subscribed to.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID of the Magento customer who subscribes to the subscription.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the subscription was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the subscription was last modified.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the parent store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the next subscription charge.
        /// </summary>
        [JsonProperty("next_run")]
        public string NextRun
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the last subscription charge.
        /// </summary>
        [JsonProperty("last_run")]
        public string LastRun
        { get; set; }

        /// <summary>
        /// Gets or sets the subscription cost subtotal.
        /// </summary>
        [JsonProperty("subtotal")]
        public decimal Subtotal
        { get; set; }

        /// <summary>
        /// Specifies whether the subscription is now expired.
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of runs the subscription should execute. 
        /// </summary>
        [JsonProperty("length")]
        public int Length
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of times the subscription has been ran.
        /// </summary>
        [JsonProperty("run_count")]
        public int RunCount
        { get; set; }

        /// <summary>
        /// Gets or sets the current status of the subscription.
        /// </summary>
        [JsonProperty("status")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the number of times to execute the subscription in relation to its <see cref="FrequencyUnit"/>.
        /// </summary>
        [JsonProperty("frequency_count")]
        public int FrequencyCount
        { get; set; }

        /// <summary>
        /// Gets or sets the interval at which to execute the subscription charge.
        /// </summary>
        [JsonProperty("frequency_unit")]
        public string FrequencyUnit
        { get; set; }

        /// <summary>
        /// Gets or sets additional information about the subscription.
        /// </summary>
        [JsonProperty("additional_information")]
        public string[] AdditionalInformation
        { get; set; }    
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ParadoxLabsSubscriptionInterface"/> class with no arguments.
        /// </summary>
        public ParadoxLabsSubscriptionInterface()
        { }
    }
}
