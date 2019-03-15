using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.StacksAndQueues
{
    public class SetOfStacks<T>
    {
        private Stack<T> _activeStack = new Stack<T>();
        private readonly HashSet<Stack<T>> setOfStacks = new HashSet<Stack<T>>();
        private int _activeStackNumberOfItems = 0;
        private readonly int capacity = 10;

        public SetOfStacks()
        {
            setOfStacks.Add(_activeStack);
        }

        public void Add(T data)
        {
            if (_activeStackNumberOfItems == capacity)
            {
                Stack<T> newStack = new Stack<T>();
                newStack.Push(data);
                setOfStacks.Add(newStack);
                _activeStack = newStack;
            }
            else
            {
                _activeStack.Push(data);
                _activeStackNumberOfItems++;
            }
        }

        public T Pop()
        {
            T data = _activeStack.Pop();
            
            if (_activeStackNumberOfItems != 0) return data;
            
            if (setOfStacks.Count == 1) return data;
            
            setOfStacks.Remove(_activeStack);
            _activeStack = setOfStacks.Last();

            return data;
        }
        //For this the set could be changed for Array for easier access.
        public T PopAtSpecifiedStack(int index)
        {
            if (setOfStacks.Count - 1 < index)
            {
                throw new Exception("You cannot pop from a non-existent Stack!");
            }
            int counter = 0;
            foreach (Stack<T> stack in setOfStacks)
            {
                if (counter == index)
                {
                    return stack.Pop();
                }

                counter++;
            }

            throw new Exception("Invalid execution of method.");
        }
    }
}