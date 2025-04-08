using System.Text;
using CustomList.Exceptions;

namespace CustomList
{
    internal class ListInt
    {
        // Fields
        private int[] _intArr = [];
        private int _capacity;
        int _pivot;

        // Properties
        public int[] IntArr
        {
            get => _intArr;
            set
            {
                _intArr = value;
                Pivot = value.Length - 1;
                int newSize = value.Length + (Capacity - value.Length % Capacity);
                Array.Resize(ref _intArr, newSize);
            }
        }
        public int Capacity { get => _capacity; }
        public int Pivot
        {
            get => _pivot;
            set => _pivot = value;
        }

        // Indexer
        public int this[int index]
        {
            get => _intArr[index];
            set => _intArr[index] = value;
        }

        // Constructor
        public ListInt(int capacity = 1)
        {
            _capacity = capacity;
            Pivot = -1;
        }

        // METHODS:
        #region Basics
        public void Add(int value)
        {
            // If array is full, resize
            if (IntArr.Length - 1 == Pivot)
            {
                Array.Resize(ref _intArr, IntArr.Length + Capacity);
            }
            IntArr[++Pivot] = value;
        }
        public void Insert(int index, int value)
        {
            if (index < 0 || index > Pivot)
            {
                throw new IndexOutOfRangeException();
            }
            // If array is full, resize
            else if (IntArr.Length - 1 == Pivot)
            {
                Array.Resize(ref _intArr, IntArr.Length + Capacity);
            }

            // Find index
            for (int i = 0; i < Pivot; i++)
            {
                if (i == index)
                {
                    // Shift everything from index to the left
                    for (int j = ++Pivot; j > i; j--)
                    {
                        IntArr[j] = IntArr[j - 1];
                    }
                    // Insert the value
                    IntArr[i] = value;
                    return;
                }
            }
        }
        public int Pop() { return IntArr[Pivot--]; }
        public void Remove(int num)
        {
            int[] newArr = new int[IntArr.Length];
            int newCount = 0;

            for (int i = 0; i < Pivot; i++)
            {
                if (IntArr[i] == num) { continue; }
                newArr[newCount++] = IntArr[i];
            }

            IntArr = newArr;
            Pivot = newCount - 1;
        }
        #endregion

        #region Index, Contains
        public int IndexOf(int num)
        {
            for (int i = 0; i < Pivot; i++)
            {
                if (IntArr[i] == num) { return i; }
            }
            throw new IndexNotFoundException();
        }
        public int LastIndexOf(int num)
        {
            int lastIndex = -1;
            for (int i = 0; i < Pivot; i++)
            {
                if (IntArr[i] == num) { lastIndex = i; }
            }

            if (lastIndex == -1) { throw new IndexNotFoundException(); }
            else return lastIndex;
        }
        public bool Contains(int value)
        {
            foreach (int i in IntArr)
            {
                if (i == value) return true;
            }
            return false;
        }
        #endregion

        #region Statistics
        public int Sum()
        {
            int sum = 0;
            foreach (int i in IntArr) { sum += i; }
            return sum;
        }
        public float Average()
        {
            float average = (float)IntArr.Sum() / (Pivot + 1);
            return average;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IntArr.Length; i++)
            {
                if (i == Pivot) { sb.Append($"[{IntArr[i]}] "); }  // highlighting pivoted element
                else sb.Append($"{IntArr[i]} ");
            }
            return sb.ToString();
        }
    }
}
