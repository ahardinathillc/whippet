using System;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.ServiceManagers;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for installing and updating a Multichannel Order Manager database. This class cannot be inherited.
    /// </summary>
    public sealed class MultichannelOrderManagerInstallerServiceManager : ServiceManager
    {
        public MultichannelOrderManagerInstallerServiceManager(string connectionString, string fullPathToDatabaseScript, )
            : base()
        { }
    }
}
