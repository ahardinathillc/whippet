using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides payment information for a Magento sales order.
    /// </summary>
    public class SalesOrderPaymentInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        [JsonProperty("account_status")]
        public string AccountStatus
        { get; set; }

        /// <summary>
        /// Gets or sets additional data about the payment.
        /// </summary>
        [JsonProperty("additional_data")]
        public string AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets additional information about the payment.
        /// </summary>
        [JsonProperty("additional_information")]
        public string[] AdditionalInformation
        { get; set; }

        /// <summary>
        /// Gets or sets the address status.
        /// </summary>
        [JsonProperty("address_status")]
        public string AddressStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized.
        /// </summary>
        [JsonProperty("amount_authorized")]
        public decimal AmountAuthorized
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled.
        /// </summary>
        [JsonProperty("amount_canceled")]
        public decimal AmountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered.
        /// </summary>
        [JsonProperty("amount_ordered")]
        public decimal AmountOrdered
        { get; set; }

        //TODO: working on https://adobe-commerce.redoc.ly/2.4.6-admin/tag/ordersid/#operation/GetV1OrdersId
    }
}
