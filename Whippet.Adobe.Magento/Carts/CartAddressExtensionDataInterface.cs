using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.SalesRule;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Provides extra order information for a <see cref="CartAddressInterface"/> object.
    /// </summary>
    public class CartAddressExtensionDataInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the discounts that were applied to the order.
        /// </summary>
        [JsonProperty("discounts")]
        public SalesRuleDiscountInterface[] Discounts
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift registry ID.
        /// </summary>
        [JsonProperty("gift_registry_id")]
        public int GiftRegistryID
        { get; set; }

        /// <summary>
        /// Gets or sets the pickup location code of the order.
        /// </summary>
        [JsonProperty("pickup_location_code")]
        public string PickupLocationCode
        { get; set; }

        /// <summary>
        /// Gets or sets the bolt ID of the order.
        /// </summary>
        public string BoltID
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartAddressExtensionDataInterface"/> class with no arguments. 
        /// </summary>
        public CartAddressExtensionDataInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartAddressExtensionDataInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="discount"><see cref="SalesRuleDiscountInterface"/> that contains discount data to be applied to the order.</param>
        /// <param name="giftRegistryId">Gift registry ID.</param>
        /// <param name="pickupLocationCode">Pickup location code.</param>
        /// <param name="boltId">Bolt ID.</param>
        public CartAddressExtensionDataInterface(SalesRuleDiscountInterface discount, int giftRegistryId, string pickupLocationCode, string boltId)
            : this(discount == null ? null : new[] { discount }, giftRegistryId, pickupLocationCode, boltId)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartAddressExtensionDataInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="discounts"><see cref="SalesRuleDiscountInterface"/> object(s) that contains discount information data to be applied to the order.</param>
        /// <param name="giftRegistryId">Gift registry ID.</param>
        /// <param name="pickupLocationCode">Pickup location code.</param>
        /// <param name="boltId">Bolt ID.</param>
        public CartAddressExtensionDataInterface(IEnumerable<SalesRuleDiscountInterface> discounts, int giftRegistryId, string pickupLocationCode, string boltId)
        {
            Discounts = (discounts == null) ? null : discounts.ToArray();
            GiftRegistryID = giftRegistryId;
            PickupLocationCode = pickupLocationCode;
            BoltID = boltId;
        }
    }
}
