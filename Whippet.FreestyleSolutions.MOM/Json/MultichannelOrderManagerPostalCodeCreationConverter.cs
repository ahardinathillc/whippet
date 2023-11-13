using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides a converter for <see cref="IMultichannelOrderManagerPostalCode"/> objects.
    /// </summary>
    public class MultichannelOrderManagerPostalCodeCreationConverter : CustomCreationConverter<IMultichannelOrderManagerPostalCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCodeCreationConverter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerPostalCodeCreationConverter()
            : base()
        { }

        /// <summary>
        /// Creates an instance of <see cref="IMultichannelOrderManagerPostalCode"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMultichannelOrderManagerPostalCode"/> object.</returns>
        public override IMultichannelOrderManagerPostalCode Create(Type objectType)
        {
            return new MultichannelOrderManagerPostalCode();
        }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMultichannelOrderManagerPostalCode"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MultichannelOrderManagerPostalCode testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                try
                {
                    testObj = Activator.CreateInstance(objectType) as MultichannelOrderManagerPostalCode;   // attempt to cast the instance which determines if it can be converted
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
