using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents a logical grouping for <see cref="Magento.Customer.Customer"/> entities.
    /// </summary>
    public class CustomerGroup : MagentoRestEntity<CustomerGroupInterface>, IMagentoEntity, ICustomerGroup, IEqualityComparer<ICustomerGroup>
    {
        /// <summary>
        /// Gets or sets the customer group code.
        /// </summary>
        public virtual string Code
        { get; set; }
        
        public virtual TaxClass 
    }
}
