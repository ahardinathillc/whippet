using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides a converter for <see cref="IMultichannelOrderManagerStateProvince"/> objects.
    /// </summary>
    public class MultichannelOrderManagerStateProvinceCreationConverter : CustomCreationConverter<IMultichannelOrderManagerStateProvince>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvinceCreationConverter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerStateProvinceCreationConverter()
            : base()
        { }

        /// <summary>
        /// Creates an instance of <see cref="IMultichannelOrderManagerStateProvince"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMultichannelOrderManagerStateProvince"/> object.</returns>
        public override IMultichannelOrderManagerStateProvince Create(Type objectType)
        {
            return new MultichannelOrderManagerStateProvince();
        }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMultichannelOrderManagerStateProvince"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MultichannelOrderManagerStateProvince testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                try
                {
                    testObj = Activator.CreateInstance(objectType) as MultichannelOrderManagerStateProvince;   // attempt to cast the instance which determines if it can be converted
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
