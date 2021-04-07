using System;

namespace HeapQueue
{
    public struct Element
    {
        public int Key;
        public int Priority;

        public Element(int key, int priority)
        {
            Key = key;
            Priority = priority;
        }
    }

    public interface IHeap
    {
        void Push(Element newElement);
        Element Remove(int key);
        Element Pop();
        Element Peek();
        int GetPriority(int key);
        bool Exists(int key);
        void Extend(Element[] data);
        void Heapify();
        void HeapifyDown(int i);
        void HeapifyUp(int i);
        bool Swap(int parentIndex, int childIndex);
    }
}