using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceCampaign"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceCampaignCommandBase : WhippetCommand, IWhippetCommand, ISalesforceCampaignCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceCampaign"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceCampaign Campaign
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceCampaign"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceCampaign ISalesforceCampaignCommand.Campaign
        {
            get
            {
                return Campaign;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaignCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceCampaignCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaignCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="SalesforceCampaign"/> instance to create or act upon in the data store.</param>
        protected SalesforceCampaignCommandBase(SalesforceCampaign campaign)
            : base()
        {
            Campaign = campaign;
        }
    }
}
