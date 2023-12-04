using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about shipping on a Magento sales order.
    /// </summary>
    public class SalesOrderShippingInterface : IExtensionInterface, IExtensionAttributes<SalesOrderShippingExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the order address.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        [JsonProperty("address")]
        public SalesOrderAddressInterface Address
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        [JsonProperty("method")]
        public string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the order's shipping totals.
        /// </summary>
        [JsonProperty("total")]
        public SalesOrderShippingTotalInterface ShippingTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderShippingExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderShippingInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="address">Order address.</param>
        /// <param name="method">Shipping method.</param>
        /// <param name="shippingTotal">Order's shipping totals.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public SalesOrderShippingInterface(SalesOrderAddressInterface address, string method, SalesOrderShippingTotalInterface shippingTotal, SalesOrderShippingExtensionInterface extensionAttributes)
            : this()
        {
            Address = address;
            Method = method;
            ShippingTotal = shippingTotal;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
