using System;

namespace HeapQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            HeapQueue heapQueue = new HeapQueue();
            heapQueue.Push(new Element(1, 2));
            Console.WriteLine($"Popped {heapQueue.Pop().Key}");
        }
    }
}