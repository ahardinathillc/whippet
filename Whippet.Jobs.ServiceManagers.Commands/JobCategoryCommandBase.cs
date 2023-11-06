using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="JobCategory"/> objects. This class must be inherited.
    /// </summary>
    public abstract class JobCategoryCommandBase : WhippetCommand, IWhippetCommand, IJobCategoryCommand
    {
        /// <summary>
        /// Gets the <see cref="JobCategory"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public JobCategory Category
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IJobCategory"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IJobCategory IJobCategoryCommand.Category
        {
            get
            {
                return Category;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryCommandBase"/> class with no arguments.
        /// </summary>
        protected JobCategoryCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryCommandBase"/> class with the specified <see cref="JobCategory"/> object.
        /// </summary>
        /// <param name="category"><see cref="JobCategory"/> object to initialize with.</param>
        protected JobCategoryCommandBase(JobCategory category)
            : this()
        {
            Category = category;
        }
    }
}
