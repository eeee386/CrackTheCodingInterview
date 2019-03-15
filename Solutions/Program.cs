using System;
using System.Collections;
using System.Collections.Generic;

namespace Solutions
{
    class Program
    {
        static bool IsPalindrome(LinkedList<int> linkedList)
        {
            if (linkedList.Count == 1)
            {
                return true;
            }

            if (linkedList.First.Value != linkedList.Last.Value)
            {
                return false;
            }

            if (linkedList.Count == 2)
            {
                return true;
            }

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            return IsPalindrome(linkedList);
        }


        static StacksAndQueues.Stack<int> SortStack(StacksAndQueues.Stack<int> stack)
        {
            StacksAndQueues.Stack<int> sortedStack = new StacksAndQueues.Stack<int>();

            while (!stack.IsEmpty())
            {
                int temp = stack.Pop();
                while (!sortedStack.IsEmpty() && sortedStack.Peek() > temp)
                {
                    stack.Push(sortedStack.Pop());
                }

                sortedStack.Push(stack.Pop());
            }

            while (!sortedStack.IsEmpty())
            {
                stack.Push(sortedStack.Pop());
            }

            return stack;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Solutions.IsRotatedString("waterbottle", "erbottlewat"));
//            LinkedListImplementation linkedListImplementation = new LinkedListImplementation();
//            LinkedListImplementation linkedListImplementation2 = new LinkedListImplementation();
            Random rnd = new Random();
//            for (int i = 0; i < 3; i++)
//            {
//                int numberToAdd = 0;
//                numberToAdd = rnd.Next(i == 0 ? 1 : 0, 10);
//                linkedListImplementation.AddToTail(numberToAdd);
//            }
//
//            for (int i = 0; i < 3; i++)
//            {
//                int numberToAdd = 0;
//                numberToAdd = rnd.Next(i == 2 ? 1 : 0, 10);
//                linkedListImplementation2.AddToTail(numberToAdd);
//            }
//
//            LinkedList<int> linkedList = new LinkedList<int>();
//            linkedList.AddFirst(1);
//            linkedList.AddLast(2);
//            linkedList.AddLast(3);
//            linkedList.AddLast(4);
//            linkedList.AddLast(3);
//            linkedList.AddLast(2);
//            linkedList.AddLast(1);
//
//            foreach (int i in linkedList)
//            {
//                Console.WriteLine(i);
//            }
//
//            Console.WriteLine(IsPalindrome(linkedList));

//            Console.WriteLine(linkedListImplementation.Size());
//            linkedListImplementation.WriteToConsole();

//            Console.WriteLine(LinkedListSolutions.RemoveDuplicates(linkedListImplementation));

//            Console.WriteLine(linkedListImplementation.Size());
//            linkedListImplementation.WriteToConsole();

//            linkedListImplementation.WriteToConsole();
//            Console.WriteLine();
//            LinkedListSolutions.DeleteFromMiddle(linkedListImplementation, 5);
//            Console.WriteLine();
//            linkedListImplementation.WriteToConsole();
//            linkedListImplementation = LinkedListSolutions.Partition(linkedListImplementation, 4);
//            
//            linkedListImplementation.WriteToConsole();

//            linkedListImplementation.WriteToConsole();
//            linkedListImplementation2.WriteToConsole();
//
//            Console.WriteLine(LinkedListSolutions.SumListsReverseOrder(linkedListImplementation, linkedListImplementation2));
//            Console.WriteLine(LinkedListSolutions.SumListsForwardOrder(linkedListImplementation, linkedListImplementation2));

//            Queue<int> queue = new Queue<int>();
//            for (int i = 0; i < 100; i++)
//            {
//                int numberToAdd = rnd.Next(i == 0 ? 1 : 0, 10000);
//                queue.Add(numberToAdd);
//            }
//            queue.WriteToConsole();
//            Console.WriteLine();
//            Console.WriteLine(queue.GetMin());
            
           
        }
    }
}