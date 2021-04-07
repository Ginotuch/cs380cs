using System;
using System.Reflection.Metadata.Ecma335;
using HeapQueue;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PushTest()
        {
            var heapInstance = new HeapQueue.HeapQueue();
            Element[] listToTest =
            {
                new(1, 1),
                new(3, 3),
                new(5, 5),
                new(6, 6),
                new(8, 8)
            };

            foreach (Element element in listToTest)
            {
                heapInstance.Push(element);
                Assert.True(heapInstance.CheckHeap());
            }
        }

        public void Remove(int key)
        {
            throw new System.NotImplementedException();
        }

        [Test]
        public void TestPop()
        {
            var heapInstance = new HeapQueue.HeapQueue();
            Element[] listToTest =
            {
                new(1, 1),
                new(3, 3),
                new(5, 5),
                new(6, 6),
                new(8, 8)
            };

            foreach (Element element in listToTest)
            {
                heapInstance.Push(element);
            }

            foreach (Element element in listToTest)
            {
                var popped = heapInstance.Pop();
                Assert.True(popped.Priority == element.Priority & popped.Key == element.Key);
            }
        }

        [Test]
        public void TestPeek()
        {
            var heapInstance = new HeapQueue.HeapQueue();
            Element[] listToTest =
            {
                new(1, 1),
                new(3, 3),
                new(5, 5),
                new(6, 6),
                new(8, 8)
            };

            foreach (Element pushElement in listToTest)
            {
                heapInstance.Push(pushElement);
            }

            var element = heapInstance.Peek();
            var compareElement = new Element(1, 1);
            Assert.True(element.Key == compareElement.Key && element.Priority == compareElement.Priority);
        }

        public void GetPriority(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Exists(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Extend(Element[] data)
        {
            throw new System.NotImplementedException();
        }

        public void Heapify()
        {
            throw new System.NotImplementedException();
        }

        public void HeapifyDown(int i)
        {
            throw new System.NotImplementedException();
        }

        public void HeapifyUp(int i)
        {
            throw new System.NotImplementedException();
        }

        public void Swap(int parentIndex, int childIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}