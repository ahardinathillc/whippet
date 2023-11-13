using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides a converter for <see cref="IMultichannelOrderManagerWarehouse"/> objects.
    /// </summary>
    public class MultichannelOrderManagerWarehouseCreationConverter : CustomCreationConverter<IMultichannelOrderManagerWarehouse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouseCreationConverter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerWarehouseCreationConverter()
            : base()
        { }

        /// <summary>
        /// Creates an instance of <see cref="IMultichannelOrderManagerWarehouse"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMultichannelOrderManagerWarehouse"/> object.</returns>
        public override IMultichannelOrderManagerWarehouse Create(Type objectType)
        {
            return new MultichannelOrderManagerWarehouse();
        }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMultichannelOrderManagerWarehouse"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MultichannelOrderManagerWarehouse testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                try
                {
                    testObj = Activator.CreateInstance(objectType) as MultichannelOrderManagerWarehouse;   // attempt to cast the instance which determines if it can be converted
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
