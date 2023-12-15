using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Data.NHibernate.UserTypes;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.SuperDuper.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.SuperDuper.Legacy.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="LegacySuperDuperAccount"/> objects.
    /// </summary>
    public class SuperDuperAccountMap : SuperDuperLegacyFluentMap<LegacySuperDuperAccount>
    {
        private const string TABLE_NAME = "account";

        private const string COL_CUSTNUM = "custnum";
        private const string COL_UUID = "uuid";
        private const string COL_EMAIL = "email";
        private const string COL_DATEADDED = "date_added";
        private const string COL_REGISTERED = "registered";
        private const string COL_PASSWORD = "[password]";
        private const string COL_NAME_LAST = "name_last";
        private const string COL_NAME_FIRST = "name_first";
        private const string COL_OCCUPATION = "occupation_id";
        private const string COL_PASSWORD_RESET = "password_reset_id";
        private const string COL_PRICEID_SPECIAL = "price_id_special";
        private const string COL_WISHLIST_UUID = "WishList_UUID";
        private const string COL_COMPANY_CODE = "Company_Code";
        private const string COL_CPACS_KEY = "cpacsKey";
        private const string COL_CAAP = "caapBeta_Key";
        private const string COL_TESTER = "tester_projects";
        private const string COL_SHOPPING_CART_EMAIL = "ShoppingCart_Abandonment_Email_Sent";
        private const string COL_TAX_EXEMPT = "taxExempt";
        private const string COL_MOM_ACCOUNT_ID = "mom_account_id";
        private const string COL_CURRENT_SESSION_ID = "currentSessionID";
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAccountMap"/> class with no arguments.
        /// </summary>
        public SuperDuperAccountMap()
            : base(TABLE_NAME)
        {
            Map(a => a.CustomerNumber).Column(COL_CUSTNUM).Not.Nullable();
            Map(a => a.UUID).Column(COL_UUID).Not.Nullable();
            Map(a => a.Email).Column(COL_EMAIL).Not.Nullable().Length(100);
            Map(a => a.CreatedDTTM).Column(COL_DATEADDED).Not.Nullable().CustomType<InstantUserType>();
            Map(a => a.Registered).Column(COL_REGISTERED).Not.Nullable();
            Map(a => a.Password).Column(COL_PASSWORD).Length(200).Nullable();
            Map(a => a.LastName).Column(COL_NAME_LAST).Length(20).Nullable();
            Map(a => a.FirstName).Column(COL_NAME_FIRST).Length(15).Nullable();
            Map(a => a.PasswordResetID).Column(COL_PASSWORD_RESET).Nullable();
            Map(a => a.SpecialPriceID).Column(COL_PRICEID_SPECIAL).Nullable();
            Map(a => a.WishlistID).Column(COL_WISHLIST_UUID).Nullable();
            Map(a => a.CompanyCode).Column(COL_COMPANY_CODE).Length(50).Nullable();
            Map(a => a.CPACS).Column(COL_CPACS_KEY).Length(50).Nullable();
            Map(a => a.CAAP).Column(COL_CAAP).Length(50).Nullable();
            Map(a => a.TesterProjects).Column(COL_TESTER).Length(100).Nullable();
            Map(a => a.ShoppingCart_Abandonment_Email_Sent).Column(COL_SHOPPING_CART_EMAIL).Nullable().CustomType<NullableInstantUserType>();
            Map(a => a.TaxExempt).Column(COL_TAX_EXEMPT).Not.Nullable();
            Map(a => a.MultichannelOrderManagerAccountID).Column(COL_MOM_ACCOUNT_ID).Nullable();
            Map(a => a.SessionID).Column(COL_CURRENT_SESSION_ID).Nullable();

            References<LegacySuperDuperAccountOccupation>(a => a.SuperDuperAccountOccupation).Column(COL_OCCUPATION).Nullable();
        }
    }
}
