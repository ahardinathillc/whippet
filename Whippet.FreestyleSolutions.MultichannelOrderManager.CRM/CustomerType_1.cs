using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM
{
    /// <summary>
    /// Represents a Multichannel Order Manager customer type.
    /// </summary>
    public class CustomerType_1 : CustomerType
    {
        /// <summary>
        /// Gets or sets the customer type code.
        /// </summary>
        public new virtual char Code
        {
            get
            {
                return String.IsNullOrWhiteSpace(base.Code) ? ' ' : Convert.ToChar(base.Code);
            }
            set
            {
                base.Code = Convert.ToString(value);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with no arguments.
        /// </summary>
        public CustomerType_1()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the customer type.</param>
        public CustomerType_1(int id)
            : base(new MultichannelOrderManagerEntityKey<int>(id))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the customer type.</param>
        /// <param name="description">Type description.</param>
        /// <param name="type">Type code.</param>
        public CustomerType_1(int id, string description, string type)
            : base(new MultichannelOrderManagerEntityKey<int>(id), description, type)
        { }        
    }
}
