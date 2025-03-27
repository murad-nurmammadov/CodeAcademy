namespace DataStructures
{
    // C stands for Custom
    public class CStack<T>  // T is a type placeholder
    {
        // Fields
        public int Capacity;
        internal int Top;
        internal T[] Items;

        // Constructor
        public CStack(int capacity)
        {
            if (capacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than zero.");
            }

            Capacity = capacity;
            Top = -1;
            Items = new T[Capacity];
        }

        // Methods: Push, Pop
        public void PrintItems()
        {
            Console.WriteLine(String.Join(' ', Items));
        }

        public void Push(T item)
        {
            if (Top == Capacity - 1)
            {
                throw new InvalidOperationException("Stack is full! Cannot push...");
            }

            Items[++Top] = item;
            PrintItems();
        }

        public T Pop()
        {
            if (Top == -1)
            {
                throw new InvalidOperationException("Stack is empty! Cannot pop...");
            }

            // we don't delete item at top, but pointer will still ignore it
            PrintItems();
            return Items[Top--];
        }
    }
}
