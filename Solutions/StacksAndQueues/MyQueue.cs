using System;

namespace Solutions.StacksAndQueues
{
    public class MyQueue<T>
    {
        internal class QueueNode<T>
        {
            internal QueueNode<T> Next;
            internal readonly T Data;

            internal QueueNode(T data)
            {
                this.Data = data;
            }
        }

        private QueueNode<T> _first;
        private QueueNode<T> _last;
        private int _min = Int32.MaxValue;

        public void Enqueue(T data)
        {
            QueueNode<T> node = new QueueNode<T>(data);
            if (_last != null)
            {
                _last.Next = node;
                _last = node;
            }

            if (_first == null)
            {
                _first = node;
                _last = _first;
            }
//For 3.2 GetMin not part of the initial Queue;
            if (data is int)
            {
                Min(Convert.ToInt32(data));
            }
        }

        public T Dequeue()
        {
            if (_first == null)
            {
                throw new Exception("You cannot dequeue from an empty Queue.");
            }

            T data = _first.Data;
            _first = _first.Next;
            return data;
        }

        public T Peek()
        {
            if (_first == null)
            {
                throw new Exception("You cannot Peek an empty Queue!");
            }
            return _first.Data;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }

        public void Min(int data)
        {
            if (data < _min)
            {
                _min = data;
            }
        }

        public int GetMin()
        {
            return _min;
        }

        public void WriteToConsole()
        {
            QueueNode<T> n = _first;
            while (n != null)
            {
                Console.WriteLine(n.Data);
                n = n.Next;
            }
        }
    }
}