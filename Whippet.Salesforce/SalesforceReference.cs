using System;
using System.Diagnostics.CodeAnalysis;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a <see cref="string"/> in Salesforce that references an <see cref="ISalesforceObject"/>.
    /// </summary>
    public struct SalesforceReference : IEqualityComparer<SalesforceReference>, ISalesforceCompositeReference
    {
        private const byte MAX_LEN = 18;

        private string _value;

        private Dictionary<string, SalesforceReference> _comp;

        /// <summary>
        /// Gets or sets the reference value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        private string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    if (value.Length > MAX_LEN)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value));
                    }
                }

                _value = value?.Trim();
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> that is indexed by the Salesforce object column name and associated <see cref="SalesforceReference"/> value. This property is read-only.
        /// </summary>
        IReadOnlyDictionary<string, SalesforceReference> ISalesforceCompositeReference.CompositeValue
        {
            get
            {
                return InternalCompositeValue;
            }
        }

        /// <summary>
        /// Gets or sets the internal <see cref="Dictionary{TKey, TValue}"/> that contains the composite value.
        /// </summary>
        private Dictionary<string, SalesforceReference> InternalCompositeValue
        {
            get
            {
                if (_comp == null)
                {
                    _comp = new Dictionary<string, SalesforceReference>();
                }

                return _comp;
            }
            set
            {
                _comp = value;
            }
        }

        /// <summary>
        /// Represents the maximum length the value can be. This property is read-only.
        /// </summary>
        public static byte MaximumLength
        {
            get
            {
                return MAX_LEN;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceReference"/> struct with no arguments.
        /// </summary>
        static SalesforceReference()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceReference"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public SalesforceReference(string value)
            : this()
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceReference"/> struct with the specified composite value.
        /// </summary>
        /// <param name="compositeReference"><see cref="ISalesforceCompositeReference"/> object to initialize with.</param>
        public SalesforceReference(ISalesforceCompositeReference compositeReference)
            : this()
        {
            if (compositeReference != null)
            {
                InternalCompositeValue = new Dictionary<string, SalesforceReference>(compositeReference.CompositeValue);
            }
        }

        /// <summary>
        /// Determines if the current instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(new SalesforceReference(obj?.ToString()));
        }

        /// <summary>
        /// Determines if the current instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesforceReference obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines if the two objects are equal.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesforceReference x, SalesforceReference y)
        {
            bool equals = String.Equals(x.Value, y.Value, StringComparison.InvariantCulture);

            if (equals)
            {
                // check the composite values

                if (x.InternalCompositeValue.Count == y.InternalCompositeValue.Count)
                {
                    foreach (KeyValuePair<string, SalesforceReference> compEntry in x.InternalCompositeValue)
                    {
                        if (y.InternalCompositeValue.ContainsKey(compEntry.Key))
                        {
                            if (compEntry.Value != y.InternalCompositeValue[compEntry.Key])
                            {
                                equals = false;
                                break;
                            }
                        }
                        else
                        {
                            equals = false;
                            break;
                        }
                    }
                }
                else
                {
                    equals = false;
                }
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return (Value == null) ? base.GetHashCode() : Value.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(SalesforceReference obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(SalesforceReference x, SalesforceReference y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(SalesforceReference x, SalesforceReference y)
        {
            return !x.Equals(y);
        }

        public static implicit operator string(SalesforceReference sfRef)
        {
            return sfRef.Value;
        }

        public static implicit operator SalesforceReference(string sfRef)
        {
            return new SalesforceReference(sfRef);
        }
    }
}

