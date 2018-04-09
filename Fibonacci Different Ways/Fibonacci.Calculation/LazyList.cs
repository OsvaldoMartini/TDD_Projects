using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Calculation
{
    public class LazyList<T> : IList<T>
    {
        Lazy<IList<T>> _subject = null;

        public LazyList(Func<IList<T>> strategy)
        {
            //crete as instance passing in the delegate that is invoked
            //to produce the lazily initializade value when it is needed.
            _subject = new Lazy<IList<T>>(() => strategy());
        }

        public int IndexOf(T item)
        {
            return _subject.Value.IndexOf(item);
        }


        public void RemoveAt(int index)
        {
            _subject.Value.RemoveAt(index);
        }

        public void Add(T item)
        {
            _subject.Value.Add(item);
        }

        public void Clear()
        {
            _subject.Value.Clear();
        }


        public bool Contains(T item)
        {
            return _subject.Value.Contains(item);
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            _subject.Value.CopyTo(array, arrayIndex);
        }


        public bool IsReadOnly
        {
            get { return _subject.Value.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return _subject.Value.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _subject.Value.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Insert(int index, T item)
        {
            _subject.Value.Insert(index, item);
        }

        public T this[int index]
        {
            get { return _subject.Value[index]; }
            set { _subject.Value.Insert(index, value); }
        }

        public int Count
        {
            get { return _subject.Value.Count; }
        }

    }
}