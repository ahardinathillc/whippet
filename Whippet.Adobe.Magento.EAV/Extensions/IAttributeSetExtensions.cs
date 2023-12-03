using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.EAV.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IAttributeSet"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IAttributeSetExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IAttributeSet"/> object to an <see cref="AttributeSet"/> object.
        /// </summary>
        /// <param name="set"><see cref="IAttributeSet"/> object.</param>
        /// <returns><see cref="AttributeSet"/> object.</returns>
        public static AttributeSet ToAttributeSet(this IAttributeSet set)
        {
            AttributeSet attribSet = null;

            if (set is AttributeSet)
            {
                attribSet = (AttributeSet)(set);
            }
            else if (set != null)
            {
                attribSet = new AttributeSet();
                attribSet.Name = set.Name;
                attribSet.SortOrder = set.SortOrder;
                attribSet.EntityTypeID = set.EntityTypeID;
                attribSet.RestEndpoint = (set.RestEndpoint == null) ? null : set.RestEndpoint.ToMagentoRestEndpoint();
                attribSet.Server = (set.Server == null) ? null : set.Server.ToMagentoServer();
            }

            return attribSet;
        }
    }
}
