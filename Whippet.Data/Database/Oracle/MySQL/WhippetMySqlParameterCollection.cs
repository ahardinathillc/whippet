using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a collection of parameters associated with a <see cref="WhippetMySqlCommand"/> and their respective mappings to columns in a <see cref="DataSet"/>. This class cannot be inherited.
    /// </summary>
    [ListBindable(true)]
    public sealed class WhippetMySqlParameterCollection : DbParameterCollection, IList<WhippetMySqlParameter>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlParameterCollection"/> object.
        /// </summary>
        private MySqlParameterCollection InternalCollection
        { get; set; }

        /// <summary>
        /// Returns an <see cref="Int32"/> that contains the number of elements in the <see cref="WhippetMySqlParameterCollection"/>. This property is read-only.
        /// </summary>
        public override int Count
        {
            get
            {
                return InternalCollection.Count;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetMySqlParameterCollection"/> has a fixed size. This property is read-only.
        /// </summary>
        public override bool IsFixedSize
        {
            get
            {
                return InternalCollection.IsFixedSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetMySqlParameterCollection"/> is read-only. This property is read-only.
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                return InternalCollection.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetMySqlParameter"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the parameter to retrieve.</param>
        /// <returns>The <see cref="WhippetMySqlParameter"/> at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetMySqlParameter this[int index]
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
        /// Gets the <see cref="WhippetMySqlParameter"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to retrieve.</param>
        /// <returns>The <see cref="WhippetMySqlParameter"/> with the specified name.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetMySqlParameter this[string parameterName]
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
        /// Gets an object that can be used to synchronize access to the <see cref="WhippetMySqlParameterCollection"/>. This property is read-only.
        /// </summary>
        public override object SyncRoot
        {
            get
            {
                return InternalCollection.SyncRoot;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMySqlParameterCollection(MySqlParameterCollection collection)
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
        /// Adds the specified <see cref="WhippetMySqlParameter"/> object to the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetMySqlParameter"/> to add to the collection.</param>
        /// <returns>A new <see cref="WhippetMySqlParameter"/> object.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        public WhippetMySqlParameter Add(WhippetMySqlParameter value)
        {
            return InternalCollection.Add(value);
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetMySqlParameter"/> object to the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetMySqlParameter"/> to add to the collection.</param>
        /// <returns>The index of the new <see cref="WhippetMySqlParameter"/> object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int Add(object value)
        {
            return InternalCollection.Add(value);
        }

        /// <summary>
        /// Adds a <see cref="WhippetMySqlParameter"/> to the <see cref="WhippetMySqlParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="MySqlDbType"/> values.</param>
        /// <returns>A new <see cref="WhippetMySqlParameter"/> object.</returns>
        public WhippetMySqlParameter Add(string parameterName, MySqlDbType dbType)
        {
            return InternalCollection.Add(parameterName, dbType);
        }

        /// <summary>
        /// Adds a <see cref="WhippetMySqlParameter"/> to the <see cref="WhippetMySqlParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="MySqlDbType"/> values.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <returns>A new <see cref="WhippetMySqlParameter"/> object.</returns>
        public WhippetMySqlParameter Add(string parameterName, MySqlDbType dbType, int size)
        {
            return InternalCollection.Add(parameterName, dbType, size);
        }

        /// <summary>
        /// Adds a <see cref="WhippetMySqlParameter"/> to the <see cref="WhippetMySqlParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="MySqlDbType"/> values.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column <see cref="WhippetMySqlParameter.SourceColumn"/> if this <see cref="WhippetMySqlParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        /// <returns>A new <see cref="WhippetMySqlParameter"/> object.</returns>
        public WhippetMySqlParameter Add(string parameterName, MySqlDbType dbType, int size, string sourceColumn)
        {
            return InternalCollection.Add(parameterName, dbType, size);
        }

        /// <summary>
        /// Adds an array of values to the end of the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="values"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetMySqlParameter"/> objects to add.</param>
        public void AddRange(IEnumerable<WhippetMySqlParameter> values)
        {
            InternalCollection.AddRange(values.ToArray());
        }

        /// <summary>
        /// Adds an array of values to the end of the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="values"><see cref="Array"/> collection of <see cref="WhippetMySqlParameter"/> objects to add.</param>
        public override void AddRange(Array values)
        {
            InternalCollection.AddRange(values);
        }

        /// <summary>
        /// Adds a value to the end of the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="value">The value to be added.</param>
        /// <returns>A <see cref="WhippetMySqlParameter"/> object.</returns>
        public WhippetMySqlParameter AddWithValue(string parameterName, object value)
        {
            return InternalCollection.AddWithValue(parameterName, (value == null) ? DBNull.Value : value);
        }

        /// <summary>
        /// Removes all the <see cref="WhippetMySqlParameter"/> objects from the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        public override void Clear()
        {
            InternalCollection.Clear();
        }

        /// <summary>
        /// Determines whether the specified <see cref="WhippetMySqlParameter"/> is in this <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetMySqlParameter"/> value.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetMySqlParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public bool Contains(WhippetMySqlParameter value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is in this <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="Object"/> value.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetMySqlParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(object value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Determines whether the specified parameter name is in this <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="value">The parameter name to search for.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetMySqlParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(string value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Copies all the elements of the current <see cref="WhippetMySqlParameterCollection"/> to the specified one-dimensional <see cref="Array"/> starting at the specified destination array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from the current <see cref="WhippetMySqlParameterCollection"/>.</param>
        /// <param name="index">The index in <paramref name="array"/> at which copying begins.</param>
        public override void CopyTo(Array array, int index)
        {
            InternalCollection.CopyTo(array, index);
        }

        /// <summary>
        /// Copies all the elements of the current <see cref="WhippetMySqlParameterCollection"/> to the specified one-dimensional <see cref="WhippetMySqlParameter"/> array starting at the specified destination array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="WhippetMySqlParameter"/> array that is the destination of the elements copied from the current <see cref="WhippetMySqlParameterCollection"/>.</param>
        /// <param name="index">The index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(WhippetMySqlParameter[] array, int index)
        {
            InternalCollection.CopyTo(array, index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> for the <see cref="WhippetMySqlParameterCollection"/>.</returns>
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
        /// Gets the location of the specified <see cref="WhippetMySqlParameter"/> within the collection.
        /// </summary>
        /// <param name="value">The <see cref="WhippetMySqlParameter"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="WhippetMySqlParameter"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public int IndexOf(WhippetMySqlParameter value)
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
        /// Gets the location of the specified <see cref="WhippetMySqlParameter"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The case-sensitive name of the <see cref="WhippetMySqlParameter"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="WhippetMySqlParameter"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public override int IndexOf(string parameterName)
        {
            return InternalCollection.IndexOf(parameterName);
        }

        /// <summary>
        /// Inserts a <see cref="WhippetMySqlParameter"/> object into the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">A <see cref="WhippetMySqlParameter"/> object to be inserted in the <see cref="WhippetMySqlParameterCollection"/>.</param>
        public void Insert(int index, WhippetMySqlParameter value)
        {
            InternalCollection.Insert(index, value);
        }

        /// <summary>
        /// Inserts an <see cref="Object"/> object into the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">An <see cref="Object"/> object to be inserted in the <see cref="WhippetMySqlParameterCollection"/>.</param>
        public override void Insert(int index, object value)
        {
            InternalCollection.Insert(index, value);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetMySqlParameter"/> from the collection.
        /// </summary>
        /// <param name="value"><see cref="WhippetMySqlParameter"/> object to remove from the collection.</param>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        public void Remove(WhippetMySqlParameter value)
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
        /// Removes the <see cref="WhippetMySqlParameter"/> from the <see cref="WhippetMySqlParameterCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="WhippetMySqlParameter"/> object to remove.</param>
        public override void RemoveAt(int index)
        {
            InternalCollection.RemoveAt(index);
        }

        /// <summary>
        /// Removes the <see cref="WhippetMySqlParameter"/> from the <see cref="WhippetMySqlParameterCollection"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The name of the <see cref="WhippetMySqlParameter"/> to remove.</param>
        public override void RemoveAt(string parameterName)
        {
            InternalCollection.RemoveAt(parameterName);
        }

        /// <summary>
        /// Sets the parameter at the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the parameter to update.</param>
        /// <param name="value"><see cref="WhippetMySqlParameter"/> to set.</param>
        protected override void SetParameter(int index, DbParameter value)
        {
            this[index] = value as WhippetMySqlParameter;
        }

        /// <summary>
        /// Sets the parameter with the specified parameter name.
        /// </summary>
        /// <param name="parameterName">Name of the parameter to update.</param>
        /// <param name="value"><see cref="WhippetMySqlParameter"/> to set.</param>
        protected override void SetParameter(string parameterName, DbParameter value)
        {
            this[parameterName] = value as WhippetMySqlParameter;
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetMySqlParameter"/> object to the <see cref="WhippetMySqlParameterCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="WhippetMySqlParameter"/> to add to the collection.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        void ICollection<WhippetMySqlParameter>.Add(WhippetMySqlParameter item)
        {
            Add(item);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetMySqlParameter"/> from the collection.
        /// </summary>
        /// <param name="item"><see cref="WhippetMySqlParameter"/> object to remove from the collection.</param>
        /// <returns><see langword="true"/> if the item was removed successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        bool ICollection<WhippetMySqlParameter>.Remove(WhippetMySqlParameter item)
        {
            Remove(item);
            return Contains(item);
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> used to iterate over each item in the collection.</returns>
        IEnumerator<WhippetMySqlParameter> IEnumerable<WhippetMySqlParameter>.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public static implicit operator WhippetMySqlParameterCollection(MySqlParameterCollection collection)
        {
            return (collection == null) ? null : new WhippetMySqlParameterCollection(collection);
        }

        public static implicit operator MySqlParameterCollection(WhippetMySqlParameterCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }
    }
}