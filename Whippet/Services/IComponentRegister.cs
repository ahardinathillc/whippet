using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Services
{
    /// <summary>
    /// Registers service locators within the application.
    /// </summary>
    public interface IComponentRegister
    {
        /// <summary>
        /// Registers the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">Service locator to register.</param>
        /// <exception cref="ArgumentNullException" />
        void Register(IWhippetServiceContext serviceLocator);
    }
}
