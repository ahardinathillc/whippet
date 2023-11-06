using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Athi.Whippet.Collections
{
    /// <summary>
    /// Represents an inverted <see cref="Stack{T}"/> where the 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InvertedStack<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
    {
        private SortedList<int, T> _internalList;

        /// <summary>
        /// Gets the internal list that serves as the stack. This property is read-only.
        /// </summary>
        private SortedList<int, T> InternalList
        {
            get
            {
                if(_internalList == null)
                {
                    _internalList = new SortedList<int, T>();
                }

                return _internalList;
            }
        }

        /// <summary>
        /// Indicates whether the current collection is thread safe. This property is read-only.
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get
            {
                return ((ICollection)(InternalList)).IsSynchronized;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>. This property is read-only.
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                return ((ICollection)(InternalList)).SyncRoot;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="InvertedStack{T}"/>. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return InternalList.Count;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvertedStack{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public InvertedStack()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvertedStack{T}"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        /// <exception cref="ArgumentNullException" />
        public InvertedStack(IEnumerable<T> collection)
            : this()
        { 
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                int i = 0;

                foreach(T element in collection)
                {
                    InternalList.Add(i, element);
                    i++;
                }
            }
        }

        /// <summary>
        /// Removes all objects from the <see cref="InvertedStack{T}"/>.
        /// </summary>
        public void Clear()
        {
            InternalList.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="InvertedStack{T}"/>. The value can be <see langword="null"/> for reference types.</param>
        /// <returns><see langword="true"/> if item is found in the <see cref="InvertedStack{T}"/>; otherwise, <see langword="false"/>.</returns>
        public bool Contains(T item)
        {
            return InternalList.ContainsValue(item);
        }

        /// <summary>
        /// Copies the <see cref="InvertedStack{T}"/> to an existing one-dimensional <see cref="Array"/>, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="InvertedStack{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public void CopyTo(T[] array, int arrayIndex)
        {
            InternalList.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="InvertedStack{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)(InternalList.Values)).CopyTo(array, index);
        }

        /// <summary>
        /// Returns an enumerator for the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> for the <see cref="InvertedStack{T}"/>.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Walk(TraversalDirection.TopToBottom);
        }

        /// <summary>
        /// Walks the <see cref="InvertedStack{T}"/> based on the specified direction.
        /// </summary>
        /// <param name="direction"><see cref="TraversalDirection"/> value that dictates how to walk the <see cref="InvertedStack{T}"/>.</param>
        /// <returns><see cref="IEnumerator{T}"/> for iterating each item in the <see cref="InvertedStack{T}"/>.</returns>
        public IEnumerator<T> Walk(TraversalDirection direction)
        {
            if(direction == TraversalDirection.TopToBottom)
            {
                foreach(T value in (from entry in InternalList orderby entry.Key ascending select entry.Value))
                {
                    yield return value;
                }
            }
            else
            {
                foreach (T value in (from entry in InternalList orderby entry.Key descending select entry.Value))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator for the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> for the <see cref="InvertedStack{T}"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Returns the object at the bottom of the <see cref="InvertedStack{T}"/> without removing it.
        /// </summary>
        /// <param name="top">If <see langword="true"/>, will peek the item at the top of the stack; otherwise, will peek the item at the bottom of the stack.</param>
        /// <returns>The object at the bottom of the <see cref="InvertedStack{T}"/>.</returns>
        /// <exception cref="InvalidOperationException" />
        public T Peek(bool top = false)
        {
            if(!InternalList.Any())
            {
                throw new InvalidOperationException();
            }
            else
            {
                return !top ? InternalList.Last().Value : InternalList.First().Value;
            }
        }

        /// <summary>
        /// Removes and returns the object at the bottom of the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <param name="top">If <see langword="true"/>, will pop the item at the top of the stack; otherwise, will pop the item at the bottom of the stack.</param>
        /// <returns>The object removed at the bottom of the <see cref="InvertedStack{T}"/>.</returns>
        /// <exception cref="InvalidOperationException" />
        public T Pop(bool top = false)
        {
            if(!InternalList.Any())
            {
                throw new InvalidOperationException();
            }
            else
            {
                int indexOfItem = top ? InternalList.First().Key : InternalList.Last().Key;
                T item = InternalList[indexOfItem];
                
                InternalList.Remove(indexOfItem);

                return item;
            }
        }

        /// <summary>
        /// Inserts an object at the bottom of the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <param name="item">The object to push onto the <see cref="InvertedStack{T}"/>. This value can be <see langword="null"/> for reference types.</param>
        public void Push(T item)
        {
            InternalList.Add(InternalList.Any() ? InternalList.Last().Key + 1 : 0, item);
        }

        /// <summary>
        /// Copies the <see cref="InvertedStack{T}"/> to a new array.
        /// </summary>
        /// <returns>A new array containing copies of the elements of the <see cref="InvertedStack{T}"/>.</returns>
        public T[] ToArray()
        {
            return InternalList.Values.ToArray();
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the <see cref="InvertedStack{T}"/>, if that number is less than 90 percent of current capacity.
        /// </summary>
        public void TrimExcess()
        {
            InternalList.TrimExcess();
        }

        /// <summary>
        /// Returns a value that indicates whether there is an object at the bottom of the <see cref="InvertedStack{T}"/>, and if one is present, copies it to the result parameter. The object is not removed from the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <param name="result">If present, the object at the bottom of the <see cref="InvertedStack{T}"/>; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="top">If <see langword="true"/>, will peek the item at the top of the stack; otherwise, will peek the item at the bottom of the stack.</param>
        /// <returns><see langword="true"/> if there is an object at the bottom of the <see cref="InvertedStack{T}"/>; <see langword="false"/> if the <see cref="InvertedStack{T}"/> is empty.</returns>
        public bool TryPeek([MaybeNullWhen(false)] out T result, bool top = false)
        {
            bool peeked = false;

            try
            {
                result = Peek(top);
            }
            catch
            {
                peeked = false;
                result = default(T);
            }

            return peeked;
        }

        /// <summary>
        /// Returns a value that indicates whether there is an object at the bottom of the <see cref="InvertedStack{T}"/>, and if one is present, copies it to the result parameter. The object is removed from the <see cref="InvertedStack{T}"/>.
        /// </summary>
        /// <param name="result">If present, the object at the bottom of the <see cref="InvertedStack{T}"/>; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="top">If <see langword="true"/>, will peek the item at the top of the stack; otherwise, will peek the item at the bottom of the stack.</param>
        /// <returns><see langword="true"/> if there is an object at the bottom of the <see cref="InvertedStack{T}"/>; <see langword="false"/> if the <see cref="InvertedStack{T}"/> is empty.</returns>
        public bool TryPop([MaybeNullWhen(false)] out T result, bool top = false)
        {
            bool popped = false;

            try
            {
                result = Pop(top);
            }
            catch
            {
                popped = false;
                result = default(T);
            }

            return popped;
        }
    }
}
