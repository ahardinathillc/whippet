using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="MagentoRestEndpoint"/> objects. This class must be inherited.
    /// </summary>
    public class MagentoRestEndpointCommandBase : WhippetCommand, IWhippetCommand, IMagentoRestEndpointCommand
    {
        /// <summary>
        /// Gets the <see cref="MagentoRestEndpoint"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        public MagentoRestEndpoint RestEndpoint
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IMagentoRestEndpoint"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoRestEndpoint IMagentoRestEndpointCommand.RestEndpoint
        {
            get
            {
                return RestEndpoint;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointCommandBase"/> class with no arguments.
        /// </summary>
        protected MagentoRestEndpointCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="endpoint"><see cref="MagentoRestEndpoint"/> instance to create or act upon in the data store.</param>
        protected MagentoRestEndpointCommandBase(MagentoRestEndpoint endpoint)
            : base()
        {
            RestEndpoint = endpoint;
        }
    }
}
