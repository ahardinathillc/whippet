using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Jobs.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="JobCategory"/> objects.
    /// </summary>
    public class JobCategoryMap : WhippetFluentMap<JobCategory>
    {
        private const string TABLE_NAME = "JobCategory";

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryMap"/> class with no arguments.
        /// </summary>
        public JobCategoryMap()
            : base(TABLE_NAME)
        {
            Map(c => c.Name).Not.Nullable().Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength());
            Map(c => c.Description).Not.Nullable().Length(ObjectExtensionMethods.GetMaximumStringLength());

            References<JobCategory>(c => c.Parent).Nullable().LazyLoad(Laziness.False);
        }
    }
}
