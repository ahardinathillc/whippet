using System;
using NHibernate;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IRegionNameRepository"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IRegionNameRepositoryExtensions
    {
        /// <summary>
        /// Generates the <see cref="IQuery"/> to retrieve a specific <see cref="IRegionName"/> object.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object.</param>
        /// <param name="regionName">Parent <see cref="RegionNameKey"/> of the <see cref="IRegionName"/> to retrieve.</param>
        /// <returns><see cref="IQuery"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQuery CreateGetRegionNameQuery(this ISession context, RegionNameKey regionName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                const string SQL_VAR_LOCALE = "locale";
                const string SQL_VAR_REGION_ID = "region_id";

                const string SQL_STATEMENT = "SELECT dcrn.* FROM directory_country_region_name dcrn WHERE locale=:" + SQL_VAR_LOCALE + " AND region_id=:" + SQL_VAR_REGION_ID;

                IQuery query = context.CreateSQLQuery(SQL_STATEMENT)
                    .AddEntity(typeof(RegionName))
                    .SetParameter(SQL_VAR_LOCALE, regionName.Locale)
                    .SetParameter(SQL_VAR_REGION_ID, regionName.Region == null ? default(uint) : regionName.Region.ID);

                return query;
            }
        }
    }
}

