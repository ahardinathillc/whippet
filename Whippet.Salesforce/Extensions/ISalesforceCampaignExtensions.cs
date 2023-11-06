using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceCampaign"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceCampaignExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceCampaign"/> object to a <see cref="SalesforceCampaign"/> object.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to convert.</param>
        /// <returns><see cref="SalesforceCampaign"/> object.</returns>
        public static SalesforceCampaign ToSalesforceCampaign(this ISalesforceCampaign campaign)
        {
            SalesforceCampaign sfCampaign = null;

            if (campaign != null)
            {
                if (campaign is SalesforceCampaign)
                {
                    sfCampaign = (SalesforceCampaign)(campaign);
                }
                else
                {
                    sfCampaign = new SalesforceCampaign();
                    sfCampaign.ImportDataRow(campaign.CreateDataRow__Internal());
                }
            }

            return sfCampaign;
        }
    }
}

