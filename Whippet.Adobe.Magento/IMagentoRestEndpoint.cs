using System;
using System.Text;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a single instance of the Magento e-commerce product that is locally or remotely hosted. All <see cref="IMagentoEntity"/> objects reference a single <see cref="IMagentoRestEndpoint"/>.
    /// </summary>
    public interface IMagentoRestEndpoint : IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IMagentoRestEndpoint>, IRestEndpoint, IMagentoServer
    {
        /// <summary>
        /// Gets or sets the unique name of the endpoint profile.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        new string Name
        { get; set; }
    }
}

