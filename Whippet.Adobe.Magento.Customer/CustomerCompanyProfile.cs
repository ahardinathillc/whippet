using System;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Provides information about an <see cref="ICustomer"/> object's job title and contact information for a company.
    /// </summary>
    public struct CustomerCompanyProfile : IEqualityComparer<CustomerCompanyProfile>
    {
        /// <summary>
        /// Gets or sets the ID of the <see cref="ICustomer"/> that the profile is for.
        /// </summary>
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company the <see cref="ICustomer"/> is associated with.
        /// </summary>
        public int CompanyID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> job title.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> company telephone number.
        /// </summary>
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the customer status at the company.
        /// </summary>
        public int Status
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCompanyProfile"/> struct with no arguments.
        /// </summary>
        static CustomerCompanyProfile()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCompanyProfile"/> struct with no arguments.
        /// </summary>
        public CustomerCompanyProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCompanyProfile"/> struct with the specified parameters.
        /// </summary>
        /// <param name="customerId"><see cref="ICustomer"/> ID the profile is for.</param>
        /// <param name="companyId">Company ID.</param>
        /// <param name="title">Job title of the <see cref="ICustomer"/>.</param>
        /// <param name="telephone">Company telephone number for the <see cref="ICustomer"/>.</param>
        /// <param name="status">Customer status at the company.</param>
        public CustomerCompanyProfile(int customerId, int companyId, string title, string telephone, int status)
            : this()
        {
            CustomerID = customerId;
            CompanyID = companyId;
            Title = title;
            Telephone = telephone;
            Status = status;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is CustomerCompanyProfile) ? false : Equals((CustomerCompanyProfile)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CustomerCompanyProfile obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two specified objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CustomerCompanyProfile x, CustomerCompanyProfile y)
        {
            return (x.CompanyID == y.CompanyID)
                   && (String.Equals(x.Telephone?.Trim(), y.Telephone?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                   && (x.CustomerID == y.CustomerID)
                   && (String.Equals(x.Title?.Trim(), y.Title?.Trim()))
                   && (x.Status == y.Status);
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerID, CompanyID, Title, Telephone, Status);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns></returns>
        public int GetHashCode(CustomerCompanyProfile obj)
        {
            return obj.GetHashCode();
        }
    }
}
