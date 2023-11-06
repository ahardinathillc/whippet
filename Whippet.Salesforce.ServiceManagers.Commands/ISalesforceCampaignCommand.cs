using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ISalesforceCampaignCommand"/> objects.
    /// </summary>
    public interface ISalesforceCampaignCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceCampaign"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public ISalesforceCampaign Campaign
        { get; }
    }
}
