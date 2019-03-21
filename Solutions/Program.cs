using System;
using System.Collections;
using System.Collections.Generic;
using Solutions.BitManipulation;

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
//            Console.WriteLine(Convert.ToString(23, 2));
//            Console.WriteLine(new Bit(23).GetBitAtPosition(3));
//            Console.WriteLine(Convert.ToString(456, 2));
//            Console.WriteLine(Convert.ToString(Bit.Insertion(456, 4, 2, 6), 2));
//            Console.WriteLine();
//
//            Console.WriteLine(Bit.DoubleFractionToBinaryString(0.33345));
//            Console.WriteLine(Bit.DoubleFractionToBinaryString(0.9666));
//            Console.WriteLine(Bit.DoubleFractionToBinaryString(0.6783345));
//            Console.WriteLine();
//
//            Console.WriteLine(new Bit(13).FindLongestSequenceOfFlipped());
//            Console.WriteLine(Convert.ToString(13, 2));
//            Console.WriteLine(new Bit(39).FindLongestSequenceOfFlipped());
//            Console.WriteLine(Convert.ToString(39, 2));
//            Console.WriteLine(new Bit(34).FindLongestSequenceOfFlipped());
//            Console.WriteLine(Convert.ToString(34, 2));
//            Console.WriteLine();
//            
//            Console.WriteLine(Convert.ToString(13, 2));
//            Console.WriteLine(Convert.ToString(new Bit(13).FindNextSmallestOfBits(), 2));
//            Console.WriteLine(Convert.ToString(new Bit(13).FindNextLargestOfBits(), 2));
//            
//            Console.WriteLine(Convert.ToString(39, 2));
//            Console.WriteLine(Convert.ToString(new Bit(39).FindNextSmallestOfBits(), 2));
//            Console.WriteLine(Convert.ToString(new Bit(39).FindNextLargestOfBits(), 2));
//            
//            Console.WriteLine(Convert.ToString(2356, 2));
//            Console.WriteLine(Convert.ToString(new Bit(2356).FindNextSmallestOfBits(), 2));
//            Console.WriteLine(Convert.ToString(new Bit(2356).FindNextLargestOfBits(), 2));
            
//            Console.WriteLine(Convert.ToString(13, 2));
//            Console.WriteLine(Convert.ToString(new Bit(13).PairwiseSwap(), 2));
//            
//            Console.WriteLine(Convert.ToString(341, 2));
//            Console.WriteLine(Convert.ToString(new Bit(341).PairwiseSwap(), 2));
//            
//            Console.WriteLine(Convert.ToString(754, 2));
//            Console.WriteLine(Convert.ToString(new Bit(754).PairwiseSwap(), 2));

            byte[] screen = new byte[40];
            Bit.DrawLine(screen, 40, 12, 35, 2);
        }
    }
}