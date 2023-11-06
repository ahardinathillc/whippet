using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents the first customer categorization type in M.O.M.
    /// </summary>
    public interface IMultichannelOrderManagerCustomerType__One : IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerEntity
    {
        /// <summary>
        /// Single-character (or digit) code that represents the customer type.
        /// </summary>
        char CustomerType
        { get; set; }

        /// <summary>
        /// Description of the customer type.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Specifies the M.O.M. type ID of the type.
        /// </summary>
        long TypeId
        { get; set; }
    }
}

