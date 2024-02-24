using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using Npgsql;
using NpgsqlTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a collection of parameters associated with a <see cref="WhippetPostgreSqlCommand"/> and their respective mappings to columns in a <see cref="DataSet"/>. This class cannot be inherited.
    /// </summary>
    [ListBindable(true)]
    public sealed class WhippetPostgreSqlParameterCollection : DbParameterCollection, IList<WhippetPostgreSqlParameter>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlParameterCollection"/> object.
        /// </summary>
        private NpgsqlParameterCollection InternalCollection
        { get; set; }

        /// <summary>
        /// Returns an <see cref="Int32"/> that contains the number of elements in the <see cref="WhippetPostgreSqlParameterCollection"/>. This property is read-only.
        /// </summary>
        public override int Count
        {
            get
            {
                return InternalCollection.Count;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetPostgreSqlParameterCollection"/> has a fixed size. This property is read-only.
        /// </summary>
        public override bool IsFixedSize
        {
            get
            {
                return InternalCollection.IsFixedSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetPostgreSqlParameterCollection"/> is read-only. This property is read-only.
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                return InternalCollection.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetPostgreSqlParameter"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the parameter to retrieve.</param>
        /// <returns>The <see cref="WhippetPostgreSqlParameter"/> at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetPostgreSqlParameter this[int index]
        {
            get
            {
                return InternalCollection[index];
            }
            set
            {
                InternalCollection[index] = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetPostgreSqlParameter"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to retrieve.</param>
        /// <returns>The <see cref="WhippetPostgreSqlParameter"/> with the specified name.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetPostgreSqlParameter this[string parameterName]
        {
            get
            {
                return InternalCollection[parameterName];
            }
            set
            {
                InternalCollection[parameterName] = value;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="WhippetPostgreSqlParameterCollection"/>. This property is read-only.
        /// </summary>
        public override object SyncRoot
        {
            get
            {
                return InternalCollection.SyncRoot;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameterCollection"/> class wth the specified <see cref="NpgsqlParameterCollection"/> object.
        /// </summary>
        /// <param name="collection"><see cref="NpgsqlParameterCollection"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlParameterCollection(NpgsqlParameterCollection collection)
            : base()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                InternalCollection = collection;
            }
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetPostgreSqlParameter"/> object to the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetPostgreSqlParameter"/> to add to the collection.</param>
        /// <returns>A new <see cref="WhippetPostgreSqlParameter"/> object.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        public WhippetPostgreSqlParameter Add(WhippetPostgreSqlParameter value)
        {
            return InternalCollection.Add(value);
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetPostgreSqlParameter"/> object to the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetPostgreSqlParameter"/> to add to the collection.</param>
        /// <returns>The index of the new <see cref="WhippetPostgreSqlParameter"/> object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int Add(object value)
        {
            return InternalCollection.Add(value);
        }

        /// <summary>
        /// Adds a <see cref="WhippetPostgreSqlParameter"/> to the <see cref="WhippetPostgreSqlParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="NpgsqlDbType"/> values.</param>
        /// <returns>A new <see cref="WhippetPostgreSqlParameter"/> object.</returns>
        public WhippetPostgreSqlParameter Add(string parameterName, NpgsqlDbType dbType)
        {
            return InternalCollection.Add(parameterName, dbType);
        }

        /// <summary>
        /// Adds a <see cref="WhippetPostgreSqlParameter"/> to the <see cref="WhippetPostgreSqlParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="NpgsqlDbType"/> values.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <returns>A new <see cref="WhippetPostgreSqlParameter"/> object.</returns>
        public WhippetPostgreSqlParameter Add(string parameterName, NpgsqlDbType dbType, int size)
        {
            return InternalCollection.Add(parameterName, dbType, size);
        }

        /// <summary>
        /// Adds a <see cref="WhippetPostgreSqlParameter"/> to the <see cref="WhippetPostgreSqlParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="NpgsqlDbType"/> values.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column <see cref="WhippetPostgreSqlParameter.SourceColumn"/> if this <see cref="WhippetPostgreSqlParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        /// <returns>A new <see cref="WhippetPostgreSqlParameter"/> object.</returns>
        public WhippetPostgreSqlParameter Add(string parameterName, NpgsqlDbType dbType, int size, string sourceColumn)
        {
            return InternalCollection.Add(parameterName, dbType, size);
        }

        /// <summary>
        /// Adds an array of values to the end of the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="values"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetPostgreSqlParameter"/> objects to add.</param>
        public void AddRange(IEnumerable<WhippetPostgreSqlParameter> values)
        {
            InternalCollection.AddRange(values.ToArray());
        }

        /// <summary>
        /// Adds an array of values to the end of the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="values"><see cref="Array"/> collection of <see cref="WhippetPostgreSqlParameter"/> objects to add.</param>
        public override void AddRange(Array values)
        {
            InternalCollection.AddRange(values);
        }

        /// <summary>
        /// Adds a value to the end of the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="value">The value to be added.</param>
        /// <returns>A <see cref="WhippetPostgreSqlParameter"/> object.</returns>
        public WhippetPostgreSqlParameter AddWithValue(string parameterName, object value)
        {
            return InternalCollection.AddWithValue(parameterName, (value == null) ? DBNull.Value : value);
        }

        /// <summary>
        /// Removes all the <see cref="WhippetPostgreSqlParameter"/> objects from the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        public override void Clear()
        {
            InternalCollection.Clear();
        }

        /// <summary>
        /// Determines whether the specified <see cref="WhippetPostgreSqlParameter"/> is in this <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetPostgreSqlParameter"/> value.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetPostgreSqlParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public bool Contains(WhippetPostgreSqlParameter value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is in this <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="Object"/> value.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetPostgreSqlParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(object value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Determines whether the specified parameter name is in this <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The parameter name to search for.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetPostgreSqlParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(string value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Copies all the elements of the current <see cref="WhippetPostgreSqlParameterCollection"/> to the specified one-dimensional <see cref="Array"/> starting at the specified destination array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from the current <see cref="WhippetPostgreSqlParameterCollection"/>.</param>
        /// <param name="index">The index in <paramref name="array"/> at which copying begins.</param>
        public override void CopyTo(Array array, int index)
        {
            InternalCollection.CopyTo(array, index);
        }

        /// <summary>
        /// Copies all the elements of the current <see cref="WhippetPostgreSqlParameterCollection"/> to the specified one-dimensional <see cref="WhippetPostgreSqlParameter"/> array starting at the specified destination array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="WhippetPostgreSqlParameter"/> array that is the destination of the elements copied from the current <see cref="WhippetPostgreSqlParameterCollection"/>.</param>
        /// <param name="index">The index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(WhippetPostgreSqlParameter[] array, int index)
        {
            InternalCollection.CopyTo(array, index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> for the <see cref="WhippetPostgreSqlParameterCollection"/>.</returns>
        public override IEnumerator GetEnumerator()
        {
            return InternalCollection.GetEnumerator();
        }

        /// <summary>
        /// Gets the <see cref="DbParameter"/> at the specified index.
        /// </summary>
        /// <param name="index">Index of the parameter to retrieve.</param>
        /// <returns><see cref="DbParameter"/> object.</returns>
        protected override DbParameter GetParameter(int index)
        {
            return this[index];
        }

        /// <summary>
        /// Gets the <see cref="DbParameter"/> that has the specified parameter name.
        /// </summary>
        /// <param name="parameterName">Name of the parameter to retrieve.</param>
        /// <returns><see cref="DbParameter"/> with the specified name.</returns>
        protected override DbParameter GetParameter(string parameterName)
        {
            return this[parameterName];
        }

        /// <summary>
        /// Gets the location of the specified <see cref="WhippetPostgreSqlParameter"/> within the collection.
        /// </summary>
        /// <param name="value">The <see cref="WhippetPostgreSqlParameter"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="WhippetPostgreSqlParameter"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public int IndexOf(WhippetPostgreSqlParameter value)
        {
            return InternalCollection.IndexOf(value);
        }

        /// <summary>
        /// Gets the location of the specified <see cref="Object"/> within the collection.
        /// </summary>
        /// <param name="value">The <see cref="Object"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="Object"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public override int IndexOf(object value)
        {
            return InternalCollection.IndexOf(value);
        }

        /// <summary>
        /// Gets the location of the specified <see cref="WhippetPostgreSqlParameter"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The case-sensitive name of the <see cref="WhippetPostgreSqlParameter"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="WhippetPostgreSqlParameter"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public override int IndexOf(string parameterName)
        {
            return InternalCollection.IndexOf(parameterName);
        }

        /// <summary>
        /// Inserts a <see cref="WhippetPostgreSqlParameter"/> object into the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">A <see cref="WhippetPostgreSqlParameter"/> object to be inserted in the <see cref="WhippetPostgreSqlParameterCollection"/>.</param>
        public void Insert(int index, WhippetPostgreSqlParameter value)
        {
            InternalCollection.Insert(index, value);
        }

        /// <summary>
        /// Inserts an <see cref="Object"/> object into the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">An <see cref="Object"/> object to be inserted in the <see cref="WhippetPostgreSqlParameterCollection"/>.</param>
        public override void Insert(int index, object value)
        {
            InternalCollection.Insert(index, value);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetPostgreSqlParameter"/> from the collection.
        /// </summary>
        /// <param name="value"><see cref="WhippetPostgreSqlParameter"/> object to remove from the collection.</param>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        public void Remove(WhippetPostgreSqlParameter value)
        {
            InternalCollection.Remove(value);
        }

        /// <summary>
        /// Removes the specified <see cref="Object"/> from the collection.
        /// </summary>
        /// <param name="value"><see cref="Object"/> instance to remove from the collection.</param>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        public override void Remove(object value)
        {
            InternalCollection.Remove(value);
        }

        /// <summary>
        /// Removes the <see cref="WhippetPostgreSqlParameter"/> from the <see cref="WhippetPostgreSqlParameterCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="WhippetPostgreSqlParameter"/> object to remove.</param>
        public override void RemoveAt(int index)
        {
            InternalCollection.RemoveAt(index);
        }

        /// <summary>
        /// Removes the <see cref="WhippetPostgreSqlParameter"/> from the <see cref="WhippetPostgreSqlParameterCollection"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The name of the <see cref="WhippetPostgreSqlParameter"/> to remove.</param>
        public override void RemoveAt(string parameterName)
        {
            InternalCollection.RemoveAt(parameterName);
        }

        /// <summary>
        /// Sets the parameter at the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the parameter to update.</param>
        /// <param name="value"><see cref="WhippetPostgreSqlParameter"/> to set.</param>
        protected override void SetParameter(int index, DbParameter value)
        {
            this[index] = value as WhippetPostgreSqlParameter;
        }

        /// <summary>
        /// Sets the parameter with the specified parameter name.
        /// </summary>
        /// <param name="parameterName">Name of the parameter to update.</param>
        /// <param name="value"><see cref="WhippetPostgreSqlParameter"/> to set.</param>
        protected override void SetParameter(string parameterName, DbParameter value)
        {
            this[parameterName] = value as WhippetPostgreSqlParameter;
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetPostgreSqlParameter"/> object to the <see cref="WhippetPostgreSqlParameterCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="WhippetPostgreSqlParameter"/> to add to the collection.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        void ICollection<WhippetPostgreSqlParameter>.Add(WhippetPostgreSqlParameter item)
        {
            Add(item);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetPostgreSqlParameter"/> from the collection.
        /// </summary>
        /// <param name="item"><see cref="WhippetPostgreSqlParameter"/> object to remove from the collection.</param>
        /// <returns><see langword="true"/> if the item was removed successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        bool ICollection<WhippetPostgreSqlParameter>.Remove(WhippetPostgreSqlParameter item)
        {
            Remove(item);
            return Contains(item);
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> used to iterate over each item in the collection.</returns>
        IEnumerator<WhippetPostgreSqlParameter> IEnumerable<WhippetPostgreSqlParameter>.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public static implicit operator WhippetPostgreSqlParameterCollection(NpgsqlParameterCollection collection)
        {
            return (collection == null) ? null : new WhippetPostgreSqlParameterCollection(collection);
        }

        public static implicit operator NpgsqlParameterCollection(WhippetPostgreSqlParameterCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }
    }
}
