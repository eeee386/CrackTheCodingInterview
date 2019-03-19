using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.TreesAndGraphs
{
    public class BinarySearchTreeNode : BinaryTreeNode<int>
    {
        public BinarySearchTreeNode Left;
        public BinarySearchTreeNode Right;

        public BinarySearchTreeNode(int data) : base(data)
        {
            
        }

        public static BinarySearchTreeNode CreateFromArray(int[] datas)
        {
            // used bigger when having an even, it would cause to be missing one from right
            // and not add it to the left;
            int middleIndex = datas.Length % 2 == 0 ? datas.Length / 2 : (datas.Length - 1) / 2;
            int middleValue = datas[datas.Length / 2 - 1];
            BinarySearchTreeNode node = new BinarySearchTreeNode(datas[middleIndex]);
            for (int i = 1; i < datas.Length; i++)
            {
                if(datas[i] != node.data)
                {
                    node.AddElement(datas[1]);
                }
            }
            return node;
        }

        public void AddElement(int dataToAdd)
        {
            if (dataToAdd <= data)
            {
                if (Left != null)
                {
                    Left.AddElement(dataToAdd); 
                }
                else
                {
                    Left = new BinarySearchTreeNode(dataToAdd);
                }
                
            }
            else
            {
                if (Right != null)
                {
                    Right.AddElement(dataToAdd);
                }
                else
                {
                    Right = new BinarySearchTreeNode(dataToAdd);
                }
            }
        }

        public BinarySearchTreeNode FindElement(int dataToFind)
        {
            if (data == dataToFind)
            {
                return this;
            }

            if (dataToFind < data)
            {
                if (Left == null)
                {
                    throw new Exception("No such element is found.");
                }
                return Left.FindElement(dataToFind);
            }

            if (dataToFind > data)
            {
                if (Right == null)
                {
                    throw new Exception("No such Element is found.");
                }
                return Right.FindElement(dataToFind);
            }
            // I think this is not needed, but compiler was whining.
            throw new Exception("No such element is found.");
        }

        public List<LinkedList<int>> getBSTSequence()
        {
            return BinarySearchTreeSequence(this);
        }

        private static List<LinkedList<int>> BinarySearchTreeSequence(BinarySearchTreeNode node)
        {
            List<LinkedList<int>> result = new List<LinkedList<int>>();

            if (node == null)
            {
                result.Add(new LinkedList<int>());
                return result;
            }
            
            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddLast(node.data);

            List<LinkedList<int>> leftSeq = BinarySearchTreeSequence(node.Left);
            List<LinkedList<int>> rightSeq = BinarySearchTreeSequence(node.Right);

            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    List<LinkedList<int>> weaved = new List<LinkedList<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    result.AddRange(weaved);
                }
            }
            return result;
        }

        private static void WeaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results,
            LinkedList<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                LinkedList<int> result = new LinkedList<int>(prefix);
                result = (LinkedList<int>) result.Concat(first);
                result = (LinkedList<int>) result.Concat(second);
                results.Add(result);
            }

            int headFirst = first.First.Value;
            first.RemoveFirst();

            prefix.AddLast(headFirst);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            first.AddFirst(headFirst);

            int headSecond = second.First.Value;
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }

        public static bool CheckSubtree(BinarySearchTreeNode bigger, BinarySearchTreeNode smaller)
        {
            if (smaller.Left == null && smaller.Right == null)
            {
                return true;
            }

            if (smaller.Left != null && smaller.Right == null)
            {
                return smaller.Left.data == bigger.Left.data && CheckSubtree(bigger.Left, smaller.Left);
            }
            
            if (smaller.Right != null && smaller.Left == null)
            {
                return smaller.Right.data == bigger.Right.data && CheckSubtree(bigger.Right, smaller.Right);
            }

            if (smaller.Left != null && smaller.Right != null)
            {
                if (smaller.Left.data != bigger.Left.data && smaller.Right.data != bigger.Right.data)
                {
                    return false;
                }
                return CheckSubtree(bigger.Left, smaller.Left) && CheckSubtree(bigger.Right, smaller.Right);
            }

            return false;
        }
    }
}