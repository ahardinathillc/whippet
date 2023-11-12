using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a customer relationship in the Multichannel Order Manager (M.O.M.) database.
    /// </summary>
    public interface IMultichannelOrderManagerCustomerRelationship : IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerCustomerRelationship>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper
    {
        /// <summary>
        /// Gets or sets the unique ID of the relationship.
        /// </summary>
        long RelationshipId
        { get; set; }

        /// <summary>
        /// Gets or sets the parent ID of the <see cref="IMultichannelOrderManagerCustomer"/> object.
        /// </summary>
        long ParentCustomerId
        { get; set; }

        /// <summary>
        /// Gets or sets the child ID of the <see cref="IMultichannelOrderManagerCustomer"/> object.
        /// </summary>
        long ChildCustomerId
        { get; set; }

        /// <summary>
        /// Specifies the relationship type.
        /// </summary>
        MultichannelOrderManagerCustomerRelationshipType RelationshipType
        { get; set; }

        /// <summary>
        /// Gets or sets the description of the relationship.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Description
        { get; set; }
    }
}