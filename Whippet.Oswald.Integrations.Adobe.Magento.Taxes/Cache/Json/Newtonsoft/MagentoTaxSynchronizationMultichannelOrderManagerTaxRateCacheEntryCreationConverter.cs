using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Json.Newtonsoft
{
    /// <summary>
    /// Provides a converter for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter : CustomCreationConverter<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        private static MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter _instance;
        
        /// <summary>
        /// Retrieves a singleton instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter"/>. This property is read-only.
        /// </summary>
        public static MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter();
                }

                return _instance;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCreationConverter()
            : base()
        { }

        /// <summary>
        /// Creates an instance of <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> using the default implementation.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</returns>
        public override IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry Create(Type objectType)
        {
            return new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry();
        }

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted to an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> instance.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object encountered.</param>
        /// <returns><see langword="true"/> if the object can be cast; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry testObj = null;
            bool canConvert = base.CanConvert(objectType);

            if (canConvert)
            {
                try
                {
                    testObj = Activator.CreateInstance(objectType) as MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry;   // attempt to cast the instance which determines if it can be converted
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
