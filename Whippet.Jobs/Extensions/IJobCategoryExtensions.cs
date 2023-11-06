using System;

namespace Athi.Whippet.Jobs.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IJobCategory"/> objects.
    /// </summary>
    public static class IJobCategoryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IJobCategory"/> object to a <see cref="JobCategory"/> object.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object.</param>
        /// <returns><see cref="JobCategory"/> object.</returns>
        public static JobCategory ToJobCategory(this IJobCategory category)
        {
            JobCategory jc = null;

            if (category != null)
            {
                jc = new JobCategory(category.ID, category.Name, category.Description, (category.Parent == null) ? null : category.Parent.ToJobCategory());
            }

            return jc;
        }
    }
}

