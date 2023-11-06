using System;
using System.Diagnostics.CodeAnalysis;
using NodaTime;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a fical date in "YYYY Q" format.
    /// </summary>
    public struct SalesforceFiscalDate : IEqualityComparer<SalesforceFiscalDate>
    {
        /// <summary>
        /// Gets or sets the fiscal quarter.
        /// </summary>
        public SalesforceFiscalQuarter Quarter
        { get; set; }

        /// <summary>
        /// Gets or sets the fiscal year.
        /// </summary>
        public Instant Year
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceFiscalDate"/> struct with no arguments.
        /// </summary>
        static SalesforceFiscalDate()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceFiscalDate"/> struct with the specified year and quarter.
        /// </summary>
        /// <param name="year">Fiscal year.</param>
        /// <param name="quarter">Fiscal quarter.</param>
        public SalesforceFiscalDate(int year, SalesforceFiscalQuarter quarter)
            : this(Instant.FromDateTimeUtc(new DateTime(year, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)), quarter)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceFiscalDate"/> struct with the specified year and quarter.
        /// </summary>
        /// <param name="date">Fiscal year.</param>
        /// <param name="quarter">Fiscal quarter.</param>
        public SalesforceFiscalDate(DateOnly date, SalesforceFiscalQuarter quarter)
            : this(date.Year, quarter)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceFiscalDate"/> struct with the specified year and quarter.
        /// </summary>
        /// <param name="dateTime">Fiscal year.</param>
        /// <param name="quarter">Fiscal quarter.</param>
        public SalesforceFiscalDate(DateTime dateTime, SalesforceFiscalQuarter quarter)
            : this(dateTime.Year, quarter)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceFiscalDate"/> struct with the specified year and quarter.
        /// </summary>
        /// <param name="dateTime">Fiscal year.</param>
        /// <param name="quarter">Fiscal quarter.</param>
        public SalesforceFiscalDate(Instant dateTime, SalesforceFiscalQuarter quarter)
            : this()
        {
            Year = dateTime;
            Quarter = quarter;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            bool equals = true;

            if (!(obj is SalesforceFiscalDate))
            {
                equals = false;
            }
            else
            {
                equals = Equals((SalesforceFiscalDate)(obj));
            }

            return equals;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="fiscalDate">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesforceFiscalDate fiscalDate)
        {
            return Equals(this, fiscalDate);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesforceFiscalDate x, SalesforceFiscalDate y)
        {
            return (x.Quarter == y.Quarter) && (x.Year.ToDateTimeUtc().Year == y.Year.ToDateTimeUtc().Year);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="fiscalDate"><see cref="SalesforceFiscalDate"/> object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(SalesforceFiscalDate fiscalDate)
        {
            return fiscalDate.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Year.ToDateTimeUtc().Year + " " + Convert.ToInt32(Quarter);
        }
    }
}

