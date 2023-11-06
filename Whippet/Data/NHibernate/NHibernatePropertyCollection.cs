using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate;
using FluentNHibernate.Cfg;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Provides an index of properties that are applied to the NHibernate engine.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class NHibernatePropertyCollection : Dictionary<string, string>, IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<string, string>, IReadOnlyCollection<KeyValuePair<string, string>>, ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernatePropertyCollection"/> class with no arguments.
        /// </summary>
        public NHibernatePropertyCollection()
            : base(StringComparer.InvariantCultureIgnoreCase)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernatePropertyCollection"/> class with the specified <see cref="FluentConfiguration"/>.
        /// </summary>
        /// <param name="config"><see cref="FluentConfiguration"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NHibernatePropertyCollection(FluentConfiguration config)
            : this()
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            else
            {
                IEnumerable<KeyValuePair<string, string>> failed = null;
                config.ExposeConfiguration(c => AddRange(c.Properties, out failed));    // should not have any failures since Properties is an IDictionary<string, string>
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernatePropertyCollection"/> class with the specified <see cref="Configuration"/>.
        /// </summary>
        /// <param name="config"><see cref="Configuration"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NHibernatePropertyCollection(Configuration config)
            : this()
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            else
            {
                IEnumerable<KeyValuePair<string, string>> failed = null;
                AddRange(config.Properties, out failed);    // should not have any failures since Properties is an IDictionary<string, string>
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernatePropertyCollection"/> class with the specified <see cref="IEnumerable{T}"/> collection.
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection to initialize with.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public NHibernatePropertyCollection(IEnumerable<KeyValuePair<string, string>> collection)
            : base(collection, StringComparer.InvariantCultureIgnoreCase)
        { }

        /// <summary>
        /// Adds the specified collection to the current instance.
        /// </summary>
        /// <param name="collection">Collection of properties to add to the current collection.</param>
        /// <param name="failed"><see cref="IEnumerable{T}"/> of entries in <paramref name="collection"/> that could not be added to the collection.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void AddRange(IEnumerable<KeyValuePair<string, string>> collection, out IEnumerable<KeyValuePair<string, string>> failed)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                Dictionary<string, string> failedEntries = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

                foreach (KeyValuePair<string, string> entry in collection)
                {
                    if (!TryAdd(entry.Key, entry.Value) && !failedEntries.ContainsKey(entry.Key))
                    {
                        failedEntries.Add(entry.Key, entry.Value);
                    }
                }

                failed = failedEntries;
            }
        }

        /// <summary>
        /// Exports the current property set to the specified <see cref="FluentConfiguration"/> object.
        /// </summary>
        /// <param name="config"><see cref="FluentConfiguration"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void ExportToConfiguration(FluentConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            else
            {
                config.ExposeConfiguration(c => ExportToConfiguration(c));
            }
        }

        /// <summary>
        /// Exports the current property set to the specified <see cref="Configuration"/> object.
        /// </summary>
        /// <param name="config"><see cref="Configuration"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void ExportToConfiguration(Configuration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            else
            {
                foreach (KeyValuePair<string, string> property in this)
                {
                    if (!config.Properties.ContainsKey(property.Key))
                    {
                        config.Properties.Add(property);
                    }
                    else
                    {
                        config.Properties[property.Key] = property.Value;
                    }
                }
            }
        }
    }
}

