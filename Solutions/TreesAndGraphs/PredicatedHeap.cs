using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Solutions.TreesAndGraphs
{
    public enum HeapType
    {
        MAX,
        MIN,
    }
    
    public class PredicatedHeap
    {
        private List<int> heap = new List<int>();
        public readonly HeapType Type;

        public PredicatedHeap(int root, HeapType type)
        {
            heap.Add(root);
            Type = type;
        }

        public void Add(int data)
        {
            heap.Add(data);
            
            int indexOfNewElement = heap.Count - 1;
            int parentIndexOfNewElement = FindParentIndex(indexOfNewElement);
            
            int newElement = heap[indexOfNewElement];
            int parentOfNewElement = heap[parentIndexOfNewElement];
            
            while (indexOfNewElement != 0)
            {
                if (Predicate(newElement, parentOfNewElement))
                {
                    heap[indexOfNewElement] = parentOfNewElement;
                    heap[parentIndexOfNewElement] = newElement;
                    
                    indexOfNewElement = parentOfNewElement;
                    parentIndexOfNewElement = FindParentIndex(indexOfNewElement);
                    
                    newElement = heap[indexOfNewElement];
                    parentOfNewElement = heap[parentIndexOfNewElement];
                }
                else
                {
                    break;
                }
            }
        }

        public int Remove()
        {
            int min = heap[0];

            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            Tuple<int, int> childIndices = FindChildIndices(0);
            if (childIndices.Item1 > heap.Count - 1 || childIndices.Item2 > heap.Count - 1)
            {
                if (childIndices.Item1 > heap.Count - 1) ;
                {
                    return min;
                }
            } 
            int? firstChild = heap[childIndices.Item1];
            int? secondChild = heap[childIndices.Item2];
            int parent = heap[0];

            while (firstChild != null && (Predicate((int)firstChild, parent) || (secondChild != null && Predicate((int)secondChild, parent))))
            {
                if (secondChild != null && Predicate((int)secondChild, (int)firstChild))
                {
                    heap[childIndices.Item2] = parent;
                    childIndices = FindChildIndices(childIndices.Item2);
                    
                }
                else
                {
                    heap[childIndices.Item1] = parent;
                    childIndices = FindChildIndices(childIndices.Item1);
                }
                firstChild = childIndices.Item1 < heap.Count ? heap[childIndices.Item1] : (int?) null;
                secondChild = childIndices.Item2 < heap.Count ? heap[childIndices.Item2] : (int?) null;
            }
            return min;
        }

        private static int FindParentIndex(int index)
        {
            if (index == 0)
            {
                throw new Exception("Root element cannot have a parent.");
            }
            int adjustedIndex = index + 1;
            int adjustedParentIndex;
            if (index % 2 == 0)
            {
                adjustedParentIndex = adjustedIndex / 2;
            }
            else
            {
                adjustedParentIndex = (adjustedIndex - 1) / 2;
            }

            return adjustedParentIndex - 1;
        }

        private static Tuple<int, int> FindChildIndices(int index)
        {
            int adjustedParentIndex = index + 1;
            int firstIndex = adjustedParentIndex * 2 - 1;
            int secondIndex = adjustedParentIndex * 2;
            return new Tuple<int, int>(firstIndex, secondIndex);
        }

        private bool Predicate(int childValue, int parentValue)
        {
            return Type == HeapType.MIN ? childValue < parentValue : childValue > parentValue;
        }
    }
}