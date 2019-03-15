using System;

namespace Solutions.StacksAndQueues
{
    public class Stack<T>
    {
        internal class StackNode<T>
        {
            internal T data;
            internal StackNode<T> Next;
            
            internal StackNode(T data)
            {
                this.data = data;
            }
        }

        private StackNode<T> _top;

        public T Pop()
        {
            if (_top == null)
            {
                throw new Exception("Cannot pop from an empty stack");
            }

            T data = _top.data;
            _top = _top.Next;
            return data;
        }

        public void Push(T data)
        {
            if (_top == null)
            {
                _top = new StackNode<T>(data);
            }
            else
            {
                StackNode<T> temp = _top;
                _top = new StackNode<T>(data) {Next = temp};
            }
        }

        public T Peek()
        {
            if (_top == null)
            {
                throw new Exception("Cannot peek an empty stack");
            }
            else
            {
                return _top.data;
            }
        }

        public bool IsEmpty()
        {
            return _top == null;
        }
    }
}