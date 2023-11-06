using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="SalesforceCampaign"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateSalesforceCampaignCommand : SalesforceCampaignCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceCampaignCommand"/> class with no arguments.
        /// </summary>
        private UpdateSalesforceCampaignCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceCampaignCommand"/> class with the specified <see cref="SalesforceCampaign"/>.
        /// </summary>
        /// <param name="campaign"><see cref="SalesforceCampaign"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateSalesforceCampaignCommand(SalesforceCampaign campaign)
            : base(campaign)
        {
            if (campaign == null)
            {
                throw new ArgumentNullException(nameof(campaign));
            }
        }
    }
}
