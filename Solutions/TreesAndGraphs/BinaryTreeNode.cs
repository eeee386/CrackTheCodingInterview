using System;

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
        
        
    }
}