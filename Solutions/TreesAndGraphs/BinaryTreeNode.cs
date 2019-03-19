using System;
using System.Collections.Generic;

namespace Solutions
{
    public class BinaryTreeNode<T>
    {
        public readonly T data;
        public readonly BinaryTreeNode<T> left;
        public readonly BinaryTreeNode<T> right;
        public readonly BinaryTreeNode<T> parent;
        public bool visited1;
        public bool visited2;

        public BinaryTreeNode(T data)
        {
            this.data = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> parent)
        {
            this.data = data;
            this.parent = parent;
        }

        public static void WriteInOrder(BinaryTreeNode<T> node)
        {
            WriteInOrder(node.left);
            Console.WriteLine(node.data);
            WriteInOrder(node.right);
        }
        
        public static void WritePreOrder(BinaryTreeNode<T> node)
        {
            Console.WriteLine(node.data);
            WritePreOrder(node.left);
            WritePreOrder(node.right);
        }

        public static void WritePostOrder(BinaryTreeNode<T> node)
        {
            WritePostOrder(node.left);
            WritePostOrder(node.right);
            Console.WriteLine(node.data);
        }

        public List<List<BinaryTreeNode<T>>> ListOfDepth()
        {
            int depth = 0;
            List<List<BinaryTreeNode<T>>> listOfDepths =  new List<List<BinaryTreeNode<T>>>();
            return ListOfDepthsHelper(this, depth, listOfDepths);
        }

        private static List<List<BinaryTreeNode<T>>> ListOfDepthsHelper(BinaryTreeNode<T> node, int depth = 0, List<List<BinaryTreeNode<T>>> listOfDepths = null)
        {
            if (listOfDepths == null)
            {
                listOfDepths = new List<List<BinaryTreeNode<T>>>();
            }
            if (listOfDepths[depth] == null)
            {
                listOfDepths[depth] = new List<BinaryTreeNode<T>>();
            }
            listOfDepths[depth].Add(node);
            if(node.left != null)
            {
                ListOfDepthsHelper(node.left, depth + 1, listOfDepths);
            }
            if(node.right != null)
            {
                ListOfDepthsHelper(node.right, depth + 1, listOfDepths);
            }
            return listOfDepths;
        }

        public bool IsBalanced()
        {
            return CheckHeight(this) != Int32.MinValue;
        }

        private static int CheckHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            int leftHeight = CheckHeight(node.left);
            if (leftHeight == Int32.MinValue)
            {
                return Int32.MinValue;
            }

            int rightHeight = CheckHeight(node.right);
            if (rightHeight == Int32.MinValue)
            {
                return Int32.MinValue;
            }

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
            {
                return Int32.MinValue;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static bool IsBinarySearchTree(BinaryTreeNode<int> node, int? min, int? max)
        {
            if (node == null)
            {
                return true;
            }

            if ((min != null && node.data <= min) || (max != null && node.data > max))
            {
                return false;
            }

            return IsBinarySearchTree(node.left, min, node.data) && IsBinarySearchTree(node.right, node.data, max);
        }

        public static BinaryTreeNode<T> InOrderSuccessor(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.right != null)
            {
                return LeftMostChild(node.right);
            }

            BinaryTreeNode<T> q = node;
            BinaryTreeNode<T> parent = q.parent;
            while (parent != null && parent.left != q)
            {
                q = parent;
                parent = parent.parent;
            }

            return parent;
        }

        private static BinaryTreeNode<T> LeftMostChild(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            while (node.left != null)
            {
                node = node.left;
            }

            return node;
        }

        public static BinaryTreeNode<T> FirstCommonAncestor(BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
        {
            BinaryTreeNode<T> traversalNode1 = node1;
            BinaryTreeNode<T> traversalNode2 = node2;
            while (traversalNode1 != null || traversalNode2 != null)
            {
                if (traversalNode1 != null)
                {
                    if (traversalNode1.visited2)
                    {
                        return traversalNode1;
                    }
                    traversalNode1.visited1 = true;
                }

                if (traversalNode2 != null)
                {
                    if (traversalNode2.visited1)
                    {
                        return traversalNode2;
                    }
                    traversalNode2.visited2 = true;
                }
                traversalNode1 = traversalNode1?.parent;
                traversalNode2 = traversalNode2?.parent;
            }
            throw new Exception("No ancestor node!");
        }

        public static int PathsWithSum(int value, int counter, BinaryTreeNode<int> node)
        {
            if (value == node.data)
            {
                return ++counter;
            }

            if (value < node.data)
            {
                return counter;
            }
            value = value - node.data;
            return PathsWithSum(value, counter, node.left) + PathsWithSum(value, counter, node.left);
        }
        
        public static bool CheckSubTree(BinaryTreeNode<int> bigger, BinaryTreeNode<int> smaller)
        {
            if (smaller.left == null && smaller.right == null)
            {
                return true;
            }

            if (smaller.left != null && smaller.right == null)
            {
                return smaller.left.data == bigger.left.data && CheckSubTree(bigger.left, smaller.left);
            }
            
            if (smaller.right != null && smaller.left == null)
            {
                return smaller.right.data == bigger.right.data && CheckSubTree(bigger.right, smaller.right);
            }

            if (smaller.left != null && smaller.right != null)
            {
                if (smaller.left.data != bigger.left.data && smaller.right.data != bigger.right.data)
                {
                    return false;
                }
                return CheckSubTree(bigger.left, smaller.left) && CheckSubTree(bigger.right, smaller.right);
            }
            return false;
        }
    }
}