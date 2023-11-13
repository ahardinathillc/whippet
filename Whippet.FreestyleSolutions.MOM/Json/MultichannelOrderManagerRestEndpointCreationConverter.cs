using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides a converter for <see cref="IMultichannelOrderManagerRestEndpoint"/> objects.
    /// </summary>
    public class MultichannelOrderManagerRestEndpointCreationConverter : CustomCreationConverter<IMultichannelOrderManagerRestEndpoint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointCreationConverter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerRestEndpointCreationConverter()
            : base()
        { }

        /// <summary>
        /// Creates an instance of <see cref="IMultichannelOrderManagerRestEndpoint"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        public override IMultichannelOrderManagerRestEndpoint Create(Type objectType)
        {
            return new MultichannelOrderManagerRestEndpoint();
        }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMultichannelOrderManagerRestEndpoint"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MultichannelOrderManagerRestEndpoint testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                try
                {
                    testObj = Activator.CreateInstance(objectType) as MultichannelOrderManagerRestEndpoint;   // attempt to cast the instance which determines if it can be converted
                    canConvert = (testObj != null);
                }
                catch
                {
                    canConvert = false;
                }
            }

            return canConvert;
        }
    }
}
