using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Solutions.TreesAndGraphs;

namespace Solutions.SortingAndSearching
{
    public static class SearchSort
    {
        public static List<int> BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return list;
        }

        public static List<int> SelectionSort(List<int> list)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                int min = list[j];
                int index = j;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] < min)
                    {
                        min = list[i];
                        index = i;
                    }
                }

                int temp = list[j];
                list[j] = min;
                list[index] = temp;

            }

            return list;
        }

        public static List<int> MergeSort(List<int> list)
        {
            int[] helper = new int[list.Count];
            return Sort(list, helper, 0, list.Count - 1);

        }

        private static List<int> Sort(List<int> list, int[] helper, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                Sort(list, helper, low, middle);
                Sort(list, helper, middle + 1, high);
                Merge(list, helper, low, middle, high);
            }

            return list;
        }

        private static void Merge(List<int> list, int[] helper, int low, int middle, int high)
        {
            for (int i = low; i <= high; i++)
            {
                Console.WriteLine(helper[i]);
                helper[i] = list[i];
            }

            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;

            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    list[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    list[current] = helper[helperRight];
                    helperRight++;
                }

                current++;
            }

            int remaining = middle - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                list[current + 1] = helper[helperLeft + 1];
            }
        }

        public static List<int> QuickSort(List<int> list)
        {
            QuickSortHelper(list, 0, list.Count - 1);
            return list;
        }

        private static List<int> QuickSortHelper(List<int> list, int left, int right)
        {
            int index = Partition(list, left, right);
            if (left < index - 1)
            {
                QuickSortHelper(list, left, index - 1);
            }

            if (right > index)
            {
                QuickSortHelper(list, index, right);
            }
        }

        private static int Partition(List<int> list, int left, int right)
        {
            int pivot = list[right];

            int i = left - 1;
            int j;
            int temp;

            for (j = left; j < right - 1; j++)
            {
                if (list[j] <= pivot)
                {
                    i++;
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            int pivotIndex = i + 1;
            temp = list[pivotIndex];
            list[pivotIndex] = list[j];
            list[j] = temp;
            return pivotIndex;
        }
    }
}