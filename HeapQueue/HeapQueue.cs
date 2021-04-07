using System.Collections.Generic;
using System.Net.Mail;

namespace HeapQueue
{
    public class HeapQueue : IHeap
    {
        private List<Element> _array;
        private Dictionary<int, int> _positions;


        public HeapQueue(List<Element> data = null)
        {
            _array = new List<Element>();
            _positions = new Dictionary<int, int>();
        }

        public int Size => _array.Count;

        public void Push(Element newElement)
        {
            if (_positions.ContainsKey(newElement.Key))
            {
                int position = _positions[newElement.Key];
                Element existingElement = _array[position];
                if (newElement.Priority > existingElement.Priority)
                {
                    _array[position] = newElement;
                    HeapifyDown(position);
                }
                else if (newElement.Priority < existingElement.Priority)
                {
                    _array[position] = newElement;
                    HeapifyUp(position);
                }
            }
            else
            {
                _positions.Add(newElement.Key, _array.Count);
                _array.Add(newElement);
                HeapifyUp(_array.Count - 1);
            }
        }

        public Element Remove(int key)
        {
            return Delete(_positions[key]);
        }

        public Element Pop()
        {
            return Delete(0);
        }

        public Element Peek()
        {
            return _array[0];
        }

        public int GetPriority(int key)
        {
            return _array[_positions[key]].Priority;
        }

        public bool Exists(int key)
        {
            return _positions.ContainsKey(key);
        }

        public void Extend(Element[] data)
        {
            throw new System.NotImplementedException();
        }

        public void Heapify()
        {
            throw new System.NotImplementedException();
        }

        private Element Delete(int i)
        {
            var deleted = _array[i];
            var oldLeaf = _array[^1];
            _array[i] = oldLeaf;

            _positions[_array[i].Key] = i;
            _positions.Remove(deleted.Key);
            
            _array.RemoveAt(_array.Count - 1);
            
            if (deleted.Priority > oldLeaf.Priority & i < _array.Count)
            {
                HeapifyUp(i);
            }
            else
            {
                HeapifyDown(i);
            }

            return deleted;
        }

        public void HeapifyDown(int i)
        {
            while (2 * i + 1 < Size)
            {
                var leftChildI = 2 * i + 1;
                var rightChildI = 2 * i + 2;
                var bigChildI = leftChildI;
                if (rightChildI < _array.Count &&
                    _array[leftChildI].Priority >= _array[rightChildI].Priority)
                {
                    bigChildI = rightChildI;
                }

                if (!Swap(i, bigChildI))
                {
                    return;
                }

                i = bigChildI;
            }
        }

        public void HeapifyUp(int i)
        {
            while (i > 0)
            {
                var parentIndex = (i - 1) >> 1;
                if (!Swap(parentIndex, i))
                {
                    return;
                }

                i = parentIndex;
            }
        }

        public bool Swap(int parentIndex, int childIndex)
        {
            var parent = _array[parentIndex];
            var child = _array[childIndex];

            if (parent.Priority > child.Priority)
            {
                _positions[parent.Key] = childIndex;
                _positions[child.Key] = parentIndex;
                _array[parentIndex] = child;
                _array[childIndex] = parent;
                return true;
            }

            return false;
        }

        public bool CheckHeap()
        {
            for (int i = 0; i < Size; i++)
            {
                var element = _array[i];
                if (2 * i + 1 < Size)
                {
                    if (!(element.Priority <= _array[2 * i + 1].Priority))
                    {
                        return false;
                    }

                    if (2 * i + 2 < Size)
                    {
                        if (!(element.Priority <= _array[2 * i + 2].Priority))
                        {
                            return false;
                        }
                    }    
                }
            }

            return true;
        }
    }
}