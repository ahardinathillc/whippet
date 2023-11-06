using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="JobCategory"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public class DeleteJobCategoryCommand : JobCategoryCommandBase, IJobCategoryCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteJobCategoryCommand"/> class with no arguments.
        /// </summary>
        private DeleteJobCategoryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteJobCategoryCommand"/> class with the specified <see cref="JobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="JobCategory"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteJobCategoryCommand(JobCategory category)
            : base(category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
        }
    }
}
