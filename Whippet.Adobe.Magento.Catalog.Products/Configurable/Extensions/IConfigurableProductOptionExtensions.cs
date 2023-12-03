using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IConfigurableProductOption"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IConfigurableProductOptionExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IConfigurableProductOption"/> object to a <see cref="ConfigurableProductOption"/> object.
        /// </summary>
        /// <param name="option"><see cref="IConfigurableProductOption"/> object to convert.</param>
        /// <returns><see cref="ConfigurableProductOption"/> object.</returns>
        public static ConfigurableProductOption ToConfigurableProductOption(this IConfigurableProductOption option)
        {
            ConfigurableProductOption cpo = null;

            if (option is ConfigurableProductOption)
            {
                cpo = (ConfigurableProductOption)(option);
            }
            else if (option != null)
            {
                cpo = new ConfigurableProductOption();
                cpo.AttributeID = option.AttributeID;
                cpo.Label = option.Label;
                cpo.Position = option.Position;
                cpo.UseDefault = option.UseDefault;
                cpo.Values = (option.Values == null) ? null : option.Values.Select(v => v);
                cpo.ProductID = option.ProductID;
                cpo.RestEndpoint = (option.RestEndpoint == null) ? null : option.RestEndpoint.ToMagentoRestEndpoint();
                cpo.Server = (option.Server == null) ? null : option.Server.ToMagentoServer();
            }

            return cpo;
        }
    }
}
