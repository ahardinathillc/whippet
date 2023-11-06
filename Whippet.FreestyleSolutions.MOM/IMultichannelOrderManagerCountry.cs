using System;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a country in the Multichannel Order Manager database.
    /// </summary>
    public interface IMultichannelOrderManagerCountry : IWhippetEntity, IMultichannelOrderManagerEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerCountry>, IWhippetCloneable, IComparable<IMultichannelOrderManagerCountry>, IJsonObject
    {
        /// <summary>
        /// Represents the unique country ID that is assigned to each entry.
        /// </summary>
        new long ID
        { get; set; }

        /// <summary>
        /// Represents the unique country ID that is assigned to each entry.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string CountryCode
        { get; set; }

        /// <summary>
        /// Name of the country.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }

        /// <summary>
        /// Specifies the country's national tax rate.
        /// </summary>
        decimal NationalTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the phone number format of the <see cref="MultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string PhoneMask
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool Tax_ClassA
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool Tax_ClassB
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool Tax_ClassC
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool Tax_ClassD
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool Tax_ClassE
        { get; set; }

        /// <summary>
        /// Indicates whether shipping costs are taxed.
        /// </summary>
        bool TaxShipping
        { get; set; }

        /// <summary>
        /// Represents the two-character ISO code for the country.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ISO2
        { get; set; }

        /// <summary>
        /// Represents the three-character ISO code for the country.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ISO3
        { get; set; }

        /// <summary>
        /// Represents the three-digit ISO number for the country.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ISONumber
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
        /// Specifies the (primary) warehouse that serves the country.
        /// </summary>
        IMultichannelOrderManagerWarehouse Warehouse
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
        long CountryId
        { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string LookupBy
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        DateTime? LookupOn
        { get; set; }
    }
}

