using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Customer;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Represents a company (or reseller) account in Magento.
    /// </summary>
    public interface ICompany : IMagentoEntity, IEqualityComparer<ICompany>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the company's status code.
        /// </summary>
        int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        string CompanyName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's legal name.
        /// </summary>
        string LegalName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's e-mail address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the company's Value Added Tax (VAT) number.
        /// </summary>
        string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the company's reseller ID.
        /// </summary>
        string ResellerID
        { get; set; }

        /// <summary>
        /// Gets or sets the comment for the company account.
        /// </summary>
        string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the company's address.
        /// </summary>
        IEnumerable<string> Street
        { get; set; }
        
        /// <summary>
        /// Gets or sets the city portion of the company's address.
        /// </summary>
        string City
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
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number associated with the company's address.
        /// </summary>
        string Telephone
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
        string RejectReason
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the company was rejected.
        /// </summary>
        Instant? RejectedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the company's administrator user.
        /// </summary>
        ICustomer Administrator
        { get; set; }

        /// <summary>
        /// Gets or sets the applicable payment method ID.
        /// </summary>
        int ApplicablePaymentMethodID
        { get; set; }
        
        /// <summary>
        /// Gets or sets a list of available payment methods.
        /// </summary>
        IEnumerable<string> AvailablePaymentMethods
        { get; set; }

        /// <summary>
        /// Specifies whether the Magento configuration settings should be used instead of custom values.
        /// </summary>
        bool UseConfigurationSettings
        { get; set; }

        /// <summary>
        /// Specifies whether quotes are enabled for the company.
        /// </summary>
        bool QuotesEnabled
        { get; set; }

        /// <summary>
        /// Specifies whether purchase orders are enabled for the company.
        /// </summary>
        bool PurchaseOrdersEnabled
        { get; set; }

        /// <summary>
        /// Gets or sets the applicable shipping method ID.
        /// </summary>
        int ApplicableShippingMethodID
        { get; set; }

        /// <summary>
        /// Gets or sets the available shipping methods.
        /// </summary>
        IEnumerable<string> AvailableShippingMethods
        { get; set; }

        /// <summary>
        /// Specifies whether the Magento configuration settings should be used instead of custom values for shipping.
        /// </summary>
        bool UseShippingConfigurationSettings
        { get; set; }
    }
}
