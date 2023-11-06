using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents a collection of parameters associated with a <see cref="WhippetSqlServerCommand"/> and their respective mappings to columns in a <see cref="DataSet"/>. This class cannot be inherited.
    /// </summary>
    [ListBindable(false)]
    public sealed class WhippetSqlServerParameterCollection : DbParameterCollection, IList<WhippetSqlServerParameter>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlParameterCollection"/> object.
        /// </summary>
        private SqlParameterCollection InternalCollection
        { get; set; }

       
        /// <summary>
        /// Returns an <see cref="Int32"/> that contains the number of elements in the <see cref="WhippetSqlServerParameterCollection"/>. This property is read-only.
        /// </summary>
        public override int Count
        {
            get
            {
                return InternalCollection.Count;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetSqlServerParameterCollection"/> has a fixed size. This property is read-only.
        /// </summary>
        public override bool IsFixedSize
        {
            get
            {
                return InternalCollection.IsFixedSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetSqlServerParameterCollection"/> is read-only. This property is read-only.
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                return InternalCollection.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetSqlServerParameter"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the parameter to retrieve.</param>
        /// <returns>The <see cref="WhippetSqlServerParameter"/> at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetSqlServerParameter this[int index]
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
        /// Gets the <see cref="WhippetSqlServerParameter"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to retrieve.</param>
        /// <returns>The <see cref="WhippetSqlServerParameter"/> with the specified name.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetSqlServerParameter this[string parameterName]
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
        /// Gets an object that can be used to synchronize access to the <see cref="WhippetSqlServerParameterCollection"/>. This property is read-only.
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
        public WhippetSqlServerParameterCollection(SqlParameterCollection collection)
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
        /// Adds the specified <see cref="WhippetSqlServerParameter"/> object to the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetSqlServerParameter"/> to add to the collection.</param>
        /// <returns>A new <see cref="WhippetSqlServerParameter"/> object.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        public WhippetSqlServerParameter Add(WhippetSqlServerParameter value)
        {
            return InternalCollection.Add(value);
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetSqlServerParameter"/> object to the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetSqlServerParameter"/> to add to the collection.</param>
        /// <returns>The index of the new <see cref="WhippetSqlServerParameter"/> object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int Add(object value)
        {
            return InternalCollection.Add(value);
        }

        /// <summary>
        /// Adds a <see cref="WhippetSqlServerParameter"/> to the <see cref="WhippetSqlServerParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="sqlDbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <returns>A new <see cref="WhippetSqlServerParameter"/> object.</returns>
        public WhippetSqlServerParameter Add(string parameterName, SqlDbType sqlDbType)
        {
            return InternalCollection.Add(parameterName, sqlDbType);
        }

        /// <summary>
        /// Adds a <see cref="WhippetSqlServerParameter"/> to the <see cref="WhippetSqlServerParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="sqlDbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <returns>A new <see cref="WhippetSqlServerParameter"/> object.</returns>
        public WhippetSqlServerParameter Add(string parameterName, SqlDbType sqlDbType, int size)
        {
            return InternalCollection.Add(parameterName, sqlDbType, size);
        }

        /// <summary>
        /// Adds a <see cref="WhippetSqlServerParameter"/> to the <see cref="WhippetSqlServerParameterCollection"/> given the parameter name and the data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="sqlDbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column <see cref="WhippetSqlServerParameter.SourceColumn"/> if this <see cref="WhippetSqlServerParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        /// <returns>A new <see cref="WhippetSqlServerParameter"/> object.</returns>
        public WhippetSqlServerParameter Add(string parameterName, SqlDbType sqlDbType, int size, string sourceColumn)
        {
            return InternalCollection.Add(parameterName, sqlDbType, size);
        }

        /// <summary>
        /// Adds an array of values to the end of the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="values"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetSqlServerParameter"/> objects to add.</param>
        public void AddRange(IEnumerable<WhippetSqlServerParameter> values)
        {
            InternalCollection.AddRange(values.ToArray());
        }

        /// <summary>
        /// Adds an array of values to the end of the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="values"><see cref="Array"/> collection of <see cref="WhippetSqlServerParameter"/> objects to add.</param>
        public override void AddRange(Array values)
        {
            InternalCollection.AddRange(values);
        }

        /// <summary>
        /// Adds a value to the end of the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="value">The value to be added.</param>
        /// <returns>A <see cref="WhippetSqlServerParameter"/> object.</returns>
        public WhippetSqlServerParameter AddWithValue(string parameterName, object value)
        {
            return InternalCollection.AddWithValue(parameterName, (value == null) ? DBNull.Value : value);
        }

        /// <summary>
        /// Removes all the <see cref="WhippetSqlServerParameter"/> objects from the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        public override void Clear()
        {
            InternalCollection.Clear();
        }

        /// <summary>
        /// Determines whether the specified <see cref="WhippetSqlServerParameter"/> is in this <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="WhippetSqlServerParameter"/> value.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetSqlServerParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public bool Contains(WhippetSqlServerParameter value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is in this <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="value">The <see cref="Object"/> value.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetSqlServerParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(object value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Determines whether the specified parameter name is in this <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="value">The parameter name to search for.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetSqlServerParameterCollection"/> contains the value; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(string value)
        {
            return InternalCollection.Contains(value);
        }

        /// <summary>
        /// Copies all the elements of the current <see cref="WhippetSqlServerParameterCollection"/> to the specified one-dimensional <see cref="Array"/> starting at the specified destination array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from the current <see cref="WhippetSqlServerParameterCollection"/>.</param>
        /// <param name="index">The index in <paramref name="array"/> at which copying begins.</param>
        public override void CopyTo(Array array, int index)
        {
            InternalCollection.CopyTo(array, index);
        }

        /// <summary>
        /// Copies all the elements of the current <see cref="WhippetSqlServerParameterCollection"/> to the specified one-dimensional <see cref="WhippetSqlServerParameter"/> array starting at the specified destination array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="WhippetSqlServerParameter"/> array that is the destination of the elements copied from the current <see cref="WhippetSqlServerParameterCollection"/>.</param>
        /// <param name="index">The index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(WhippetSqlServerParameter[] array, int index)
        {
            InternalCollection.CopyTo(array, index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> for the <see cref="WhippetSqlServerParameterCollection"/>.</returns>
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
        /// Gets the location of the specified <see cref="WhippetSqlServerParameter"/> within the collection.
        /// </summary>
        /// <param name="value">The <see cref="WhippetSqlServerParameter"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="WhippetSqlServerParameter"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public int IndexOf(WhippetSqlServerParameter value)
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
        /// Gets the location of the specified <see cref="WhippetSqlServerParameter"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The case-sensitive name of the <see cref="WhippetSqlServerParameter"/> to find.</param>
        /// <returns>The zero-based location of the specified <see cref="WhippetSqlServerParameter"/> within the collection or -1 if the object does not exist within the collection.</returns>
        public override int IndexOf(string parameterName)
        {
            return InternalCollection.IndexOf(parameterName);
        }

        /// <summary>
        /// Inserts a <see cref="WhippetSqlServerParameter"/> object into the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">A <see cref="WhippetSqlServerParameter"/> object to be inserted in the <see cref="WhippetSqlServerParameterCollection"/>.</param>
        public void Insert(int index, WhippetSqlServerParameter value)
        {
            InternalCollection.Insert(index, value);
        }

        /// <summary>
        /// Inserts an <see cref="Object"/> object into the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">An <see cref="Object"/> object to be inserted in the <see cref="WhippetSqlServerParameterCollection"/>.</param>
        public override void Insert(int index, object value)
        {
            InternalCollection.Insert(index, value);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetSqlServerParameter"/> from the collection.
        /// </summary>
        /// <param name="value"><see cref="WhippetSqlServerParameter"/> object to remove from the collection.</param>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        public void Remove(WhippetSqlServerParameter value)
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
        /// Removes the <see cref="WhippetSqlServerParameter"/> from the <see cref="WhippetSqlServerParameterCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="WhippetSqlServerParameter"/> object to remove.</param>
        public override void RemoveAt(int index)
        {
            InternalCollection.RemoveAt(index);
        }

        /// <summary>
        /// Removes the <see cref="WhippetSqlServerParameter"/> from the <see cref="WhippetSqlServerParameterCollection"/> with the specified name.
        /// </summary>
        /// <param name="parameterName">The name of the <see cref="WhippetSqlServerParameter"/> to remove.</param>
        public override void RemoveAt(string parameterName)
        {
            InternalCollection.RemoveAt(parameterName);
        }

        /// <summary>
        /// Sets the parameter at the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the parameter to update.</param>
        /// <param name="value"><see cref="WhippetSqlServerParameter"/> to set.</param>
        protected override void SetParameter(int index, DbParameter value)
        {
            this[index] = value as WhippetSqlServerParameter;
        }

        /// <summary>
        /// Sets the parameter with the specified parameter name.
        /// </summary>
        /// <param name="parameterName">Name of the parameter to update.</param>
        /// <param name="value"><see cref="WhippetSqlServerParameter"/> to set.</param>
        protected override void SetParameter(string parameterName, DbParameter value)
        {
            this[parameterName] = value as WhippetSqlServerParameter;
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetSqlServerParameter"/> object to the <see cref="WhippetSqlServerParameterCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="WhippetSqlServerParameter"/> to add to the collection.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentNullException" />
        void ICollection<WhippetSqlServerParameter>.Add(WhippetSqlServerParameter item)
        {
            Add(item);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetSqlServerParameter"/> from the collection.
        /// </summary>
        /// <param name="item"><see cref="WhippetSqlServerParameter"/> object to remove from the collection.</param>
        /// <returns><see langword="true"/> if the item was removed successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SystemException" />
        bool ICollection<WhippetSqlServerParameter>.Remove(WhippetSqlServerParameter item)
        {
            Remove(item);
            return Contains(item);
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> used to iterate over each item in the collection.</returns>
        IEnumerator<WhippetSqlServerParameter> IEnumerable<WhippetSqlServerParameter>.GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public static implicit operator WhippetSqlServerParameterCollection(SqlParameterCollection collection)
        {
            return (collection == null) ? null : new WhippetSqlServerParameterCollection(collection);
        }

        public static implicit operator SqlParameterCollection(WhippetSqlServerParameterCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }
    }
}
