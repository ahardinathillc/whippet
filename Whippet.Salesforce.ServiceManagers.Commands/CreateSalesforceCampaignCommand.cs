using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceCampaign"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceCampaignCommand : SalesforceCampaignCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceCampaignCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceCampaignCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceCampaignCommand"/> class with the specified <see cref="SalesforceCampaign"/>.
        /// </summary>
        /// <param name="campaign"><see cref="SalesforceCampaign"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceCampaignCommand(SalesforceCampaign campaign)
            : base(campaign)
        {
            if (campaign == null)
            {
                throw new ArgumentNullException(nameof(campaign));
            }
        }
    }
}
