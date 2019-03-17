using System;
using System.Collections.Generic;

namespace Solutions
{
    public class BinaryTreeNode<T>
    {
        public readonly T data;
        public readonly BinaryTreeNode<T> left;
        public readonly BinaryTreeNode<T> right;

        public BinaryTreeNode(T data)
        {
            this.data = data;
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


        
    }
}