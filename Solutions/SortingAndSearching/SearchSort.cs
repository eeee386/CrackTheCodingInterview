using System;
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
        
        public static int BinarySearch(List<int> list, int x)
        {
            int low = 0;
            int high = list.Count;
            int mid;

            while(low <= high)
            {
                mid = (low + high) / 2;
                if(list[mid] < x)
                {
                    low = mid + 1;
                } else if (list[mid] > x)
                {
                    high = mid-1;
                } else
                {
                    return mid;
                }
            }
            throw new Exception('Value is not in List.');
        }
    }
}