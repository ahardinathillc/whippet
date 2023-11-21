using System;

namespace Athi.Whippet.Adobe.Magento.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="MagentoCustomAttributeCollection"/> objects. This class cannot be inherited.
    /// </summary>
    public static class MagentoCustomAttributeCollectionExtensions
    {
        /// <summary>
        /// Converts the <see cref="MagentoCustomAttributeCollection"/> object to an <see cref="Array"/> of <see cref="CustomAttributeInterface"/> objects.
        /// </summary>
        /// <returns><see cref="CustomAttributeInterface"/> array.</returns>
        public static CustomAttributeInterface[] ToInterfaceArray(this MagentoCustomAttributeCollection collection)
        {
            CustomAttributeInterface[] array = null;
            int index = 0;
            
            if ((collection != null) && (collection.Count > 0))
            {
                array = new CustomAttributeInterface[collection.Count];

                foreach (MagentoCustomAttribute attribute in collection)
                {
                    array[index] = new CustomAttributeInterface(attribute.Code, attribute.Value);
                    index++;
                }
            }

            return array;
        }
        
    }
}
