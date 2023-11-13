using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents the third customer categorization type in M.O.M.
    /// </summary>
    public interface IMultichannelOrderManagerCustomerType__Three : IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerEntity
    {
        /// <summary>
        /// Two-character (or digit) code that represents the customer type.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string CustomerType
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
