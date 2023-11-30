using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************

    // Aggregate interface
    interface IAbstractCollection<T>
    {
        IIterator<T> GetIterator();
    }

    // Iterator interface
    interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    // Concrete collection
    class CustomList<T> : IAbstractCollection<T>
    {
        private readonly List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public IIterator<T> GetIterator()
        {
            return new CustomListIterator<T>(this);
        }

        public int Count()
        {
            return items.Count;
        }

        public T GetItem(int index)
        {
            return items[index];
        }
    }

    // Concrete iterator
    class CustomListIterator<T> : IIterator<T>
    {
        private readonly CustomList<T> collection;
        private int index;

        public CustomListIterator(CustomList<T> collection)
        {
            this.collection = collection;
            index = 0;
        }

        public bool HasNext()
        {
            return index < collection.Count();
        }

        public T Next()
        {
            if (HasNext())
            {
                T item = collection.GetItem(index);
                index++;
                return item;
            }
            throw new InvalidOperationException("No more elements in the collection.");
        }
    }

    // ****************************************  Example 02 *******************************************

    // Concrete Iterator
    class ArrayIterator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int index = -1;

        public ArrayIterator(T[] array)
        {
            this.array = array;
        }

        public T Current => array[index];

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            index++;
            return index < array.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
