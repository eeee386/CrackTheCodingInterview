using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Solutions
{
    public class BinaryTreeNode<T>
    {
        public readonly T data;
        public readonly BinaryTreeNode<T> left;
        public readonly BinaryTreeNode<T> right;
        public readonly BinaryTreeNode<T> parent;

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
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
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
            else
            {
                BinaryTreeNode<T> q = node;
                BinaryTreeNode<T> parent = q.parent;
                while (parent != null && parent.left != q)
                {
                    q = parent;
                    parent = parent.parent;
                }

                return parent;
            }
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

        
    }
}