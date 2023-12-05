using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Interface that provides company attributes to sales orders in Magento.
    /// </summary>
    public class CompanyOrderInterface : IExtensionInterface, IExtensionAttributes<CompanyOrderExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the company's status code.
        /// </summary>
        public virtual int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public virtual string CompanyName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's legal name.
        /// </summary>
        public virtual string LegalName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's e-mail address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the company's Value Added Tax (VAT) number.
        /// </summary>
        public virtual string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the company's reseller ID.
        /// </summary>
        public virtual string ResellerID
        { get; set; }

        /// <summary>
        /// Gets or sets the comment for the company account.
        /// </summary>
        public virtual string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the company's address.
        /// </summary>
        public virtual IEnumerable<string> Street
        { get; set; }
        
        /// <summary>
        /// Gets or sets the city portion of the company's address.
        /// </summary>
        public virtual string City
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country portion of the company's address.
        /// </summary>
        ICountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the region of the company's address.
        /// </summary>
        IRegion Region
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the company's address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number associated with the company's address.
        /// </summary>
        public virtual string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group of the company.
        /// </summary>
        ICustomerGroup Group
        { get; set; }

        /// <summary>
        /// Gets or sets the sales representative of the company.
        /// </summary>
        ICustomer SalesRepresentative
        { get; set; }

        /// <summary>
        /// Gets or sets the reject reason for the company.
        /// </summary>
        public virtual string RejectReason
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the company was rejected.
        /// </summary>
        public virtual Instant? RejectedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the company's administrator user.
        /// </summary>
        ICustomer Administrator
        { get; set; }

        /// <summary>
        /// Gets or sets the applicable payment method ID.
        /// </summary>
        public virtual int ApplicablePaymentMethodID
        { get; set; }
        
        /// <summary>
        /// Gets or sets a list of available payment methods.
        /// </summary>
        public virtual IEnumerable<string> AvailablePaymentMethods
        { get; set; }

        /// <summary>
        /// Specifies whether the Magento configuration settings should be used instead of custom values.
        /// </summary>
        public virtual bool UseConfigurationSettings
        { get; set; }

        /// <summary>
        /// Specifies whether quotes are enabled for the company.
        /// </summary>
        public virtual bool QuotesEnabled
        { get; set; }

        /// <summary>
        /// Specifies whether purchase orders are enabled for the company.
        /// </summary>
        public virtual bool PurchaseOrdersEnabled
        { get; set; }

        /// <summary>
        /// Gets or sets the applicable shipping method ID.
        /// </summary>
        public virtual int ApplicableShippingMethodID
        { get; set; }

        /// <summary>
        /// Gets or sets the available shipping methods.
        /// </summary>
        public virtual IEnumerable<string> AvailableShippingMethods
        { get; set; }

        /// <summary>
        /// Specifies whether the Magento configuration settings should be used instead of custom values for shipping.
        /// </summary>
        public virtual bool UseShippingConfigurationSettings
        { get; set; }
    }
}
