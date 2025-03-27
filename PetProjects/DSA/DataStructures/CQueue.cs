namespace DataStructures
{
    // C stands for Custom

    // Types of Queues:
    // 1. Simple - FIFO
    // 2. Circular - last element points to first
    // 3. Priority - insertion on arrival, removal on priority
    // 4. Deque (double ended queue)
    public class CQueue<T>
    {
        // Fields
        public int Capacity;
        public T[] Items;

        // Pointers:
        private int left;
        private int right;

        // Constructor:
        public CQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity cannot be negative!");
            }

            Capacity = capacity;
            left = -1;
            right = -1;
            Items = new T[capacity];
        }

        // Methods: Enque, Deque
        public void PrintItems()
        {
            if (left == -1)
            {
                Console.WriteLine(String.Join(' ', Items[..(right + 1)]));
            }
            else
            {
                Console.WriteLine(String.Join(' ', Items[left..(right + 1)]));
            }
        }

        public void Enqueue(T item)
        {
            if (right == Capacity - 1)
            {
                throw new InvalidOperationException("Queue is full! Cannot enque...");
            }
            Items[++right] = item;
            PrintItems();
        }

        public T Dequeue()
        {
            T popElement = default;

            if (left == right)
            {
                throw new InvalidOperationException("Queue is empty! Cannot dequeue...");
            }

            if (left < right)
            {
                popElement = Items[++left];

                if (left == right)
                {
                    left = -1;
                    right = -1;
                }
            }

            PrintItems();

            return popElement;
        }
    }
}
