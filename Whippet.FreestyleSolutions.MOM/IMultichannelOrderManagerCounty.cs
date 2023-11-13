using System;
using System.Data;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a county in the Multichannel Order Manager (M.O.M.) database.
    /// </summary>
    public interface IMultichannelOrderManagerCounty : IWhippetEntity, IMultichannelOrderManagerEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerCounty>, IWhippetCloneable, IComparable<IMultichannelOrderManagerCounty>
    {
        /// <summary>
        /// Gets or sets the county's parent country.
        /// </summary>
        IMultichannelOrderManagerCountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the three digit county code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string CountyCode
        { get; set; }

        /// <summary>
        /// Specifies the FIPS code for the county.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string FIPS
        { get; set; }

        /// <summary>
        /// Specifies the name of the county.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the timezone offet for the county.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string TimezoneOffset
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MSA
        { get; set; }

        /// <summary>
        /// Gets or sets the county's tax rate.
        /// </summary>
        decimal TaxRate
        { get; set; }

        /// <summary>
        /// Indicates whether the company has a presence in the county.
        /// </summary>
        bool Presence
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        char Code
        { get; set; }

        /// <summary>
        /// Specifies the warehouse that serves the county.
        /// </summary>
        IMultichannelOrderManagerWarehouse Warehouse
        { get; set; }

        /// <summary>
        /// Indicates whether shipping should be taxed.
        /// </summary>
        bool TaxShipping
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        bool Tax_ClassA
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        bool Tax_ClassB
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        bool Tax_ClassC
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        bool Tax_ClassD
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        bool Tax_ClassE
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal RateClass_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal RateClass_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal RateClass_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal RateClass_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal RateClass_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LCAP_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LCAP_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LCAP_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LCAP_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LCAP_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LTAXIT_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LTAXIT_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LTAXIT_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LTAXIT_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool LTAXIT_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NTAXIT_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NTAXIT_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NTAXIT_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NTAXIT_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NTAXIT_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NCAP_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NCAP_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NCAP_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NCAP_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        decimal NCAP_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NONTAXBOX
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NTAXTHRES_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NTAXTHRES_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NTAXTHRES_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NTAXTHRES_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NTAXTHRES_E
        { get; set; }

        /// <summary>
        /// Specifies whether handling charges should be taxed.
        /// </summary>
        bool TaxHandling
        { get; set; }

        /// <summary>
        /// Represents the unique ID assigned to the entity by the external data source.
        /// </summary>
        long CountyId
        { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        string LookupBy
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        DateTime? LookupOn
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last updated.
        /// </summary>
        DateTime? Updated
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerStateProvince"/>.
        /// </summary>
        IMultichannelOrderManagerStateProvince StateProvince
        { get; set; }
    }
}
