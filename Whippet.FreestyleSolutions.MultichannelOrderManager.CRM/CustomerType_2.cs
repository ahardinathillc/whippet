using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM
{
    /// <summary>
    /// Represents a Multichannel Order Manager customer type.
    /// </summary>
    public class CustomerType_2 : CustomerType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with no arguments.
        /// </summary>
        public CustomerType_2()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the customer type.</param>
        public CustomerType_2(int id)
            : base(new MultichannelOrderManagerEntityKey<int>(id))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the customer type.</param>
        /// <param name="description">Type description.</param>
        /// <param name="type">Type code.</param>
        public CustomerType_2(int id, string description, string type)
            : base(new MultichannelOrderManagerEntityKey<int>(id), description, type)
        { }        
    }
}
