using System;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a query attribute to a <see cref="WhippetMySqlCommand"/>.
    /// </summary>
    public class WhippetMySqlAttribute : MySqlAttribute, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlAttribute"/> class with no arguments.
        /// </summary>
        public WhippetMySqlAttribute()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlAttribute"/> class with the specified name and value.
        /// </summary>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        public WhippetMySqlAttribute(string attributeName, object attributeValue)
            : base(attributeName, attributeValue)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlAttribute"/> class with the specified <see cref="MySqlAttribute"/>.
        /// </summary>
        /// <param name="attribute"><see cref="MySqlAttribute"/> object to initialize with.</param>
        public WhippetMySqlAttribute(MySqlAttribute attribute)
            : base(attribute?.AttributeName, attribute?.Value)
        { }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public new WhippetMySqlAttribute Clone()
        {
            return new WhippetMySqlAttribute(base.Clone());
        }
    }
}

