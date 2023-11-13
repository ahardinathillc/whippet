using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides a converter for <see cref="IMultichannelOrderManagerCounty"/> objects.
    /// </summary>
    public class MultichannelOrderManagerCountyCreationConverter : CustomCreationConverter<IMultichannelOrderManagerCounty>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountyCreationConverter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerCountyCreationConverter()
            : base()
        { }

        /// <summary>
        /// Creates an instance of <see cref="IMultichannelOrderManagerCounty"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMultichannelOrderManagerCounty"/> object.</returns>
        public override IMultichannelOrderManagerCounty Create(Type objectType)
        {
            return new MultichannelOrderManagerCounty();
        }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMultichannelOrderManagerCounty"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MultichannelOrderManagerCounty testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                try
                {
                    testObj = Activator.CreateInstance(objectType) as MultichannelOrderManagerCounty;   // attempt to cast the instance which determines if it can be converted
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
