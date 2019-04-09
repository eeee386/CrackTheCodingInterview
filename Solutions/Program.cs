using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Solutions.BitManipulation;
using Solutions.TreesAndGraphs;

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

        public static int[] SortedMerge(int[] a, int[] b)
        {
            int[] helper = new int[a.Length + b.Length];
            a.CopyTo(helper, 0);
            b.CopyTo(helper, a.Length);
            int aIndex = 0;
            int bIndex = 0;
            int hIndex = 0;
            while (aIndex < a.Length && bIndex < b.Length)
            {
                if (a[aIndex] <= b[bIndex])
                {
                    helper[hIndex] = a[aIndex];
                    aIndex++;
                }
                else
                {
                    helper[hIndex] = b[bIndex];
                    bIndex++;
                }

                hIndex++;
            }

            int remaining = a.Length - aIndex;

            for (int g = 0; g < remaining; g++)
            {
                helper[hIndex] = a[aIndex + g];
                hIndex++;
            }

            return helper;
        }

        private static List<string> GroupAnagrams(List<string> strings)
        {
            var dict = new Dictionary<string, List<string>>();
            List<string> groupedList = new List<string>();
            foreach (var str in strings)
            {
                var cs = str.ToCharArray();
                Array.Sort(cs);
                var key = cs.ToString();
                if (dict[key] == null)
                {
                    dict.Add(key, new List<string>());
                    dict[key].Add(str);
                }
            }

            foreach (var obj in dict)
            {
                groupedList.AddRange(dict[obj.Key]);
            }

            return groupedList;
        }

        public static int FindValueInRotatedArray(List<int> list, int x)
        {
            int pivot = FindPivotInRotatedArray(list);

            if (pivot == -1)
            {
                return SortingAndSearching.SearchSort.BinarySearch(list, x);
            }
            else
            {
                if (list[0] > x && list[list.Count - 1] < x)
                {
                    return -1;
                }
                else if (list[0] <= x)
                {
                    return SortingAndSearching.SearchSort.BinarySearch(list.GetRange(0, pivot), x);
                }
                else
                {
                    return SortingAndSearching.SearchSort.BinarySearch(list.GetRange(pivot, list.Count - pivot), x);
                }
            }
        }

        public static int FindPivotInRotatedArray(List<int> list)
        {
            int high = list.Count - 1;
            int low = 0;

            while (high > low)
            {
                int mid = (high + low) / 2;
                if (mid < high && list[mid] > list[mid + 1])
                {
                    return mid;
                }

                if (mid > low && list[mid] < list[mid - 1])
                {
                    return mid + 1;
                }

                if (list[low] > list[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid;
                }
            }

            return -1;
        }

        public static int SortedSearchNoSize(int x)
        {
            // Prepare Listy
            Random rnd = new Random();
            List<int> listy = new List<int>(rnd.Next());
            for (int i = 0; i < listy.Capacity; i++)
            {
                listy[i] = rnd.Next();
            }
            // end prepare.

            if (listy.Count == 0)
            {
                return -1;
            }

            int indexPlusOne = 1;

            while (true)
            {
                if (listy[indexPlusOne - 1] == x)
                {
                    return indexPlusOne - 1;
                }

                if (listy[indexPlusOne - 1] == -1 || listy[indexPlusOne - 1] > x)
                {
                    //Listy does not have a Capacity method! it is just for not throwing error;
                    return SortingAndSearching.SearchSort.BinarySearch(
                        listy.GetRange(indexPlusOne - 1, listy.Capacity - indexPlusOne - 1), x);
                }

                if (listy[indexPlusOne] != -1 && listy[indexPlusOne - 1] < x)
                {
                    indexPlusOne = indexPlusOne * 2;
                }
            }
        }

        public static int SparseSearch(List<string> list, string s)
        {
            int low = 0;
            int high = list.Count;
            int mid;
            int compareValue = 1;
            while (low < high)
            {
                mid = (high + low) / 2;
                if (list[mid] == "")
                {
                    if (compareValue == -1)
                    {
                        for (int i = mid; i < high; i++)
                        {
                            if (list[i] != "")
                            {
                                mid = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = mid; i >= low; i--)
                        {
                            if (list[i] != "")
                            {
                                mid = i;
                            }
                        }
                    }
                }

                compareValue = String.CompareOrdinal(list[mid], s);
                if (compareValue == 0)
                {
                    return mid;
                }

                if (compareValue == -1)
                {
                    low = mid;
                }

                if (compareValue == 1)
                {
                    high = mid;
                }
            }

            return -1;
        }

        public static void swap(int[] array, int i, int j)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }

        public static void SubOptimalPeaksAndValleys(int[] array)
        {
            Array.Sort(array);
            for (int i = 1; i < array.Length; i = i + 2)
            {
                swap(array, i, i-1);
            }
        }

        public static void PeaksAndValleys(int[] array)
        {
            for (int i = 0; i < array.Length; i = i + 2)
            {
                if (i > 0 && array[i] < array[i - 1])
                {
                    swap(array, i, i-1);
                }

                if (i < array.Length - 1 && array[i] < array[i + 1])
                {
                    swap(array, i, i+1);
                }
            }
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

//            byte[] screen = new byte[40];
//            Bit.DrawLine(screen, 40, 12, 35, 2);
//            int[] ints = {9, 8, 3, 7, 1, 97, 3, 7, 4, 6, 4, 66, 225, 442, 123, 42, 123, 53, 664, 63, 24, 73};
//            List<int> list = new List<int>(ints);
//
//            int[] ints2 = {1, 2, 3, 4};
//            int[] ints3 = {5, 6, 7, 8};
//            List<int>[] intlists = {new List<int>(ints2), new List<int>(ints3)};
//            List<List<int>> matrix = new List<List<int>>( intlists);
//
//            SortingAndSearching.SearchSort.MergeSort(list);
////            Console.WriteLine(list);
//
//            Console.WriteLine(SortingAndSearching.SearchSort.TwoDimensionalMatrixBinarySearch(matrix, 9));

            int[] a = {1, 5, 2, 6, 4, 8, 33, 66, 46, 75, 81, 1, 84, 1, 67, 32, 28, 61, 64, 86, 39};
            PredicatedHeap p = new PredicatedHeap(31, HeapType.MIN);
            foreach (int i in a)
            {
                p.Add(i);
            }
        }
    }
}