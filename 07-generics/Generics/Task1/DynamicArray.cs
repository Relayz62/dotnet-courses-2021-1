using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class DynamicArray<T> where T : new()
    {
        private T[] _itemsArray;
        private static readonly T[] _emptyArray = new T[0];
        private static readonly int _defaultCapacity = 8;

        public DynamicArray()
        {
            Length = 0;
            _itemsArray = new T[_defaultCapacity];
        }

        public DynamicArray(int capacity)
        {
            if (_defaultCapacity < 0) throw new ArgumentOutOfRangeException();
            if (_defaultCapacity == 0) _itemsArray = _emptyArray;
            else _itemsArray = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();

            ICollection<T> listCollection = collection as ICollection<T>;
            if (listCollection != null)
            {
                int count = listCollection.Count;
                if (count == 0)
                {
                    _itemsArray = _emptyArray;
                }
                else
                {
                    _itemsArray = new T[count];
                    listCollection.CopyTo(_itemsArray, 0);
                    Length = count;
                }
            }
            else
            {
                Length = 0;
                _itemsArray = _emptyArray;
            }
        }

        public DynamicArray(T[] array)
        {
            if(array == null)
            {
                _itemsArray = _emptyArray;
                Length = 0;
            }
            else
            {
                Length = array.Length;
                _itemsArray = new T[Length];
                array.CopyTo(_itemsArray, 0);
            }
        }

        public int Length
        {
            get; private set;
        }

        public int Capacity
        {
            get { return _itemsArray.Length; }
            set
            {
                if (value < Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (Length > 0)
                        {
                            Array.Copy(_itemsArray, 0, newItems, 0, Length);
                        }
                        _itemsArray = newItems;
                    }
                    else
                    {
                        _itemsArray = _emptyArray;
                    }
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Length) throw new ArgumentOutOfRangeException();
                else return _itemsArray[index];
            }
            set
            {
                if (index >= Length) throw new ArgumentOutOfRangeException();
                else _itemsArray[index] = value;
            }
        }

        public void Add(T value)
        {
            if(Length == Capacity)
            {
                Array.Resize(ref _itemsArray, _itemsArray.Length * 2);
            }
            _itemsArray[Length++] = value;
        }

        public void AddRange(params T[] values)
        {
            int size = _itemsArray.Length;
            if (_itemsArray.Length < values.Length + Length)
            {
                while (size < values.Length + Length)
                {
                    size = size * 2;
                }
                Array.Resize(ref _itemsArray, size);
            }
            values.CopyTo(_itemsArray, Length);
            Length += values.Length;
        }

        public bool Remove(T value)
        {
            for (int i = 0; i < Length; i++)
            {
                if(Equals(_itemsArray[i],value))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        private void RemoveAt(int index)
        {
            if (index >= Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            Length--;
            if (index < Length)
            {
                Array.Copy(_itemsArray, index + 1, _itemsArray, index, Length - index);
            }
            _itemsArray[Length] = default(T);
        }

        public void Insert(int index, T value)
        {
            if (index > Capacity)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Capacity == _itemsArray.Length) Capacity++;
            if (index < Capacity)
            {
                Array.Copy(_itemsArray, index, _itemsArray, index + 1, Length - index);
            }
            _itemsArray[index] = value;
            Length++;
        }


        public void PrintDynamicArray()
        {
            Console.WriteLine("/////////////////////////////////////");
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine(_itemsArray[i]);
            }
            Console.WriteLine($"Capacity: {Capacity}");
            Console.WriteLine($"Length: {Length}");
        }
    }
}
