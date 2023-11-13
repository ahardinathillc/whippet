using System;
using Newtonsoft.Json;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Json
{
    /// <summary>
    /// Provides instances of the default Multichannel Order Manager JSON converters. This class cannot be inherited.
    /// </summary>
    public static class MultichannelOrderManagerDefaultJsonConverters
    {
        /// <summary>
        /// Provides instances of Multichannel Order Manager Newtonsoft JSON converters. This class cannot be inherited.
        /// </summary>
        public static class NewtonsoftConverters
        {
            private static MultichannelOrderManagerCountryCreationConverter _countryInterface;
            private static MultichannelOrderManagerPostalCodeCreationConverter _postalCodeInterface;
            private static MultichannelOrderManagerStateProvinceCreationConverter _stateProvinceInterface;
            private static MultichannelOrderManagerCountyCreationConverter _countyInterface;
            private static MultichannelOrderManagerWarehouseCreationConverter _warehouseInterface;
            private static MultichannelOrderManagerServerCreationConverter _serverInterface;
            private static MultichannelOrderManagerRestEndpointCreationConverter _endpointInterface;

            /// <summary>
            /// Gets an array of <see cref="JsonConverter"/> objects. This property is read-only.
            /// </summary>
            public static JsonConverter[] DefaultConverters
            {
                get
                {
                    return new JsonConverter[]
                    {
                        CountryInterface,
                        PostalCodeInterface,
                        StateProvinceInterface,
                        CountyInterface,
                        WarehouseInterface,
                        ServerInterface,
                        RestEndpointInterface
                    };
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerCountryCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerCountry"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerCountryCreationConverter CountryInterface
            {
                get
                {
                    if (_countryInterface == null)
                    {
                        _countryInterface = new MultichannelOrderManagerCountryCreationConverter();
                    }

                    return _countryInterface;
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerCountyCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerCounty"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerCountyCreationConverter CountyInterface
            {
                get
                {
                    if (_countyInterface == null)
                    {
                        _countyInterface = new MultichannelOrderManagerCountyCreationConverter();
                    }

                    return _countyInterface;
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerPostalCodeCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerPostalCode"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerPostalCodeCreationConverter PostalCodeInterface
            {
                get
                {
                    if (_postalCodeInterface == null)
                    {
                        _postalCodeInterface = new MultichannelOrderManagerPostalCodeCreationConverter();
                    }

                    return _postalCodeInterface;
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerStateProvinceCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerStateProvince"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerStateProvinceCreationConverter StateProvinceInterface
            {
                get
                {
                    if (_stateProvinceInterface == null)
                    {
                        _stateProvinceInterface = new MultichannelOrderManagerStateProvinceCreationConverter();
                    }

                    return _stateProvinceInterface;
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerWarehouseCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerWarehouse"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerWarehouseCreationConverter WarehouseInterface
            {
                get
                {
                    if (_warehouseInterface == null)
                    {
                        _warehouseInterface = new MultichannelOrderManagerWarehouseCreationConverter();
                    }

                    return _warehouseInterface;
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerServerCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerServer"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerServerCreationConverter ServerInterface
            {
                get
                {
                    if (_serverInterface == null)
                    {
                        _serverInterface = new MultichannelOrderManagerServerCreationConverter();
                    }

                    return _serverInterface;
                }
            }

            /// <summary>
            /// Gets the <see cref="MultichannelOrderManagerRestEndpointCreationConverter"/> object for converting <see cref="IMultichannelOrderManagerRestEndpoint"/> objects. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerRestEndpointCreationConverter RestEndpointInterface
            {
                get
                {
                    if (_endpointInterface == null)
                    {
                        _endpointInterface = new MultichannelOrderManagerRestEndpointCreationConverter();
                    }

                    return _endpointInterface;
                }
            }
        }
    }
}
