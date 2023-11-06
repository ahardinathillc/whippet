using System;
using System.Security.Claims;
using System.IO;

namespace Athi.Whippet.Security.Claims
{
    /// <summary>
    /// Represents a claim. A claim is a statement about a subject by an issuer, which in turn represents one or more attributes of the subject that are useful in the context of authentication and authorization operations.
    /// </summary>
    public class WhippetClaim : Claim
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="reader"><see cref="BinaryReader"/> pointing to a <see cref="Claim"/>.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(BinaryReader reader)
            : base(reader)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class based on the specified existing <see cref="Claim"/>.
        /// </summary>
        /// <param name="other">The security claim.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(Claim other)
            : base(other)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified reader and subject.
        /// </summary>
        /// <param name="reader">The binary reader.</param>
        /// <param name="subject">The subject that this claim describes.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(BinaryReader reader, ClaimsIdentity subject)
            : base(reader, subject)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified security claim and subject.
        /// </summary>
        /// <param name="other">The security claim.</param>
        /// <param name="subject">The subject that this claim describes.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(Claim other, ClaimsIdentity subject)
            : base(other, subject)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified claim type and value.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(string type, string value)
            : base(type, value)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified claim type, value, and value type.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        /// <param name="valueType">The claim value type. If <see langword="null"/>, <see cref="String"/> is used.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(string type, string value, string valueType)
            : base(type, value, valueType)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified claim type, value, value type, and issuer.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        /// <param name="valueType">The claim value type. If <see langword="null"/>, <see cref="String"/> is used.</param>
        /// <param name="issuer">The claim issuer. If this parameter is empty or <see langword="null"/>, <see cref="ClaimsIdentity.DefaultIssuer"/> is used.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(string type, string value, string valueType, string issuer)
            : base(type, value, valueType, issuer)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified claim type, value, value type, issuer, and original issuer.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        /// <param name="valueType">The claim value type. If <see langword="null"/>, <see cref="String"/> is used.</param>
        /// <param name="issuer">The claim issuer. If this parameter is empty or <see langword="null"/>, <see cref="ClaimsIdentity.DefaultIssuer"/> is used.</param>
        /// <param name="originalIssuer">The original issuer of the claim. If this property is empty or <see langword="null"/>, then the <see cref="Claim.OriginalIssuer"/> property is set to the value of the <see cref="Claim.Issuer"/> property.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(string type, string value, string valueType, string issuer, string originalIssuer)
            : base(type, value, valueType, issuer, originalIssuer)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaim"/> class with the specified claim type, value, value type, issuer, original issuer, and subject.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        /// <param name="valueType">The claim value type. If <see langword="null"/>, <see cref="String"/> is used.</param>
        /// <param name="issuer">The claim issuer. If this parameter is empty or <see langword="null"/>, <see cref="ClaimsIdentity.DefaultIssuer"/> is used.</param>
        /// <param name="originalIssuer">The original issuer of the claim. If this property is empty or <see langword="null"/>, then the <see cref="Claim.OriginalIssuer"/> property is set to the value of the <see cref="Claim.Issuer"/> property.</param>
        /// <param name="subject">The subject that this claim describes.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaim(string type, string value, string valueType, string issuer, string originalIssuer, ClaimsIdentity subject)
            : base(type, value, valueType, issuer, originalIssuer, subject)
        { }
    }
}

