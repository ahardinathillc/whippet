using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides a converter for <see cref="IMultichannelOrderManagerServer"/> objects.
    /// </summary>
    public class MultichannelOrderManagerServerCreationConverter : CustomCreationConverter<IMultichannelOrderManagerServer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerCreationConverter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerServerCreationConverter()
            : base()
        { }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMultichannelOrderManagerServer"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MultichannelOrderManagerServer testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                // is this an interface type?
                
                try
                {
                    if (objectType.IsAbstract || objectType.IsInterface)
                    {
                        canConvert = true;
                    }
                    else
                    {
                        testObj = Activator.CreateInstance(objectType) as MultichannelOrderManagerServer;   // attempt to cast the instance which determines if it can be converted
                        canConvert = (testObj != null);
                    }
                }
                catch
                {
                    canConvert = false;
                }
            }

            return canConvert;
        }

        /// <summary>
        /// Creates an instance of <see cref="IMultichannelOrderManagerServer"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMultichannelOrderManagerServer"/> object.</returns>
        public override IMultichannelOrderManagerServer Create(Type objectType)
        {
            return new MultichannelOrderManagerServer();
        }
    }
}
